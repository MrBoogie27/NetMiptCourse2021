using System;
using System.Net;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;
using CommonNetLibrary;

namespace ServerSocket
{
    class Program
    {
        private static int port = 8005;

        static void Main(string[] args)
        {
            var RSA = new RSACryptoServiceProvider(2048);
            Socket listenSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            var hostName = Dns.GetHostName();
            var hostAddresses = Dns.GetHostAddresses(hostName);
            var countAddress = hostAddresses.Length;
            if (countAddress <= 0)
            {
                Console.WriteLine("Свободные адреса не найдены");
                return;
            }
            IPEndPoint ipPoint = new IPEndPoint(hostAddresses[countAddress - 1], port);

            // связываем сокет с локальной точкой, по которой будем принимать данные
            listenSocket.Bind(ipPoint);
            
            // начинаем пsрослушивание
            listenSocket.Listen(10);
            Console.WriteLine($"Сервер запущен по адресу {ipPoint.Address}:{ipPoint.Port}. Ожидание подключений...");

            while (true)
            {
                using (var handler = listenSocket.Accept())
                { 
                    try
                    {
                        //Асинхронный ключ шифрования
                        handler.Send(Encoding.UTF8.GetBytes(RSA.ToXmlString(false)));
                        Console.WriteLine("Открытй ключ RSA отправлен");

                        //Синхронный ключ шифрования
                        var byteDES = RSA.Decrypt(HelperClass.RecieveMes(handler), true);
                        var myDES = HelperClass.ByteArrayToObject(byteDES) as MyDES;
                        var DES = new DESCryptoServiceProvider()
                        {
                            Key = myDES.key,
                            IV = myDES.IV
                        };

                        handler.Send(Encoding.UTF8.GetBytes("All right"));

                        MyDB.CreateDb();

                        var studentJob = HelperClass.ByteArrayToStudentJob(HelperClass.RecieveMes(handler), DES);
                        MyDB.WriteToDb(studentJob);

                        // отправляем ответ
                        string message = "Ваше сообщение доставлено";
                        byte[] info = Encoding.UTF8.GetBytes(message);
                        handler.Send(info);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        // отправляем ответ
                        string message = "Ваше сообщение было доставлено с ошибкой";
                        byte[] info = Encoding.UTF8.GetBytes(message);
                        handler.Send(info);
                    }
                }
                Console.WriteLine("Данные успешно обработаны");
            }
        }
    }
}
