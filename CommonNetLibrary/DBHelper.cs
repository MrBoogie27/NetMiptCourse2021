using MySql.Data.MySqlClient;
using WriteToDB;

namespace CommonNetLibrary
{
    public static class MyDB
    {
        public const string Schema = "study";
        public const string Database = "SomeCourse";
        public const string MainTable = "Submitted";

        public const string IdField = "id";
        public const string NameField = "name";
        public const string GroupField = "group";
        public const string TaskNumberField = "task_number";
        public const string ContextField = "context";

        private const string Host = "127.0.0.1";
        private const int Port = 3306;
        private const string Username = "root";
        private const string Password = "1111";
        public static string ConnString = "Server=" + Host + ";Charset=utf8"
                                            + ";port=" + Port + ";User Id=" + Username + ";password=" + Password;

        public static void CreateDb()
        {
            using (var conn = new MySqlConnection(ConnString))
            {
                conn.Open();
                var sqlCommand = new MySqlCommand("select count(*) from sysdatabases where name = " + Database, conn);
                if (sqlCommand.ExecuteReader().Read().ToString() != "0")
                {
                    sqlCommand = new MySqlCommand("CREATE DATABASE " + Database + ";", conn);
                    sqlCommand.ExecuteNonQuery();

                    sqlCommand = new MySqlCommand($@"CREATE TABLE {Database}.{MainTable} (
                                                        {NameField} TEXT NOT NULL,
                                                        {GroupField} TEXT NOT NULL,
                                                        {TaskNumberField} INTEGER  NOT NULL,
                                                        {ContextField} TEXT NOT NULL);", 
                                                  conn);
                    sqlCommand.ExecuteNonQuery();
                }
                sqlCommand.Dispose();
                conn.Close();
            }

            ConnString += ";Database" + Database;
        }

        public static void WriteToDb(StudentJob studentJob)
        {
            using (var conn = new MySqlConnection(ConnString))
            {
                conn.Open();

                var strSql = "insert into @table values(@name, @group, @task_number, @context)";
                var sqlCommand = new MySqlCommand(strSql, conn);
                sqlCommand.Parameters.AddWithValue("@table", MainTable);
                sqlCommand.Parameters.AddWithValue("@name", studentJob.Fio);
                sqlCommand.Parameters.AddWithValue("@group", studentJob.Group);
                sqlCommand.Parameters.AddWithValue("@task_number", studentJob.TaskNumber);
                sqlCommand.Parameters.AddWithValue("@context", studentJob.CodeContext);
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
