using System;
using System.Threading.Tasks;
using CommonNetLibrary;
using Grpc.Core;
using WriteToDB;

namespace ServerGRPC
{
    public class CodesDataBaseImpl : CodesDataBase.CodesDataBaseBase
    {
        public override Task<Request> Write(StudentJob studentJob, ServerCallContext context)
        {
            Console.WriteLine("Данные получены!");
            try
            {
                MyDB.WriteToDb(studentJob);

                return Task.FromResult(new Request()
                {
                    Message = "All right"
                });
            }
            catch (Exception ex)
            {
                return Task.FromResult(new Request()
                {
                    Message = ex.Message
                });
            }
        }
    }
}
