using FacultyInformationSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FacultyInformationSystem.Data
{
    public class UserLogic : SqlQueries
    {
        public static int SignUpUser(int user_id, string e_mail, string pass, int user_type)
        {
            User data = new User
            {
                UserId = user_id,
                Email = e_mail,
                Password = pass,
                UserType = user_type
            };

            string sql = @"INSERT INTO [Users](UserId, Email, Password, UserType) VALUES(@UserId, @Email, @Password, @UserType);";

            return SqlQueries.CreateUser(sql, data);
        }

        public static List<User> SignInUser(int user_id, string e_mail, string pass, int user_type)
        {
            User data = new User
            {
                UserId = user_id,
                Email = e_mail,
                Password = pass,
                UserType = user_type
            };

            string sql = @"SELECT UserType FROM [Users] WHERE(Email = @Email AND Password = @Password);";

            return SqlQueries.CheckUser<User>(sql, data);
        }
    }
}
