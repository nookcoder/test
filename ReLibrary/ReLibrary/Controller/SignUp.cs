using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using ReLibrary.Model;
using ReLibrary.VO;
using ReLibrary.Controller;

namespace ReLibrary.Controller
{
    class SignUp
    {
        private string name;
        private string phoneNumber;
        private string address;
        private string id;
        private string password;



        public SignUp()
        {
        }

        // 입력 값 처리 함수 
        public string InputName()
        {
            string temp;

            Screen screen = new Screen();
            Except except = new Except();

            screen.PrintSignUpName(null);
            temp = Console.ReadLine();
            name = except.HandleUserNameExcept(temp);

            return name;
        }

        public string InputNumber(string name)
        {
            string temp;

            Screen screen = new Screen();
            Except except = new Except();

            screen.PrintSignUpName(name);
            screen.PrintSignUpPhoneNumber(null);
            temp = Console.ReadLine();
            phoneNumber = except.HandlePhoneNumberExcept(temp, name);

            return phoneNumber;
        }

        public string InputAdress(string name, string phoneNumber)
        {
            string address;

            Screen screen = new Screen();
            screen.PrintSignUpName(name);
            screen.PrintSignUpPhoneNumber(phoneNumber);
            screen.PrintSignUpAddress(null);
            address = Console.ReadLine();

            return address;
        }

        public string InputId(string name, string phoneNumber,string address)
        {
            string temp;
            string id; 
            
            Screen screen = new Screen();
            Except except = new Except();

            screen.PrintSignUpName(name);
            screen.PrintSignUpPhoneNumber(phoneNumber);
            screen.PrintSignUpAddress(address);
            screen.PrintSignUpId(null);
            temp = Console.ReadLine();
            id = except.HandleIdExcept(name, phoneNumber, address, temp);
            
            return id;
        }

        public SecureString MaskingPassword()
        {
            SecureString password = new SecureString();
            while(true)
            {
                ConsoleKeyInfo i = Console.ReadKey(true);
                if (i.Key == ConsoleKey.Enter)
                {
                    break;
                }

                else if (i.Key == ConsoleKey.Backspace)
                {
                    password.RemoveAt(password.Length - 1);
                    Console.Write("\b \b");
                }

                else;
                {
                    password.AppendChar(i.KeyChar);
                    Console.Write("*");
                }
            }

            return password;
        }

        public string InputPassword(string name, string phoneNumber, string address, string id)
        {
            string password; 

            Screen screen = new Screen();

            screen.PrintSignUpName(name);
            screen.PrintSignUpPhoneNumber(phoneNumber);
            screen.PrintSignUpAddress(address);
            screen.PrintSignUpId(id);
            screen.PrintSignUpPassword();
            password = Console.ReadLine();
            Console.WriteLine("\n");
            Console.WriteLine("                   회원가입이 완료되었습니다.");
            Console.ReadKey();

            return password;
        }
    }
}
