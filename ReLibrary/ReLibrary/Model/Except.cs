﻿using System;

namespace ReLibrary.Model
{
    class Except
    {
        public int HandleFirstMenuExcept(string check)
        {
            int menu = Constants.RESET;
            bool isError = true;
            Screen screen = new Screen();

            while (isError)
            {
                if (check == "1" || check == "2" || check == "3")
                {
                    menu = int.Parse(check);
                    isError = Constants.NOERROR;
                }

                else
                {
                    Console.Clear();
                    Console.Clear();
                    screen.PrintLabel();
                    screen.PrintFirstPage();
                    screen.PrintPageError();
                    screen.PrintInput();
                    check = Console.ReadLine();
                }
            }

            return menu;
        }

        public int HandleUserMenuExcept(string check)
        {
            int menu = Constants.RESET;
            bool isError = true;
            Screen screen = new Screen();

            while (isError)
            {
                if (check == "1" || check == "2" || check == "3" || check == "4" || check == "5")
                {
                    menu = int.Parse(check);
                    isError = Constants.NOERROR;
                }

                else
                {
                    Console.Clear();
                    screen.PrintLabel();
                    screen.PrintUserLoginPage();
                    screen.PrintPageError();
                    screen.PrintInput();
                    check = Console.ReadLine();
                }
            }

            return menu;
        }

        public string HandleUserNameExcept(string name)
        {
            bool isError = true;

            while (isError)
            {
                if (name.Length >= 2 && name.Length <= 4)
                {
                    for (int index = 0; index < name.Length; index++)
                    {
                        if ((0xAC00 > name[index] || name[index] > 0xD7A3) || (0x3131 > name[index] && name[index] > 0x318E))
                        {
                            Screen screen = new Screen();
                            screen.PrintNameError();
                            name = Console.ReadLine();
                        }

                        else
                        {
                            isError = Constants.NOERROR;
                        }
                    }
                }

                else
                {
                    Screen screen = new Screen();
                    screen.PrintNameError();
                    name = Console.ReadLine();
                }
            }
            return name;
        }

        public string HandlePhoneNumberExcept(string phoneNumber,string name)
        {
            bool isError = true;
            Screen screen = new Screen();

            while(isError)
            {
                if(phoneNumber.Length == 11)
                {
                    for(int index = 0; index < phoneNumber.Length; index++)
                    {
                        if(phoneNumber[index] != '1' && phoneNumber[index] != '2' && phoneNumber[index] != '3' &&
                           phoneNumber[index] != '4' && phoneNumber[index] != '5' && phoneNumber[index] != '6' &&
                           phoneNumber[index] != '7' && phoneNumber[index] != '8' && phoneNumber[index] != '9' && phoneNumber[index] != '0')
                        {
                            screen.PrintPhoneNumberError(name);
                            phoneNumber = Console.ReadLine();
                        }

                        else
                        {
                            isError = Constants.NOERROR;
                        }
                    }
                }

                else
                {
                    screen.PrintPhoneNumberError(name);
                    phoneNumber = Console.ReadLine();
                }
            }

            return phoneNumber;
        }

        public string HandleIdExcept(string name, string phoneNumber, string address, string id)
        {
            bool isError = true;
            Screen screen = new Screen();

            while(isError)
            {
                if(id.Length >= 8)
                {
                    isError = Constants.NOERROR;
                }

                else
                {
                    screen.PrintSignUpName(name);
                    screen.PrintSignUpPhoneNumber(phoneNumber);
                    screen.PrintSignUpAddress(address);
                    screen.PrintIdError(name,phoneNumber,address);
                    id = Console.ReadLine();
                }
            }

            return id;
        }
    }

}
