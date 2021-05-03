using System;
using System.Data;
using MySql.Data.MySqlClient;
using Library_MySql.Controll;

namespace Library_MySql
{
    class LibraryMain
    {
        static void Main(string[] args)
        {
            InitialMenu initialMenu = new InitialMenu();
            Registration join = new Registration();
            initialMenu.RunMenu(join);
        }
    }
}
