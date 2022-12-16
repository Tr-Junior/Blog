using System;

namespace Blog.Screens.UserScreens
{
    public static class MenuUserScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de tags");
            Console.WriteLine("--------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar usuários");
            Console.WriteLine("2 - Cadastrar usuários");
            Console.WriteLine("3 - Atualizar usuários");
            Console.WriteLine("4 - Excluir usuários");
            Console.WriteLine("5 - Retornar ao menu anterior");
            Console.WriteLine("6 - Sair");
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1:
                    ListUserScreen.Load();
                    break;
                case 2:
                    CreateUserScreen.Load();
                    break;
                case 3:
                    UpdateUserScreen.Load();
                    break;
                case 4:
                    DeleteUserScreen.Load();
                    break;
                case 5:
                    Program.Menu();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}