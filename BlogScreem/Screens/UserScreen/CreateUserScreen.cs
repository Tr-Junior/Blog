using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
    public static class CreateUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Novo Usuário");
            Console.WriteLine("-------------");
            Console.Write("Nome: ");
            var name = Console.ReadLine();

            Console.Write("Email: ");
            var email = Console.ReadLine();

            Console.Write("Passwrod: ");
            var passwordHash = Console.ReadLine();

            Console.Write("Bio: ");
            var bio = Console.ReadLine();

            Console.Write("Image: ");
            var image = Console.ReadLine();

            Console.Write("Slug: ");
            var slug = Console.ReadLine();

            Create(new User
            {
                Name = name,
                Email = email,
                PasswordHash = passwordHash,
                Bio = bio,
                Image = image,
                Slug = slug,

            });
            Console.WriteLine("Digite o Id da Função para Vincular ao usuário");
            Console.WriteLine("-------------");
            Console.WriteLine("Lista de Usuarios");
            List();
            Console.WriteLine("Lista de Funções");
            ListRole();
            Console.WriteLine("-------------");
            Console.Write("Id de usuário: ");
            var userId = int.Parse(Console.ReadLine()!);
            Console.Write("Id da função: ");
            var roleId = int.Parse(Console.ReadLine()!);

            CreateUserRole(new UserRole
            {
                UserId = userId,
                RoleId = roleId
            });
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        public static void Create(User User)
        {
            try
            {
                var repository = new Repository<User>(Database.Connection);
                repository.Create(User);
                Console.WriteLine("Usuário cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível salvar o usuário");
                Console.WriteLine(ex.Message);
            }
        }
        public static void CreateUserRole(UserRole UserRole)
        {
            try
            {
                var repository = new Repository<UserRole>(Database.Connection);
                repository.Create(UserRole);
                Console.WriteLine("Usuário cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível salvar o usuário");
                Console.WriteLine(ex.Message);
            }
        }
        private static void ListRole()
        {

            var repository = new Repository<Role>(Database.Connection);
            var roles = repository.Get();
            foreach (var role in roles)
                Console.WriteLine($"{role.Id} - {role.Name}");
        }
        private static void List()
        {
            var repository = new Repository<User>(Database.Connection);
            var user = repository.Get();
            foreach (var item in user)
                Console.WriteLine($"{item.Id} - {item.Name}");
        }
    }
}