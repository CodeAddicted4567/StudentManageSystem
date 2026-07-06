using StudentMng.Areas.Users.Data;
using StudentMng.Contracts;
using StudentMng.DAL.Utils;
using System.Data;
using System.Data.SqlClient;

namespace StudentMng.DAL.Repositories
{
    public class UserRepo : IUserRepo
    {
        private readonly UserDBHelper Factory;
        public UserRepo(UserDBHelper _factory)
        {
            Factory = _factory;
        }
        public void AddUser(User user)
        {
            using (var conn = Factory.GetConnect())
            {
                conn.Open();
                string query = "INSERT INTO Users (Username, Password, Role) VALUES (@use,@pass,@role)";
                using(var cmd = new SqlCommand(query,conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@use", SqlDbType.NVarChar) { Value = user.UserName });
                    cmd.Parameters.Add(new SqlParameter("@pass", SqlDbType.NVarChar) { Value = user.Password });
                    cmd.Parameters.Add(new SqlParameter("@role", SqlDbType.NVarChar) { Value = user.Role });
                    cmd.ExecuteNonQuery();
                }
            }
        }
        public (string Username, string Role)? ValidateUser(string username, string password)
        {
            using (var conn = Factory.GetConnect())
            {
                conn.Open();

                string query = "SELECT Username, Role FROM Users WHERE Username=@u AND Password=@p";

                using (var cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.Add(new SqlParameter("@u", SqlDbType.NVarChar) { Value = username });
                    cmd.Parameters.Add(new SqlParameter("@p", SqlDbType.NVarChar) { Value = password });

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return (
                                reader["Username"].ToString(),
                                reader["Role"].ToString()
                            );
                        }
                    }
                }
            }

            return null;
        }
    }
}