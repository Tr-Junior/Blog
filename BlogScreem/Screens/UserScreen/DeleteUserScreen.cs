using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.UserScreens
{
    public static class DeleteUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Excluir uma tag");
            Console.WriteLine("-------------");
            List();
            Console.Write("Qual o id do usuário que deseja exluir? ");

            var id = Console.ReadLine();

            Delete(int.Parse(id!));
            Console.ReadKey();
            MenuUserScreen.Load();
        }
        private static void List()
        {
            var repository = new Repository<User>(Database.Connection);
            var user = repository.Get();
            foreach (var item in user)
                Console.WriteLine($"{item.Id} - {item.Name}");
        }

        public static void Delete(int id)
        {
            try
            {
                var repository = new Repository<Tag>(Database.Connection);
                repository.Delete(id);
                Console.WriteLine("Usuário exluído com sucesso!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Não foi possível exluir o Usuário");
                Console.WriteLine(ex.Message);
            }
        }
    }
}