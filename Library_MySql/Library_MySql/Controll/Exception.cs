using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Library_MySql
{
    class Exception
    {
        private Exception() { }

        private static Exception exception = null;

        public static Exception Instance()
        {
            if (exception == null)
            {
                exception = new Exception();
            }

            return exception;
        }

        public string HandleGetId(string idCheck)
        {
            Regex regex = new Regex(@"^[0-9a-zA-Z]");

            while (!regex.IsMatch(idCheck) || idCheck == null)
            {
                Console.SetCursorPosition(0, 3);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, 0);
                Initialization.screen.PrintGetId();
                Console.SetCursorPosition(0, 5);
                Initialization.screen.PrintInputError();
                Console.SetCursorPosition(24, 4);
                idCheck = Console.ReadLine();
            }
            Console.SetCursorPosition(0, 5);
            Console.Write(new String(' ', 1000));
            Console.SetCursorPosition(0, 4);

            return idCheck;
        }

        public string HandleGetPassword(string idCheck)
        {
            Regex regex = new Regex(@"^[0-9a-zA-Z]");

            while (!regex.IsMatch(idCheck) || idCheck == null)
            {
                Console.SetCursorPosition(0, 7);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, 4);
                Initialization.screen.PrintGetPassword();
                Console.SetCursorPosition(0, 9);
                Initialization.screen.PrintInputError();
                Console.SetCursorPosition(24, 8);
                idCheck = Console.ReadLine();
            }
            Console.SetCursorPosition(0, 9);
            Console.Write(new String(' ', 1000));
            Console.SetCursorPosition(0, 9);

            return idCheck;
        }
    }
}
