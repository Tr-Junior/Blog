using Blog.Models;
using Blog.Repositories;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog
{
    class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$!;Trusted_Connection=False; TrustServerCertificate=True;";
        static void Main(string[] args)
        {
            using var connection = new SqlConnection(CONNECTION_STRING);
            var repositoryU = new Repository<User>(connection);
            var repositoryR = new Repository<Role>(connection);
            var repositoryT = new Repository<Tag>(connection);


            //CreateUser(repository);
            //UpdateUser(repository);
            //DeleteUser(repository);
            //ReadRoles(repositoryR);
            //ReadTags(repositoryT);
            //ReadUsers(repositoryU);
            ReadWithRoles(connection);
        }
        public static void ReadUsers(Repository<User> repository)
        {
            var users = repository.Read();
            foreach (var item in users)
            {
                Console.WriteLine($"{item.Name} - {item.Email} - {item.Bio}");
            }

        }
        public static void ReadRoles(Repository<Role> repository)
        {
            var roles = repository.Read();
            foreach (var item in roles)
            {
                Console.WriteLine($"{item.Name}");
            }

        }
        public static void ReadTags(Repository<Tag> repository)
        {
            var tags = repository.Read();
            foreach (var item in tags)
            {
                Console.WriteLine($"{item.Name}");
            }

        }

        public static void CreateUser(Repository<User> repository)
        {
            var user = new User()
            {
                Bio = "Formado em Programação",
                Email = "tarcisioosicrat@gmail.com",
                Image = "https://avatars.githubusercontent.com/u/83793209?s=40&v=4",
                Name = "Tarcisio Júnior",
                Slug = "tarcisio-j",
                PasswordHash = Guid.NewGuid().ToString()
            };
            repository.Create(user);
            Console.WriteLine("Usuário cadastrado");


        }

        public static void UpdateUser(Repository<User> repository)
        {
            var user = new User()
            {
                Id = 1,
                Bio = "Programador Sênior",
                Email = "tarcisiomp@gmail.com",
                Image = "https://avatars.githubusercontent.com/u/83793209?s=40&v=4",
                Name = "Tarcisio Melo",
                Slug = "Tj",
                PasswordHash = Guid.NewGuid().ToString()
            };
            repository.Update(user);
            Console.WriteLine("Usuário Atualizado");


        }
        public static void DeleteUser(Repository<User> repository)
        {
            var user = repository.Read(5);
            repository.Delete(user);
            Console.WriteLine("Deletado com sucesso");
        }

        private static void ReadWithRoles(SqlConnection connection)
        {
            var repository = new UserRepository(connection);
            var users = repository.ReadWithRole();

            foreach (var user in users)
            {
                Console.WriteLine(user.Email);
                foreach (var role in user.Roles) Console.WriteLine($" - {role.Slug}");
            }
        }
    }
}
