using System;
using System.Security.Cryptography;
using System.Text;
using RabbitMQ.Client;
using CommonNetLibrary;

namespace ServerMQ
{
    class Program
    {
        static void Main(string[] args)
        {
            var RSA = new RSACryptoServiceProvider(2048);

            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
            };
            using (var connection = factory.CreateConnection())
            {
                while (true)
                {
                    using (var channel = connection.CreateModel())
                    {
                        try
                        {
                            //Асинхронный ключ шифрования
                            HelperClass.SendMes(channel, HelperClass.RsaQueue, Encoding.UTF8.GetBytes(RSA.ToXmlString(false)));

                            //Синхронный ключ шифрования
                            var byteDES = RSA.Decrypt(HelperClass.RecieveMes(channel, HelperClass.DesQueue), true);
                            var myDES = HelperClass.ByteArrayToObject(byteDES) as MyDES;
                            var DES = new DESCryptoServiceProvider()
                            {
                                Key = myDES.key,
                                IV = myDES.IV
                            };

                            MyDB.CreateDb();

                            //Сообщение
                            var studentJob = HelperClass.ByteArrayToStudentJob(HelperClass.RecieveMes(channel, HelperClass.RecordsQueue),
                                DES);
                            MyDB.WriteToDb(studentJob);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    }
                }
            }
        }
    }
}
