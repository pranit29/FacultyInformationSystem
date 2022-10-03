using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace FacultyInformationSystem.Data
{
    public class SqlQueries
    {
        public static string GetConnectionString(string connectionName = "DefaultConnection")
        {
            //var connectionString = "Data Source=tcp:facultyinformationsystemdbserver.database.windows.net,1433;Initial Catalog=FacultyInformationSystem_db;User Id=KetanRaul@facultyinformationsystemdbserver;Password=Rajkunwar@1";
            var connectionString = "Data Source=tcp:facultyinformationsystemserver.database.windows.net,1433;Initial Catalog=FacultyInformationSystemdb;User Id=pranit@facultyinformationsystemserver;Password=Shinde@1234567";

           // var connectionString = "Server = PRANIT; Database = FDB; Trusted_Connection = True; MultipleActiveResultSets = true";
            return connectionString;
        }
        public static int CreateUser<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Execute(sql, data);
            }
        }

        public static List<T> CheckUser<T>(string sql, T data)
        {
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                return cnn.Query<T>(sql, data).ToList();
            }
        }
    }
}
