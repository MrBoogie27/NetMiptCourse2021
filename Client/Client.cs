using System;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using Grpc.Core;
using RabbitMQ.Client;
using CommonNetLibrary;
using WriteToDB;

namespace Client
{
    public class Client
    {
        public void SendSocket(StudentJob record, string address)
        {
            const int port = 8005; // порт Socket сервера
            try
            {
                var socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                var ipPoint = new IPEndPoint(IPAddress.Parse(address), port);
                // подключаемся к удаленному хосту
                socket.Connect(ipPoint);

                //Асинхронный ключ шифрования
                var RSA = new RSACryptoServiceProvider();
                var rsaInBytes = HelperClass.RecieveMes(socket);
                RSA.FromXmlString(Encoding.UTF8.GetString(rsaInBytes));

                //Синхронный ключ шифрования
                var DES = new DESCryptoServiceProvider();
                DES.GenerateKey();
                DES.GenerateIV();
                var byteDES = HelperClass.ObjectToByteArray(new MyDES(DES.Key, DES.IV));
                var DESEncrypt = RSA.Encrypt(byteDES, true);
                socket.Send(DESEncrypt);

                var answerDes = HelperClass.RecieveMes(socket);

                //Данные
                var data = HelperClass.StudentJobToByteArray(record, DES);
                socket.Send(data);

                //Ответ
                var answer = HelperClass.RecieveMes(socket);
                MessageBox.Show("Ответ сервера: " + Encoding.UTF8.GetString(answer));

                // закрываем сокет
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void SendMQ(StudentJob record, string address)
        {
            var factory = new ConnectionFactory { HostName = address };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                //Асинхронный ключ шифрования
                var RSA = new RSACryptoServiceProvider();
                var rsaInBytes = HelperClass.RecieveMes(channel, "RSA");
                RSA.FromXmlString(Encoding.UTF8.GetString(rsaInBytes));

                //Синхронный ключ шифрования
                var DES = new DESCryptoServiceProvider();
                DES.GenerateKey();
                DES.GenerateIV();
                var byteDES = HelperClass.ObjectToByteArray(new MyDES(DES.Key, DES.IV));
                var DESEncrypt = RSA.Encrypt(byteDES, true);
                HelperClass.SendMes(channel, "DES", DESEncrypt);

                var body = HelperClass.StudentJobToByteArray(record, DES);
                HelperClass.SendMes(channel, "records", body);
            }
            MessageBox.Show(@"Send!");
        }

        public void SendGRPC(StudentJob record, string address)
        {
            const int port = 50051; // порт grpc сервера
            try
            {
                Channel channel = new Channel(address + ":" + port, ChannelCredentials.Insecure);
                MessageBox.Show(address);
                var client = new CodesDataBase.CodesDataBaseClient(channel);
                var reply = client.Write(record);
                MessageBox.Show(reply.Message);
                channel.ShutdownAsync().Wait();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
