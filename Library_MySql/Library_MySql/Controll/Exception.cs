﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Library_MySql.Model;

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

        /// <summary>
        /// 회원가입 예외처리 함수
        /// </summary>

        // 아이디 예외처리 
        public string HandleGetId(string check, MemberData memberData)
        {
            Regex regex = new Regex(@"^[0-9a-zA-Z]");

            // 숫자 영어 로만 이루어진 아이디인지, 중복되는 아이디가 없는 지 확인
            while (!regex.IsMatch(check) || check?.Length == 0 || memberData.IsMemberIdDuplication(check))
            {
                Console.SetCursorPosition(0, 3);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, 0);
                Initialization.screen.PrintGetId();
                Console.SetCursorPosition(0, 5);

                if (!regex.IsMatch(check) || check?.Length == 0)
                {
                    Initialization.screen.PrintInputError();
                }

                else if (memberData.IsMemberIdDuplication(check))
                {
                    Initialization.screen.PrintIdDuplicationError();
                }

                Console.SetCursorPosition(24, 3);
                check = Console.ReadLine();
            }

            Console.SetCursorPosition(0, 5);
            Console.Write(new String(' ', 1000));
            Console.SetCursorPosition(0, 4);

            return check;
        }

        // 비밀번호 예외처리 
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

        // 이름 예외처리 
        public string HandleGetName(string check)
        {
            Regex regex = new Regex(@"^[가-힣a-zA-Z]{2,}$");

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

        // 전화번호 예외처리 (중복 방지) 
        public string HandleGetPhoneNumber(string check, MemberData memberData)
        {
            Regex regex = new Regex(@"^(010)(\d{4})(\d)");
            Regex regex1 = new Regex(@"^(011)(\d{4})(\d)");
            while ((!regex.IsMatch(check) && !regex1.IsMatch(check)) || memberData.IsMemberPhoneNumberDuplication(check))
            {
                Console.SetCursorPosition(0, 15);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, 12);
                Initialization.screen.PrintGetPhoneNumber();
                Console.SetCursorPosition(0, 17);

                if (!regex.IsMatch(check) || !regex1.IsMatch(check))
                {
                    Initialization.screen.PrintInputError();
                }

                else if (memberData.IsMemberPhoneNumberDuplication(check))
                {
                    Initialization.screen.PrintPhoneNumberDuplicationError();
                }

                Console.SetCursorPosition(23, 16);
                check = Console.ReadLine();
            }
            Console.SetCursorPosition(0, 17);
            Console.Write(new String(' ', 1000));
            Console.SetCursorPosition(0, 16);

            return check;
        }

        // 주소 예외처리 
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

        /// <summary>
        /// 도서 예외처리
        /// </summary>

        // 도서 번호 예외처리 
        public string HandleGetBookUd(string check, BookData bookData)
        {
            Regex regex = new Regex(@"^[0-9]{1,7}$");
            while (!regex.IsMatch(check) || bookData.IsBookIdDuplication(check))
            {
                Console.SetCursorPosition(0, 3);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, 0);
                Initialization.screen.PrintGetBookId();
                Console.SetCursorPosition(0, 5);

                if (!regex.IsMatch(check))
                {
                    Initialization.screen.PrintInputError();
                }

                // 도서 중복막기
                else if (bookData.IsBookIdDuplication(check))
                {
                    Initialization.screen.PrintBookIdDuplicationError();
                }

                Console.SetCursorPosition(14, 4);
                check = Console.ReadLine();
            }
            Console.SetCursorPosition(0, 5);
            Console.Write(new String(' ', 1000));
            Console.SetCursorPosition(0, 4);

            return check;
        }

        public string HandleGetBookIdInModification(string check)
        {
            Regex regex = new Regex(@"^[0-9]{1,7}$");
            while (!regex.IsMatch(check) && check != "q")
            {
                Console.SetCursorPosition(0, 4);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, 2);
                Initialization.screen.PrintGetBookId();
                Console.SetCursorPosition(0, 7);
                Initialization.screen.PrintInputError();

                Console.SetCursorPosition(14, 6);
                check = Console.ReadLine();
            }
            Console.SetCursorPosition(0, 6);
            Console.Write(new String(' ', 1000));
            Console.SetCursorPosition(0, 5);

            return check;
        }

        public string HandleGetBookPriceInModification(string check)
        {
            Regex regex = new Regex(@"^[0-9]");

            while ((!regex.IsMatch(check) || check == null || check.Length > 6) && check != "q")
            {
                Console.SetCursorPosition(0, 4);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, 2);
                Initialization.screen.PrintGetBookPrice();
                Console.SetCursorPosition(0, 7);

                if (!regex.IsMatch(check) || check == null)
                {
                    Initialization.screen.PrintInputError();
                }

                // 7자리 정수면 막기
                else if (check.Length > 6)
                {
                    Initialization.screen.PrintGetModifingBookPrice();
                }

                Console.SetCursorPosition(14, 6);
                check = Console.ReadLine();
            }

            Console.SetCursorPosition(0, 6);
            Console.Write(new String(' ', 1000));
            Console.SetCursorPosition(0, 5);

            return check;
        }

        // 도서 제목 등록 예외처리 
        public string HandleGetBookTitle(string check, BookData bookData)
        {
            Regex regex = new Regex(@"^[가-힣a-zA-Z0-9]");

            while (!regex.IsMatch(check) || check == null || bookData.IsBookTitleDuplication(check))
            {
                Console.SetCursorPosition(0, 7);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, 4);
                Initialization.screen.PrintGetBookTitle();
                Console.SetCursorPosition(0, 9);

                if (!regex.IsMatch(check) || check == null)
                {
                    Initialization.screen.PrintInputError();
                }


                // 도서 중복막기
                else if (bookData.IsBookTitleDuplication(check))
                {
                    Initialization.screen.PrintTitleDuplicationError();
                }
                Console.SetCursorPosition(13, 8);
                check = Console.ReadLine();
            }
            Console.SetCursorPosition(0, 9);
            Console.Write(new String(' ', 1000));
            Console.SetCursorPosition(0, 8);

            return check;
        }

        public string HandleGetTitle(string check)
        {
            Regex regex = new Regex(@"^[가-힣a-zA-Z0-9]");

            while (!regex.IsMatch(check) || check == null)
            {
                Console.SetCursorPosition(0, 0);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, 0);
                Initialization.screen.PrintGetBookTitle();
                Console.SetCursorPosition(0, 2);
                Initialization.screen.PrintInputError();
                Console.SetCursorPosition(13, 4);
                check = Console.ReadLine();
            }

            Console.SetCursorPosition(0, 9);
            Console.Write(new String(' ', 1000));
            Console.SetCursorPosition(0, 8);

            return check;
        }

        // 도서 출판사 예외처리 
        public string HandleGetPublisher(string check)
        {
            Regex regex = new Regex(@"^[가-힣a-zA-Z]");

            while (!regex.IsMatch(check) || check == null)
            {
                Console.SetCursorPosition(0, 11);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, 8);
                Initialization.screen.PrintGetBookPublisher();
                Console.SetCursorPosition(0, 13);
                Initialization.screen.PrintInputError();
                Console.SetCursorPosition(11, 12);
                check = Console.ReadLine();
            }

            Console.SetCursorPosition(0, 13);
            Console.Write(new String(' ', 1000));
            Console.SetCursorPosition(0, 12);

            return check;
        }

        public string HandleGetPublisherInInquiry(string check)
        {
            Regex regex = new Regex(@"^[가-힣a-zA-Z]");

            while (!regex.IsMatch(check) || check == null)
            {
                Console.SetCursorPosition(0, 4);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, 1);
                Initialization.screen.PrintGetBookPublisher();
                Console.SetCursorPosition(0, 4);
                Initialization.screen.PrintInputError();
                Console.SetCursorPosition(11, 5);
                check = Console.ReadLine();
            }

            return check;
        }

        // 도서 저자 예외처리 
        public string HandleGetBookAuthor(string check)
        {
            Regex regex = new Regex(@"^[가-힣a-zA-Z]");

            while (!regex.IsMatch(check) || check == null)
            {
                Console.SetCursorPosition(0, 15);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, 12);
                Initialization.screen.PrintGetBookAuthor();
                Console.SetCursorPosition(0, 17);
                Initialization.screen.PrintInputError();
                Console.SetCursorPosition(13, 16);
                check = Console.ReadLine();
            }

            Console.SetCursorPosition(0, 17);
            Console.Write(new String(' ', 1000));
            Console.SetCursorPosition(0, 16);

            return check;
        }

        public string HandleGetAuthorInInquiry(string check)
        {
            Regex regex = new Regex(@"^[가-힣a-zA-Z]");

            while (!regex.IsMatch(check) || check == null)
            {
                Console.SetCursorPosition(0, 4);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, 1);
                Initialization.screen.PrintGetBookAuthor();
                Console.SetCursorPosition(0, 4);
                Initialization.screen.PrintInputError();
                Console.SetCursorPosition(11, 5);
                check = Console.ReadLine();
            }

            return check;
        }


        // 도서 가격 예외처리 
        public string HandleGetBookPrice(string check)
        {
            Regex regex = new Regex(@"^[0-9]");

            while (!regex.IsMatch(check) || check == null || check.Length > 6)
            {
                Console.SetCursorPosition(0, 19);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, 16);
                Initialization.screen.PrintGetBookPrice();
                Console.SetCursorPosition(0, 21);

                if (!regex.IsMatch(check) || check == null)
                {
                    Initialization.screen.PrintInputError();
                }

                // 7자리 정수면 막기
                else if (check.Length > 6)
                {
                    Initialization.screen.PrintBookPriceError();
                }

                Console.SetCursorPosition(14, 20);
                check = Console.ReadLine();
            }

            Console.SetCursorPosition(0, 21);
            Console.Write(new String(' ', 1000));
            Console.SetCursorPosition(0, 20);

            return check;
        }

        // 도서 수량 예외처리 
        public string HandleGetBookCount(string check)
        {
            Regex regex = new Regex(@"^[0-9]");

            while (!regex.IsMatch(check) || check == null || check.Length > 2)
            {
                Console.SetCursorPosition(0, 23);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, 20);
                Initialization.screen.PrintGetBookPrice();
                Console.SetCursorPosition(0, 25);

                if (!regex.IsMatch(check) || check == null)
                {
                    Initialization.screen.PrintInputError();
                }

                else if (check.Length > 3)
                {
                    Initialization.screen.PrintBookCountError();
                }

                Console.SetCursorPosition(13, 24);
                check = Console.ReadLine();
            }

            Console.SetCursorPosition(0, 25);
            Console.Write(new String(' ', 1000));
            Console.SetCursorPosition(0, 24);

            return check;
        }

        public string HandleGetBookCountInModification(string check)
        {
            Regex regex = new Regex(@"^[0-9]");

            while ((!regex.IsMatch(check) || check == null || check.Length > 2) && check != "q")
            {
                Console.SetCursorPosition(0, 3);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, 1);
                Initialization.screen.PrintGetModifingBookCount();
                Console.SetCursorPosition(0, 7);

                if (!regex.IsMatch(check) || check == null)
                {
                    Initialization.screen.PrintInputError();
                }

                else if (check.Length > 3)
                {
                    Initialization.screen.PrintBookCountError();
                }

                Console.SetCursorPosition(13, 6);
                check = Console.ReadLine();
            }

            Console.SetCursorPosition(0, 6);
            Console.Write(new String(' ', 1000));
            Console.SetCursorPosition(0, 5);

            return check;
        }

        /// <summary>
        /// 메뉴 예외 처리
        /// </summary>
        /// <param name="check"></param>
        /// <returns></returns>
        public string HandleGetFourMenu(string check)
        {
            Regex regex = new Regex("^[1-4]$");
            while (!regex.IsMatch(check))
            {
                Console.SetCursorPosition(0, 23);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, 21);
                Initialization.screen.PrintInput();
                Console.SetCursorPosition(0, 22);
                Initialization.screen.PrintMenuInputError();
                Console.SetCursorPosition(27, 23);
                check = Console.ReadLine();
            }

            return check;
        }

        public string HandleGetThreeMenu(string check)
        {
            Regex regex = new Regex("^[1-3]$");
            while (!regex.IsMatch(check))
            {
                Console.SetCursorPosition(0, 19);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, 18);
                Initialization.screen.PrintInput();
                Console.SetCursorPosition(0, 19);
                Initialization.screen.PrintMenuInputError();
                Console.SetCursorPosition(27, 20);
                check = Console.ReadLine();
            }

            return check;
        }

        public string HandleGetFiveMenu(string check)
        {
            Regex regex = new Regex("^[1-5]$");
            while (!regex.IsMatch(check))
            {
                Console.SetCursorPosition(0, 25);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, 24);
                Initialization.screen.PrintInput();
                Console.SetCursorPosition(0, 25);
                Initialization.screen.PrintMenuInputError();
                Console.SetCursorPosition(27, 26);
                check = Console.ReadLine();
            }

            return check;
        }

        public string HandleManagerMenuInput(string check)
        {
            Regex regex = new Regex("^[1-8]$");

            while (!regex.IsMatch(check))
            {
                Console.SetCursorPosition(0, 35);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, 33);
                Initialization.screen.PrintInput();
                Console.SetCursorPosition(0, 34);
                Initialization.screen.PrintMenuInputError();
                Console.SetCursorPosition(27, 35);
                check = Console.ReadLine();
            }

            return check;
        }

        public int FindHangle(string str)
        {
            int length;
            string str2;
            string english;

            length = str.Length;

            str2 = Regex.Replace(str, @"\s", "");
            english = Regex.Replace(str, @"[^a-zA-Z0-9\.]", "");

            return length - str2.Length + english.Length;
        }
    }
}
