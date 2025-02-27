﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReLibrary.VO;

namespace ReLibrary.Controller
{
    class Login
    {
        List<UserVO> userList;
        List<BooksVO> bookList;
        public Login(List<UserVO> userList, List<BooksVO> bookList)
        {
            this.bookList = bookList;
            this.userList = userList;
        }
        
        public void TryLogin()
        {
            string Id;
            string password;

            Screen screen = new Screen();
            Console.Clear();
            screen.PrintLoginId(null);
            Id = Console.ReadLine();
            screen.PrintSignUpPassword();
            password = Console.ReadLine();
            CheckIdPassword(Id, password);
        }

        public void CheckIdPassword(string id,string password)
        {
            bool isFound = false; 

            for(int index = 0; index < userList.Count; index++)
            {
                if(userList[index].Id == id && userList[index].Password == password)
                {
                    isFound = true;
                }
            }

            if(isFound)
            {
                //LoadUserBookMenu();
            }

            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" ");
                Console.WriteLine("           아이디 혹은 비밀번호가 일치하지않습니다.");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
                UserLoginPage userLogin = new UserLoginPage(userList,bookList);
                userLogin.GoUserLoginNextMenu();
            }
        }
    }
}
