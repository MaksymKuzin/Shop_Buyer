//using Microsoft.Data.SqlClient;
//using DAL.Interface;
//using DTO;

//namespace DAL.Concrete
//{
//    public class UserDal : IUserDal
//    {
//        private readonly string _connectionString;

//        public UserDal(string connectionString)
//        {
//            _connectionString = connectionString;
//        }

//        public int AddUser(UserDto user)
//        {
//            using (var connection = new SqlConnection(_connectionString))
//            {
//                var command = new SqlCommand("INSERT INTO Users (Name, Email, Password) OUTPUT INSERTED.UserId VALUES (@Name, @Email, @Password)", connection);
//                command.Parameters.AddWithValue("@Name", user.Name);
//                command.Parameters.AddWithValue("@Email", user.Email);
//                command.Parameters.AddWithValue("@Password", user.Password);

//                connection.Open();
//                return (int)command.ExecuteScalar();
//            }
//        }

//        public UserDto GetUserById(int userId)
//        {
//            using (var connection = new SqlConnection(_connectionString))
//            {
//                var command = new SqlCommand("SELECT UserId, Name, Email FROM Users WHERE UserId = @UserId", connection);
//                command.Parameters.AddWithValue("@UserId", userId);
//                connection.Open();

//                using (var reader = command.ExecuteReader())
//                {
//                    if (reader.Read())
//                    {
//                        return new UserDto
//                        {
//                            UserId = reader.GetInt32(0),
//                            Name = reader.GetString(1),
//                            Email = reader.GetString(2)
//                        };
//                    }
//                    return null;
//                }
//            }
//        }
//    }

//}
