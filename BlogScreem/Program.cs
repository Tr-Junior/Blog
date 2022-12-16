using System;
using Blog.Screens.TagScreens;
using Blog.Screens.UserScreens;
using Microsoft.Data.SqlClient;

namespace Blog
{
    class Program
    {
        private const string CONNECTION_STRING = @"Server=localhost,1433;Database=Blog;User ID=sa;Password=1q2w3e4r@#$!;Trusted_Connection=False; TrustServerCertificate=True;";

        static void Main(string[] args)
        {
            Database.Connection = new SqlConnection(CONNECTION_STRING);
            Database.Connection.Open();

            Menu();
            Database.Connection.Close();
        }

        public static void Menu()
        {
            Console.Clear();
            Console.WriteLine("Meu Blog");
            Console.WriteLine("-----------------");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine();
            Console.WriteLine("1 - Gestão de usuário");
            Console.WriteLine("2 - Gestão de perfil");
            Console.WriteLine("3 - Gestão de categoria");
            Console.WriteLine("4 - Gestão de tag");
            Console.WriteLine("5 - Gestão de funções");
            Console.WriteLine("6 - Gestão de posts");
            Console.WriteLine("7 - Relatórios");
            Console.WriteLine("8 - Sair");
            Console.WriteLine();
            Console.WriteLine();
            var option = short.Parse(Console.ReadLine()!);

            switch (option)
            {
                case 1:
                    MenuUserScreen.Load();
                    break;
                case 4:
                    MenuTagScreen.Load();
                    break;
                case 8:
                    Environment.Exit(0);
                    break;
            }
        }
    }
}