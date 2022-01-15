using Google.Protobuf;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Security.Cryptography;
using WriteToDB;

namespace CommonNetLibrary
{
    public static class HelperClass
    {
        public const string RsaQueue = "RSA";
        public const string DesQueue = "DES";
        public const string RecordsQueue = "records";

        #region Шифрование

        public static byte[] StudentJobToByteArray(StudentJob obj, DES des)
        {
            using (var encryptor = des.CreateEncryptor())
            {
                var temp = ProtoSerialize(obj);
                return encryptor.TransformFinalBlock(temp, 0, temp.Length);
            }
        }

        public static StudentJob ByteArrayToStudentJob(byte[] arrBytes, DES des)
        {
            using (var decryptor = des.CreateDecryptor())
            {
                var temp = decryptor.TransformFinalBlock(arrBytes, 0, arrBytes.Length);
                return ProtoDeserialize(temp) as StudentJob;
            }
        }

        #endregion

        #region Сериализация
        public static byte[] ProtoSerialize(StudentJob record)
        {
            
            using (var stream = new MemoryStream())
            {
                record.WriteTo(stream);
                return stream.ToArray();
            }
        }

        public static StudentJob ProtoDeserialize(byte[] data)
        {
            using (var stream = new MemoryStream(data))
            {
                return StudentJob.Parser.ParseFrom(stream);
            }
        }

        public static byte[] ObjectToByteArray(object obj)
        {
            BinaryFormatter bf = new BinaryFormatter();
            using (var ms = new MemoryStream())
            {
                bf.Serialize(ms, obj);
                return ms.ToArray();
            }
        }

        public static object ByteArrayToObject(byte[] arrBytes)
        {
            using (var memStream = new MemoryStream())
            {
                var binForm = new BinaryFormatter();
                memStream.Write(arrBytes, 0, arrBytes.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                var obj = binForm.Deserialize(memStream);
                return obj;
            }
        }
        #endregion

        #region Сокеты
        public static byte[] RecieveMes(Socket socket)
        {
            // получаем сообщение
            List<byte> builder = new List<byte>();
            int bytes = 0; // количество полученных байтов
            byte[] data = new byte[256]; // буфер для получаемых данных
            do
            {
                bytes = socket.Receive(data);
                for (int i = 0; i < bytes; i++)
                    builder.Add(data[i]);
            } while (socket.Available > 0);

            return builder.ToArray();
        }
        #endregion

        #region Очередь сообщений
        public static void SendMes(IModel channel, string nameQueue, byte[] body)
        {
            channel.QueueDeclare(nameQueue, true, false);

            channel.ExchangeDeclare(nameQueue, ExchangeType.Fanout, true);

            channel.BasicPublish("",
                nameQueue,
                null,
                body);

            Console.WriteLine($"Сообщение доставлено в очередь {nameQueue}");
        }

        public static byte[] RecieveMes(IModel channel, string nameQueue)
        {
            channel.QueueDeclare(nameQueue, true, false);

            channel.ExchangeDeclare(nameQueue, ExchangeType.Fanout, true);

            var consumer = new EventingBasicConsumer(channel);

            byte[] rsaInBytes = null;

            consumer.Received += (model, ea) =>
            {
                rsaInBytes = ea.Body;
            };

            channel.BasicConsume(nameQueue,
                true,
                consumer);

            while (rsaInBytes == null)
            { }
            Console.WriteLine($"Сообщение принято из очереди {nameQueue}");
            return rsaInBytes;
        }
        #endregion
    }
}
