using MySql.Data.MySqlClient;
using WriteToDB;

namespace CommonNetLibrary
{
    public static class MyDB
    {
        public const string Database = "somecourse";
        public const string MainTable = "Submitted";

        public const string IdField = "id";
        public const string NameField = "name";
        public const string GroupField = "group_name";
        public const string TaskNumberField = "task_number";
        public const string ContextField = "context";

        private const string Host = "127.0.0.1";
        private const int Port = 3306;
        private const string Username = "root";
        private const string Password = "1111";
        public static string ConnString = "Server=" + Host + ";Database= " + Database + ";Charset=utf8"
                                            + ";port=" + Port + ";User Id=" + Username + ";password=" + Password;

        public static void CreateDb()
        {
            using (var conn = new MySqlConnection(ConnString))
            {
                conn.Open();
                var sqlCommand = new MySqlCommand($@"SELECT table_name
                                                     FROM information_schema.tables
                                                     WHERE table_schema = '{Database}' and table_name = '{MainTable}';",
                                                  conn);
                var reader = sqlCommand.ExecuteReader();
                var any_rows = reader.HasRows;
                reader.Close();
                if (!any_rows)
                {
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
        }

        public static void WriteToDb(StudentJob studentJob)
        {
            using (var conn = new MySqlConnection(ConnString))
            {
                conn.Open();

                var strSql = $"insert into {MainTable} values(@name, @group, @task_number, @context)";
                var sqlCommand = new MySqlCommand(strSql, conn);
                sqlCommand.Parameters.AddWithValue("@name", studentJob.Fio);
                sqlCommand.Parameters.AddWithValue("@group", studentJob.Group);
                sqlCommand.Parameters.AddWithValue("@task_number", studentJob.TaskNumber);
                sqlCommand.Parameters.AddWithValue("@context", studentJob.CodeContext);
                sqlCommand.ExecuteNonQuery();
            }
        }
    }
}
