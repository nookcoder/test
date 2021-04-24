using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace LectureTimeTable2.Login
{
    class LoginException : LoginScreen 
    {
        // 학번 예외처리 
        public string HandleIdException(string idChecker)
        {
            while (Constants.ERROR)
            {
                // 숫자만 입력받기(학번)
                if (Regex.IsMatch(idChecker, @"^[0-9]{8}$"))
                {
                    PrintLTT();
                    PrintId(idChecker);
                    break;
                }

                // q 입력 시 종료하기
                else if(idChecker == "q")
                {
                    Environment.Exit(0);
                }

                // 잘못 입력했을 시 반복 
                PrintLTT();
                PrintReWriteId();
                idChecker = Console.ReadLine();
            }

            return idChecker;
        }

        // 비밀번호 예외처리
        public string HandlePasswordException(string id, string passwordChecker)
        {
            while (Constants.ERROR)
            {
                // 숫자와 영문조합만 입력 받기
                if (Regex.IsMatch(passwordChecker, @"^[0-9a-zA-Z]{8,12}$"))
                {
                    PrintLTT();
                    PrintId(id);
                    PrintPassword(passwordChecker);
                    break;
                }

                // q 를 입력하면 종료 
                else if (passwordChecker == "q")
                {
                    Environment.Exit(0);
                }

                // 잘못 입력 했을 때 반복 
                PrintLTT();
                PrintId(id);
                PrintReWritePassword();
                passwordChecker = Console.ReadLine();
            }

            return passwordChecker;
        }

        // initialMenu 에서 1~6까지 숫자만 입력받기.
        public string HandleInitialMenu(string menuCheck)
        {
            while(Constants.ERROR)
            {
                if (Regex.IsMatch(menuCheck, @"^[1-6]$"))
                {
                    break;
                }

                PrintInitialMenu();
                PrintMenuError();
                menuCheck = Console.ReadLine();
            }

            return menuCheck;
        }

    }
}
