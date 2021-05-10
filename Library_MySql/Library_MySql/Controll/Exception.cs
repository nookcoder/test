using System;
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

        // 수정 도서 번호 예외 처리 
        public string HandleGetIdInDelete(string check)
        {
            Regex regex = new Regex(@"^[0-9a-zA-Z]");
            while (!regex.IsMatch(check) && check != "q")
            {
                Console.SetCursorPosition(0, 3);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, 1);
                Initialization.screen.PrintGetDeleteId();
                Console.SetCursorPosition(0, 7);
                Initialization.screen.PrintInputError();

                Console.SetCursorPosition(11, 6);
                check = Console.ReadLine();
            }

            return check;
        }

        // 회원 수정시 아이디 예외처리
        public string HandleGetIdInModifing(string check)
        {
            Regex regex = new Regex(@"^[0-9a-zA-Z]");

            // 숫자 영어 로만 이루어진 아이디인지 확인
            while ((!regex.IsMatch(check) || check?.Length == 0) && check != "q")
            {
                Console.SetCursorPosition(0, 3);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, 1);
                Initialization.screen.PrintGetModifingMemberId();
                Console.SetCursorPosition(0, 7);

                if (!regex.IsMatch(check) || check?.Length == 0)
                {
                    Initialization.screen.PrintInputError();
                }

                Console.SetCursorPosition(11, 6);
                check = Console.ReadLine();
            }

            return check;
        }

        public string HandleGetIdForSearch(string check)
        {
            Regex regex = new Regex(@"^[0-9a-zA-Z]");
            int positionY = Console.GetCursorPosition().Top;

            // 숫자 영어 로만 이루어진 아이디인지 확인
            while ((!regex.IsMatch(check) || check?.Length == 0) && check != "q")
            {
                Console.SetCursorPosition(0, positionY - 1);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, positionY - 4);
                Initialization.screen.PrintGetIdForSearch();
                Console.SetCursorPosition(0, positionY);

                if (!regex.IsMatch(check) || check?.Length == 0)
                {
                    Initialization.screen.PrintInputError();
                }

                Console.SetCursorPosition(24, positionY - 1);
                check = Console.ReadLine();
            }

            return check;
        }

        public string HandleGetIdInLogin(string check)
        {
            Regex regex = new Regex(@"^[0-9a-zA-Z]");

            // 숫자 영어 로만 이루어진 아이디인지 확인
            while ((!regex.IsMatch(check) || check?.Length == 0) && check != "q")
            {
                Console.SetCursorPosition(0, 3);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, 1);
                Initialization.screen.PrintGetLoginId();
                Console.SetCursorPosition(0, 6);

                if (!regex.IsMatch(check) || check?.Length == 0)
                {
                    Initialization.screen.PrintInputError();
                }

                Console.SetCursorPosition(24, 5);
                check = Console.ReadLine();
            }

            return check;
        }

        // 비밀번호 예외처리 
        public string HandleGetPassword(string check)
        {
            Regex regex = new Regex(@"^[0-9a-zA-Z]");
            int positionY = Console.GetCursorPosition().Top;

            while (!regex.IsMatch(check) || check == null&& check !="q")
            {
                Console.SetCursorPosition(0, positionY);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, positionY-5);
                Initialization.screen.PrintGetPassword();
                Console.SetCursorPosition(0, positionY);
                Initialization.screen.PrintInputError();
                Console.SetCursorPosition(27, positionY-1);
                check = Console.ReadLine();
            }
            Console.SetCursorPosition(0, positionY);
            Console.Write(new String(' ', 1000));
            Console.SetCursorPosition(0, positionY);

            return check;
        }

        public string HandleGetPasswordInLogin(string check)
        {
            Regex regex = new Regex(@"^[0-9a-zA-Z]");

            while (!regex.IsMatch(check) || check == null)
            {
                Console.SetCursorPosition(0, 7);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, 6);
                Initialization.screen.PrintGetPassword();
                Console.SetCursorPosition(0, 11);
                Initialization.screen.PrintInputError();
                Console.SetCursorPosition(27, 10);
                check = Console.ReadLine();
            }

            return check;
        }


        // 이름 조회 예외처리 
        public string HandleGetName(string check)
        {
            Regex regex = new Regex(@"^[가-힣a-zA-Z]{2,}$");
            int positionY = Console.GetCursorPosition().Top;
            while (!regex.IsMatch(check) || check == null)
            {
                Console.SetCursorPosition(0, positionY -1);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, positionY - 5);
                Initialization.screen.PrintGetName();
                Console.SetCursorPosition(0, positionY);
                Initialization.screen.PrintInputError();
                Console.SetCursorPosition(9, positionY - 1);
                check = Console.ReadLine();
            }
            Console.SetCursorPosition(0, positionY);
            Console.Write(new String(' ', 1000));
            Console.SetCursorPosition(0, positionY - 1);

            return check;
        }

        public string HandleGetNameInInquiry(string check)
        {
            Regex regex = new Regex(@"^[가-힣a-zA-Z]");

            while ((!regex.IsMatch(check) || check == null) && check != "q")
            {
                Console.SetCursorPosition(0, 3);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, 1);
                Initialization.screen.PrintGetInquiringName();
                Console.SetCursorPosition(0, 7);
                Initialization.screen.PrintInputError();
                Console.SetCursorPosition(8, 6);
                check = Console.ReadLine();
            }

            return check;
        }

        public string HandleGetAgeInInquiry(string check)
        {
            Regex regex = new Regex(@"^[0-9]");

            while ((!regex.IsMatch(check) || check == null) && check != "q")
            {
                Console.SetCursorPosition(0, 3);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, 1);
                Initialization.screen.PrintGetInquiringAge();
                Console.SetCursorPosition(0, 7);
                if (!regex.IsMatch(check))
                {
                    Initialization.screen.PrintInputError();
                }

                else if (check == "0" || Convert.ToInt32(check) >= 150)
                {
                    Initialization.screen.PrintAgeError();
                }

                Console.SetCursorPosition(8, 6);
                check = Console.ReadLine();
            }

            return check;
        }

        public string HandleGetAddressInInquiry(string check)
        {
            Regex regex = new Regex(@"([가-힣]+)시 ([가-힣0-9]+)대로");
            Regex regex1 = new Regex(@"([가-힣]+)시 ([가-힣0-9]+)로");
            Regex regex2 = new Regex(@"([가-힣]+)시 ([가-힣0-9]+)길");

            while (!regex.IsMatch(check) && !regex1.IsMatch(check) && !regex2.IsMatch(check) && check != "q")
            {
                Console.SetCursorPosition(0, 3);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, 1);
                Initialization.screen.PrintGetInquiringAddress();
                Console.SetCursorPosition(0, 7);
                Initialization.screen.PrintInputError();
                Console.SetCursorPosition(28, 6);
                check = Console.ReadLine();
            }

            return check;
        }

        // 전화번호 예외처리 (중복 방지) 
        public string HandleGetPhoneNumber(string check, MemberData memberData)
        {
            int positionY = Console.GetCursorPosition().Top;
            Regex regex = new Regex(@"^(010)(\d{4})(\d{4})$");
            Regex regex1 = new Regex(@"^(011)(\d{4})(\d{4})$");
            while ((!regex.IsMatch(check) && !regex1.IsMatch(check)) || memberData.IsMemberPhoneNumberDuplication(check))
            {
                Console.SetCursorPosition(0, positionY-1);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, positionY-5);
                Initialization.screen.PrintGetPhoneNumber();
                Console.SetCursorPosition(0, positionY);

                if (!regex.IsMatch(check) || !regex1.IsMatch(check))
                {
                    Initialization.screen.PrintInputError();
                }

                else if (memberData.IsMemberPhoneNumberDuplication(check))
                {
                    Initialization.screen.PrintPhoneNumberDuplicationError();
                }

                Console.SetCursorPosition(23, positionY-1);
                check = Console.ReadLine();
            }
            Console.SetCursorPosition(0, positionY);
            Console.Write(new String(' ', 1000));
            Console.SetCursorPosition(0, positionY);

            return check;
        }

        // 회원 전화번호 수정 예외처리 
        public string HandleGetPhoneNumberInModification(string check, MemberData memberData)
        {
            Regex regex = new Regex(@"^(010)(\d{4})(\d{4})$");
            Regex regex1 = new Regex(@"^(011)(\d{4})(\d{4})$");
            while (((!regex.IsMatch(check) && !regex1.IsMatch(check)) || memberData.IsMemberPhoneNumberDuplication(check)) && check != "q")
            {
                Console.SetCursorPosition(0, 4);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, 2);
                Initialization.screen.PrintGetPhoneNumber();
                Console.SetCursorPosition(0, 7);

                if (memberData.IsMemberPhoneNumberDuplication(check))
                {
                    Initialization.screen.PrintPhoneNumberDuplicationError();
                }

                else if (!regex.IsMatch(check) || !regex1.IsMatch(check))
                {
                    Initialization.screen.PrintInputError();
                }


                Console.SetCursorPosition(23, 6);
                check = Console.ReadLine();
            }

            return check;
        }

        // 회원 전화번호 수정 예외처리 
        public string HandleGetPhoneNumberInModificationBySelf(string check, MemberData memberData)
        {
            int positionY = Console.GetCursorPosition().Top;
            Regex regex = new Regex(@"^(010)(\d{4})(\d{4})$");
            Regex regex1 = new Regex(@"^(011)(\d{4})(\d{4})$");
            while (((!regex.IsMatch(check) && !regex1.IsMatch(check)) || memberData.IsMemberPhoneNumberDuplication(check)) && check != "q")
            {
                Console.SetCursorPosition(0, positionY - 1);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, positionY - 5);
                Initialization.screen.PrintGetPhoneNumber();
                Console.SetCursorPosition(0, positionY);

                if (memberData.IsMemberPhoneNumberDuplication(check))
                {
                    Initialization.screen.PrintPhoneNumberDuplicationError();
                }

                else if (!regex.IsMatch(check) || !regex1.IsMatch(check))
                {
                    Initialization.screen.PrintInputError();
                }


                Console.SetCursorPosition(23, positionY - 1);
                check = Console.ReadLine();
            }

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

        public string HandleGetAddressInModification(string check)
        {
            Regex regex = new Regex(@"([가-힣]+)시 ([가-힣0-9]+)대로");
            Regex regex1 = new Regex(@"([가-힣]+)시 ([가-힣0-9]+)로");
            Regex regex2 = new Regex(@"([가-힣]+)시 ([가-힣0-9]+)길");
            while ((!regex.IsMatch(check) && !regex1.IsMatch(check) && !regex2.IsMatch(check)) && check != "q")
            {
                Console.SetCursorPosition(0, 3);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, 1);
                Initialization.screen.PrintGetModifingAddress();
                Console.SetCursorPosition(0, 7);
                Initialization.screen.PrintInputError();
                Console.SetCursorPosition(28, 6);
                check = Console.ReadLine();
            }

            return check;
        }

        public string HandleGetAddressInModificationBySelf(string check)
        {
            int positionY = Console.GetCursorPosition().Top;
            Regex regex = new Regex(@"([가-힣]+)시 ([가-힣0-9]+)대로");
            Regex regex1 = new Regex(@"([가-힣]+)시 ([가-힣0-9]+)로");
            Regex regex2 = new Regex(@"([가-힣]+)시 ([가-힣0-9]+)길");
            while ((!regex.IsMatch(check) && !regex1.IsMatch(check) && !regex2.IsMatch(check)) && check != "q")
            {
                Console.SetCursorPosition(0, positionY - 3);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, positionY - 6);
                Initialization.screen.PrintGetModifingAddress();
                Console.SetCursorPosition(0, positionY);
                Initialization.screen.PrintInputError();
                Console.SetCursorPosition(28, positionY - 1);
                check = Console.ReadLine();
            }

            return check;
        }

        // 회원 나이 예외처리 
        public string HandleGetAge(string check)
        {
            Regex regex = new Regex(@"^[0-9]{1,3}$");
            while (!regex.IsMatch(check) || check == "0" || Convert.ToInt32(check) >= 150)
            {
                Console.SetCursorPosition(0, 23);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, 20);
                Initialization.screen.PrintGetAge();
                Console.SetCursorPosition(0, 25);

                if (!regex.IsMatch(check))
                {
                    Initialization.screen.PrintInputError();
                }

                else if (check == "0" || Convert.ToInt32(check) >= 150)
                {
                    Initialization.screen.PrintAgeError();
                }

                Console.SetCursorPosition(9, 24);
                check = Console.ReadLine();
            }
            Console.SetCursorPosition(0, 26);
            Console.Write(new String(' ', 1000));
            Console.SetCursorPosition(0, 25);

            return check;
        }

        /// <summary>
        /// 도서 예외처리
        /// </summary>

        // 도서 번호 예외처리 
        public string HandleGetBookUd(string check, BookData bookData)
        {
            Regex regex = new Regex(@"^[0-9]{1,7}$");
            int positionY = Console.GetCursorPosition().Top;
            while (!regex.IsMatch(check) || bookData.IsBookIdDuplication(check) && check != "q")
            {
                Console.SetCursorPosition(0, positionY - 1);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, positionY - 5);
                Initialization.screen.PrintGetBookId();
                Console.SetCursorPosition(0, positionY + 1);

                if (!regex.IsMatch(check))
                {
                    Initialization.screen.PrintInputError();
                }

                // 도서 중복막기
                else if (bookData.IsBookIdDuplication(check))
                {
                    Initialization.screen.PrintBookIdDuplicationError();
                }

                Console.SetCursorPosition(14, positionY - 1);
                check = Console.ReadLine();
            }
            Console.SetCursorPosition(0, positionY + 1);
            Console.Write(new String(' ', 1000));
            Console.SetCursorPosition(0, positionY);

            return check;
        }

        public string HandleGetBookUdInBorrowing(string check)
        {
            int positionY = Console.GetCursorPosition().Top;
            int positionX = Console.GetCursorPosition().Left;
            Regex regex = new Regex(@"^[0-9]{1,7}$");
            while (!regex.IsMatch(check))
            {
                Console.SetCursorPosition(0, positionY - 2);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, positionY - 3);
                Initialization.screen.PrintGetBorrowBookNumber();
                Console.SetCursorPosition(0, positionY);
                Initialization.screen.PrintInputError();
                Console.SetCursorPosition(35, positionY - 1);
                check = Console.ReadLine();
            }

            return check;
        }

        // 수정 도서 번호 예외 처리 
        public string HandleGetBookIdInModification(string check)
        {
            Regex regex = new Regex(@"^[0-9]{1,7}$");
            int positionY = Console.GetCursorPosition().Top;
            while (!regex.IsMatch(check) && check != "q")
            {
                Console.SetCursorPosition(0, positionY - 1);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, positionY - 5);
                Initialization.screen.PrintGetBookId();
                Console.SetCursorPosition(0, positionY + 1);
                Initialization.screen.PrintInputError();

                Console.SetCursorPosition(14, positionY - 1);
                check = Console.ReadLine();
            }
            Console.SetCursorPosition(0, positionY);
            Console.Write(new String(' ', 1000));
            Console.SetCursorPosition(0, positionY - 1);

            return check;
        }

        public string HandleGetBookIdInBorrowing(string check)
        {
            Regex regex = new Regex(@"^[0-9]{1,7}$");
            int positionY = Console.GetCursorPosition().Top;
            while (!regex.IsMatch(check) && check != "q")
            {
                Console.SetCursorPosition(0, positionY - 1);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, positionY - 1);
                Initialization.screen.PrintGetBorrowBookNumber();
                Console.SetCursorPosition(0, positionY);
                Initialization.screen.PrintInputError();

                Console.SetCursorPosition(35, positionY - 1);
                check = Console.ReadLine();
            }
            Console.SetCursorPosition(0, positionY);
            Console.Write(new String(' ', 1000));
            Console.SetCursorPosition(0, positionY - 1);

            return check;
        }


        // 도서 가격 수정 예외처리 
        public string HandleGetBookPriceInModification(string check)
        {
            Regex regex = new Regex(@"^(0-9{1,})(00)$");
            int positionY = Console.GetCursorPosition().Top;
            while ((!regex.IsMatch(check) || check == null || check.Length > 6) && check != "q")
            {
                Console.SetCursorPosition(0, positionY - 1);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, positionY - 5);
                Initialization.screen.PrintGetBookPrice();
                Console.SetCursorPosition(0, positionY + 1);

                if (!regex.IsMatch(check) || check == null)
                {
                    Initialization.screen.PrintInputError();
                }

                // 7자리 정수면 막기
                else if (check.Length > 6)
                {
                    Initialization.screen.PrintGetModifingBookPrice();
                }

                Console.SetCursorPosition(14, positionY - 1);
                check = Console.ReadLine();
            }

            Console.SetCursorPosition(0, positionY);
            Console.Write(new String(' ', 1000));
            Console.SetCursorPosition(0, positionY - 1);

            return check;
        }

        // 도서 제목 등록 예외처리 
        public string HandleGetBookTitle(string check, BookData bookData)
        {
            Regex regex = new Regex(@"^[가-힣a-zA-Z0-9]");
            int positionX = Console.GetCursorPosition().Left;
            int positionY = Console.GetCursorPosition().Top;

            while (!regex.IsMatch(check) || check == null || bookData.IsBookTitleDuplication(check) && check != "q")
            {
                Console.SetCursorPosition(0, positionY - 1);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, positionY - 5);
                Initialization.screen.PrintGetBookTitle();
                Console.SetCursorPosition(0, positionY + 1);

                if (!regex.IsMatch(check) || check == null)
                {
                    Initialization.screen.PrintInputError();
                }


                // 도서 중복막기
                else if (bookData.IsBookTitleDuplication(check))
                {
                    Initialization.screen.PrintTitleDuplicationError();
                }
                Console.SetCursorPosition(13, positionY - 1);
                check = Console.ReadLine();
            }
            Console.SetCursorPosition(0, positionY);
            Console.Write(new String(' ', 1000));
            Console.SetCursorPosition(0, positionY - 1);

            return check;
        }

        // 도서 제목 예외처리
        public string HandleGetTitle(string check)
        {
            Regex regex = new Regex(@"^[가-힣a-zA-Z0-9]");
            int positionY = Console.GetCursorPosition().Top;
            while (!regex.IsMatch(check) || check == null && check != "q")
            {
                Console.SetCursorPosition(0, positionY - 1);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, positionY - 5);
                Initialization.screen.PrintGetBookTitle();
                Console.SetCursorPosition(0, positionY + 1);
                Initialization.screen.PrintInputError();
                Console.SetCursorPosition(13, positionY - 1);
                check = Console.ReadLine();
            }

            Console.SetCursorPosition(0, positionY);
            Console.Write(new String(' ', 1000));
            Console.SetCursorPosition(0, positionY - 1);

            return check;
        }

        // 도서 출판사 예외처리 
        public string HandleGetPublisher(string check)
        {
            Regex regex = new Regex(@"^[가-힣a-zA-Z]");
            int positionY = Console.GetCursorPosition().Top;
            while (!regex.IsMatch(check) || check == null)
            {
                Console.SetCursorPosition(0, positionY - 1);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, positionY - 5);
                Initialization.screen.PrintGetBookPublisher();
                Console.SetCursorPosition(0, positionY + 1);
                Initialization.screen.PrintInputError();
                Console.SetCursorPosition(11, positionY - 1);
                check = Console.ReadLine();
            }

            Console.SetCursorPosition(0, positionY);
            Console.Write(new String(' ', 1000));
            Console.SetCursorPosition(0, positionY - 1);

            return check;
        }

        // 도서 출판사 조회 예외처리
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
            int positionY = Console.GetCursorPosition().Top;
            while (!regex.IsMatch(check) || check == null)
            {
                Console.SetCursorPosition(0, positionY - 1);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, positionY - 5);
                Initialization.screen.PrintGetBookAuthor();
                Console.SetCursorPosition(0, positionY + 1);
                Initialization.screen.PrintInputError();
                Console.SetCursorPosition(13, positionY - 1);
                check = Console.ReadLine();
            }

            Console.SetCursorPosition(0, positionY);
            Console.Write(new String(' ', 1000));
            Console.SetCursorPosition(0, positionY - 1);

            return check;
        }

        // 도서 저자 조회 예외처리 
        public string HandleGetAuthorInInquiry(string check)
        {
            Regex regex = new Regex(@"^[가-힣a-zA-Z]");
            int positionY = Console.GetCursorPosition().Top;
            while (!regex.IsMatch(check) || check == null)
            {
                Console.SetCursorPosition(0, positionY - 1);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, positionY - 5);
                Initialization.screen.PrintGetBookAuthor();
                Console.SetCursorPosition(0, positionY + 1);
                Initialization.screen.PrintInputError();
                Console.SetCursorPosition(11, positionY - 1);
                check = Console.ReadLine();
            }

            return check;
        }

        // 도서 가격 예외처리 
        public string HandleGetBookPrice(string check)
        {
            Regex regex = new Regex(@"^(\d{1,})(0)$");
            int positionY = Console.GetCursorPosition().Top;
            while (!regex.IsMatch(check) || check == null || check.Length > 6)
            {
                Console.SetCursorPosition(0, positionY - 1);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, positionY - 5);
                Initialization.screen.PrintGetBookPrice();
                Console.SetCursorPosition(0, positionY + 1);

                if (!regex.IsMatch(check) || check == null)
                {
                    Initialization.screen.PrintInputError();
                }

                // 7자리 정수면 막기
                else if (check.Length > 6)
                {
                    Initialization.screen.PrintBookPriceError();
                }

                Console.SetCursorPosition(14, positionY - 1);
                check = Console.ReadLine();
            }

            Console.SetCursorPosition(0, positionY);
            Console.Write(new String(' ', 1000));
            Console.SetCursorPosition(0, positionY - 1);

            return check;
        }

        // 도서 수량 예외처리 
        public string HandleGetBookCount(string check)
        {
            Regex regex = new Regex(@"^[0-9]");
            int positionY = Console.GetCursorPosition().Top;
            while (!regex.IsMatch(check) || check == null || check.Length > 2)
            {
                Console.SetCursorPosition(0, positionY - 1);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, positionY - 5);
                Initialization.screen.PrintGetBookCount();
                Console.SetCursorPosition(0, positionY + 1);

                if (!regex.IsMatch(check) || check == null)
                {
                    Initialization.screen.PrintInputError();
                }

                else if (check.Length > 3)
                {
                    Initialization.screen.PrintBookCountError();
                }

                Console.SetCursorPosition(13, positionY - 1);
                check = Console.ReadLine();
            }

            Console.SetCursorPosition(0, positionY);
            Console.Write(new String(' ', 1000));
            Console.SetCursorPosition(0, positionY - 1);

            return check;
        }

        public string HandleGetShowBookCount(string check)
        {
            Regex regex = new Regex(@"^[0-9]");
            int positionY = Console.GetCursorPosition().Top;
            while (!regex.IsMatch(check) || check == null || int.Parse(check) <= 0 || int.Parse(check) > 10 && check != "q")
            {
                Console.SetCursorPosition(0, positionY - 2);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, positionY - 3);
                Initialization.screen.PrintGetCountForShow();
                Console.SetCursorPosition(0, positionY);

                if (!regex.IsMatch(check) || check == null)
                {
                    Initialization.screen.PrintInputError();
                }

                else if (check.Length > 3)
                {
                    Initialization.screen.PrintBookCountError();
                }

                Console.SetCursorPosition(33, positionY - 1);
                check = Console.ReadLine();
            }

            Console.SetCursorPosition(0, positionY);
            Console.Write(new String(' ', 1000));
            Console.SetCursorPosition(0, positionY - 1);

            return check;
        }


        // 도서 수량 수정 예외처리 
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

                else if (check.Length >= 3)
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

        // 도서 출력 갯수 예외처리 
        public string HandleGetCountForShow(string check)
        {
            Regex regex = new Regex(@"^[0-9]{1,2}$");
            int positionY = Console.GetCursorPosition().Top;

            while (!regex.IsMatch(check) || int.Parse(check) > 10 || int.Parse(check) == 0 && check != "q")
            {
                Console.SetCursorPosition(0, positionY - 1);
                Console.WriteLine(new String(' ', 1000));
                Console.SetCursorPosition(0, positionY - 3);
                Initialization.screen.PrintGetCountForShow();
                Console.SetCursorPosition(0, positionY);
                Initialization.screen.PrintInputError();
                Console.SetCursorPosition(34, positionY - 1);
                check = Console.ReadLine();
            }

            return check;
        }

        // 도서 제목 예외처리
        public string HandleGetTitleForShow(string check)
        {
            Regex regex = new Regex(@"^[가-힣a-zA-Z0-9]");
            int positionY = Console.GetCursorPosition().Top;
            while (!regex.IsMatch(check) || check == null && check != "q")
            {
                Console.SetCursorPosition(0, positionY - 1);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, positionY - 3);
                Initialization.screen.PrintGetTitleForShow();
                Console.SetCursorPosition(0, positionY);
                Initialization.screen.PrintInputError();
                Console.SetCursorPosition(25, positionY - 1);
                check = Console.ReadLine();
            }
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
        public string HandleGetSixMenu(string check)
        {
            int positionX;
            int positionY;

            positionY = Console.GetCursorPosition().Top;
            positionX = Console.GetCursorPosition().Left;

            Regex regex = new Regex("^[1-6]$");
            while (!regex.IsMatch(check))
            {
                Console.SetCursorPosition(0, positionY - 1);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, positionY - 3);
                Initialization.screen.PrintInput();
                Console.SetCursorPosition(0, positionY);
                Initialization.screen.PrintMenuInputError();
                Console.SetCursorPosition(27, positionY - 1);
                check = Console.ReadLine();
            }

            return check;
        }

        public string HandleManagerMenuInput(string check)
        {
            Regex regex = new Regex("^[1-9]$");

            while (!regex.IsMatch(check))
            {
                Console.SetCursorPosition(0, 38);
                Console.Write(new String(' ', 1000));
                Console.SetCursorPosition(0, 36);
                Initialization.screen.PrintInput();
                Console.SetCursorPosition(0, 37);
                Initialization.screen.PrintMenuInputError();
                Console.SetCursorPosition(27, 38);
                check = Console.ReadLine();
            }

            return check;
        }

        public string HandleGetTwoMenu(string check)
        {
            int positionY = Console.GetCursorPosition().Top;
            Regex regex = new Regex("^[1-2]$");

            while (!regex.IsMatch(check) && check != "q")
            {
                Console.SetCursorPosition(0, positionY - 1);
                Console.Write(new String(' ', 100));
                Console.SetCursorPosition(0, positionY - 3);
                Initialization.screen.PrintInput();
                Console.SetCursorPosition(0, positionY + 1);
                Initialization.screen.PrintMenuInputError();
                Console.SetCursorPosition(26, positionY);
                check = Console.ReadLine();
            }

            return check;
        }

        public string HandleGetDecision(string check)
        {
            int positionY = Console.GetCursorPosition().Top;

            while (check != "1" && check != "q")
            {
                Console.SetCursorPosition(0, positionY - 1);
                Console.Write(new String(' ', 100));
                Console.SetCursorPosition(0, positionY - 2);
                Initialization.screen.PrintGetDecision();
                Console.SetCursorPosition(0, positionY);
                Initialization.screen.PrintInputError();
                Console.SetCursorPosition(9, positionY - 1);
                check = Console.ReadLine();
            }

            return check;
        }
    }
}
