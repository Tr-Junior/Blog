using System;
using Blog.Models;
using Blog.Repositories;

namespace Blog.Screens.RoleScreens
{
    public static class MenuRoleScreen
    {
        public static void Load()
        {
            Console.Clear();
            Console.WriteLine("Gestão de funções");
            Console.WriteLine("--------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Listar função");
            Console.WriteLine("2 - Cadastrar função");
            Console.WriteLine("3 - Atualizarfunção");
            Console.WriteLine("4 - Excluir função");
            Console.WriteLine("5 - Retornar ao menu anterior");
            Console.WriteLine("6 - Sair");
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1:
                    ListRoleScreen.Load();
                    break;
                case 2:
                    CreateRoleScreen.Load();
                    break;
                case 3:
                    // UpdateRoleScreen.Load();
                    break;
                case 4:
                    //DeleteRoleScreen.Load();
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