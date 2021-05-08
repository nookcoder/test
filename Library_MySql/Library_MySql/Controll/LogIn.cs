using Library_MySql.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_MySql.Controll
{
    class LogIn
    {

        public LogIn()
        {

        }

        public string GetId()
        {
            string idCheck;
            string id;

            Initialization.screen.PrintExit();
            Initialization.screen.PrintGetLoginId();
            idCheck = Console.ReadLine();
            id = Initialization.exception.HandleGetIdInLogin(idCheck);

            return id;
        }

        public string GetPassword()
        {
            string passwordCheck;
            string password;

            Initialization.screen.PrintGetPassword();
            passwordCheck = Console.ReadLine();
            password = Initialization.exception.HandleGetPasswordInLogin(passwordCheck);

            return password;
        }

        public string GetManagerCode()
        {
            string code;

            Console.Clear();
            Initialization.screen.PrintGetManagerCode();
            code = Console.ReadLine();

            return code;
        }

        public Tuple<bool,string> RunCheckMember(MemberData memberData)
        {
            string id;
            string password;

            bool isSuccess = false;

            Console.Clear();
            id = GetId();

            if (id != "q")
            {
                password = GetPassword();
                if (password != "q")
                {
                    if (memberData.IsMemberIdDuplication(id))
                    {
                        if (memberData.IsMemberPasswordDuplication(id, password))
                        {
                            Initialization.screen.PrintLoginSuccess();
                            Initialization.log.RecordWithNoBook(id, "로그인");
                            isSuccess = true;
                        }

                        else
                        {
                            Initialization.screen.PrintFailLogin();
                        }
                    }

                    else
                    {
                        Initialization.screen.PrintFailLogin();
                    }
                }

                else { }

            }

            else { }

            var result = Tuple.Create<bool, string>(isSuccess, id);
            return result;
        }

        public bool RunCheckManager()
        {
            bool isRight = false;
            string code;

            code = GetManagerCode();

            if (code == "*")
            {
                isRight = true;
                Initialization.log.RecordWithNoBook("관리자", "로그인");
                Initialization.screen.PrintLoginSuccess();
            }

            else
            {
                Initialization.screen.PrintFailLogin();
            }

            return isRight;
        }
    }
}
