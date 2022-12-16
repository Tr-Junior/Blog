using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
    public static class ListUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Lista de Usuários");
            Console.WriteLine("-------------");
            List();
            Console.ReadKey();
            MenuUserScreen.Load();
        }

        private static void List()
        {

            var repository = new UserRepository(Database.Connection);
            var users = repository.ReadWithRole();

            foreach (var user in users)
            {
                Console.WriteLine($"{user.Name} - {user.Email} - {user.Bio}");
                foreach (var role in user.Roles!)
                    Console.WriteLine($" - {role.Name}");
            }

            // var repository = new Repository<User>(Database.Connection);
            // var user = repository.Get();
            // foreach (var item in user)
            //     Console.WriteLine($"{item.Name} - {item.Email} ({item.Roles}) - {item.Slug}");
        }
    }
}