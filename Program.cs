using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
    class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=balta;User ID=sa;Password=1q2w3e4r@#$!;Trusted_Connection=False; TrustServerCertificate=True;";
        static void Main(string[] args)
        {
            System.Console.WriteLine("");
        }
        public static void ReadUsers()
        {
            using (var connection = new SqlConnection(CONNECTION_STRING))
            {
                var users = connection.GetAll<User>();

                foreach (var user in users)
                {
                    System.Console.WriteLine(user.Name);
                }
            }
        }
    }
}