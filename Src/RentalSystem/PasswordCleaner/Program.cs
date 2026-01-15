using System.Configuration;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace PasswordCleaner
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            string login;
            string newPassword;

            if (args.Length != 2)
            {
                login = "admin";
                newPassword = "admin";
            }
            else
            {
                login = args[0];
                newPassword = args[1];
            }

            var connectionString = ConfigurationManager.ConnectionStrings["RentalSystemConnectionString"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand("", connection))
                {
                    command.CommandText = "update [Users] set [Password] = @password where [Login] = @login";

                    command.Parameters.AddWithValue("@password", GetNewPassword(newPassword));
                    command.Parameters.AddWithValue("@login", login);

                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        private static byte[] GetNewPassword(string password)
        {
            return MD5.Create().ComputeHash(Encoding.Unicode.GetBytes(password));
        }
    }
}