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

        public string HandleGetId(string check)
        {
            Regex regex = new Regex(@"^[0-9a-zA-Z]");

            while (!regex.IsMatch(check) || check?.Length == 0)
            {
                Console.SetCursorPosition(0, 3);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, 0);
                Initialization.screen.PrintGetId();
                Console.SetCursorPosition(0, 5);
                Initialization.screen.PrintInputError();
                Console.SetCursorPosition(24, 4);
                check = Console.ReadLine();
            }
            Console.SetCursorPosition(0, 5);
            Console.Write(new String(' ', 1000));
            Console.SetCursorPosition(0, 4);

            return check;
        }

        public string HandleGetPassword(string check)
        {
            Regex regex = new Regex(@"^[0-9a-zA-Z]");

            while (!regex.IsMatch(check) || check == null)
            {
                Console.SetCursorPosition(0, 7);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, 4);
                Initialization.screen.PrintGetPassword();
                Console.SetCursorPosition(0, 9);
                Initialization.screen.PrintInputError();
                Console.SetCursorPosition(26, 8);
                check = Console.ReadLine();
            }
            Console.SetCursorPosition(0, 9);
            Console.Write(new String(' ', 1000));
            Console.SetCursorPosition(0, 8);

            return check;
        }

        public string HandleGetName(string check)
        {
            Regex regex = new Regex(@"^[가-힣a-zA-Z]{2,}");

            while (!regex.IsMatch(check) || check == null)
            {
                Console.SetCursorPosition(0, 11);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, 8);
                Initialization.screen.PrintGetName();
                Console.SetCursorPosition(0, 13);
                Initialization.screen.PrintInputError();
                Console.SetCursorPosition(9, 12);
                check = Console.ReadLine();
            }
            Console.SetCursorPosition(0, 13);
            Console.Write(new String(' ', 1000));
            Console.SetCursorPosition(0, 12);

            return check;
        }
        public string HandleGetPhoneNumber(string check)
        {
            Regex regex = new Regex(@"^(010)(\d{4})(\d)");
            Regex regex1 = new Regex(@"^(011)(\d{4})(\d)");
            while (!regex.IsMatch(check) || regex1.IsMatch(check))
            {
                Console.SetCursorPosition(0, 15);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, 12);
                Initialization.screen.PrintGetPhoneNumber();
                Console.SetCursorPosition(0, 17);
                Initialization.screen.PrintInputError();
                Console.SetCursorPosition(23, 16);
                check = Console.ReadLine();
            }
            Console.SetCursorPosition(0, 17);
            Console.Write(new String(' ', 1000));
            Console.SetCursorPosition(0, 16);

            return check;
        }

        public string HandleGetAddress(string check)
        {
            Regex regex = new Regex(@"([가-힣]+)시 ([가-힣0-9]+)대로");
            Regex regex1 = new Regex(@"([가-힣]+)시 ([가-힣0-9]+)로");
            Regex regex2 = new Regex(@"([가-힣]+)시 ([가-힣0-9]+)길");
            while (!regex.IsMatch(check) && !regex1.IsMatch(check) && !regex2.IsMatch(check))
            {
                Console.SetCursorPosition(0, 19);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, 16);
                Initialization.screen.PrintGetAddress();
                Console.SetCursorPosition(0, 21);
                Initialization.screen.PrintInputError();
                Console.SetCursorPosition(28, 20);
                check = Console.ReadLine();
            }
            Console.SetCursorPosition(0, 21);
            Console.Write(new String(' ', 1000));
            Console.SetCursorPosition(0, 20);

            return check;
        }

    }
}
