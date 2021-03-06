using System;
using System.Linq;
using System.Net;
using Grpc.Core;
using WriteToDB;

namespace ServerGRPC
{
    class Program
    {
        private const int Port = 50051;
        static void Main(string[] args)
        {
            Server server = new Server
            {
                Services = { CodesDataBase.BindService(new CodesDataBaseImpl()) },
                Ports = { new ServerPort(Dns.GetHostName(), Port, ServerCredentials.Insecure) }
            };
            server.Start();

            Console.WriteLine($"ServerGRPC listening on port {server.Ports.First().Port} in addresses: ");
            foreach (var address in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (!address.IsIPv6LinkLocal)
                    Console.WriteLine(address.ToString());
            }

            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
    }

}
