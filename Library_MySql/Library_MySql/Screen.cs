using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_MySql
{
    class Screen
    {
        private Screen() { }

        private static Screen screen = null;

        public static Screen Instance()
        {
            if (screen == null)
            {
                screen = new Screen();
            }

            return screen;
        }

        public void PrintLabel()
        {
            Console.SetWindowSize(60, 45);
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
            Console.WriteLine("■■■          ■■■■■  ■■■  ■■          ■  ■■■");
            Console.WriteLine("■■■  ■■■■■■■■■  ■■■  ■■■■■■  ■  ■■■");
            Console.WriteLine("■■■  ■■■■■■■■■  ■■■  ■■■  ■■■■  ■■■");
            Console.WriteLine("■■■          ■■■■    ■      ■■                ■■");
            Console.WriteLine("■■■■■  ■■■■■  ■  ■■■  ■■■■■■■■  ■■■");
            Console.WriteLine("■■■■■  ■■■■■  ■■  ■■  ■■■  ■■■■■■■■");
            Console.WriteLine("■■              ■■  ■■  ■■  ■■■            ■■■");
            Console.WriteLine("■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n");
        }
        public void PrintInitalMenu()
        {
            Console.WriteLine(new String(' ', 20) + "[1] 회원 접속");
            Console.WriteLine("\n");
            Console.WriteLine(new String(' ', 20) + "[2] 회원 가입");
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(new String(' ', 20) + "[3] 관리자 접속");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(new String(' ', 20) + "[4] 종료 하기");
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// 회원가입 관련 화면 
        /// </summary>
        public void PrintGetId()
        {
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("  종료 : q 입력");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("  아이디(영어,숫자만) : ");
        }

        public void PrintGetPassword()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.Write("  비밀번호(영어,숫자만) : ");
        }

        public void PrintGetName()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.Write("  이름 : ");
        }

        public void PrintGetPhoneNumber()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.Write("  전화번호('-' 제외) : ");
        }

        public void PrintGetAddress()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.Write("  주소(OO시 OO대로/로/길) : ");
        }

        public void PrintGetAge()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.Write("  나이 : ");
        }

        public void PrintIdDuplicationError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("  중복된 아이디입니다!! ");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void PrintPhoneNumberDuplicationError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("  중복된 전화번호입니다!! ");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void PrintAgeError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("  엥? ");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void PrintJoinSuccess()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("  회원 가입 성공!!");
            Console.WriteLine("  계속 진행하시려면 아무키나 눌러주세요 ");
        }

        /// <summary>
        /// 회원 정보 수정 관련 화면 
        /// </summary>
        public void PrintGetModifingMemberId()
        {
            Console.WriteLine("\n");
            Console.WriteLine("  수정하려는 회원 아이디를 입력해주세요");
            Console.WriteLine("\n");
            Console.Write("  아이디 : ");
        }

        public void PrintGetModifingPhoneNumber()
        {
            Console.WriteLine("\n");
            Console.WriteLine("  수정된 회원 전화번호를 입력해주세요");
            Console.WriteLine("\n");
            Console.Write("  전화번호('-' 제외) : ");
        }

        public void PrintGetModifingAddress()
        {
            Console.WriteLine("\n");
            Console.WriteLine("  수정된 회원 주소를 입력해주세요");
            Console.WriteLine("\n");
            Console.Write("  주소(OO시 OO대로/로/길) : ");
        }

        /// <summary>
        /// 회원 조회 화면 
        /// </summary>

        // 회원 이름 검색 
        public void PrintGetInquiringName()
        {
            Console.WriteLine("\n");
            Console.WriteLine("  검색할 회원 이름을 입력해주세요");
            Console.WriteLine("\n");
            Console.Write("  이름 : ");
        }

        // 회원 나이 검색 
        public void PrintGetInquiringAge()
        {
            Console.WriteLine("\n");
            Console.WriteLine("  검색할 회원 나이를 입력해주세요");
            Console.WriteLine("\n");
            Console.Write("  나이 : ");
        }

        public void PrintGetInquiringAddress()
        {
            Console.WriteLine("\n");
            Console.WriteLine("  검색할 회원 주소를 입력해주세요");
            Console.WriteLine("\n");
            Console.Write("  주소(OO시 OO대로/로/길) : ");
        }

        /// <summary>
        /// 도서 등록 화면 
        /// </summary>
        public void PrintGetBookId()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.Write("  도서 번호 : ");
        }

        public void PrintBookIdDuplicationError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("  중복된 도서 번호입니다!! ");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void PrintGetBookTitle()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.Write("  도서 제목: ");
        }

        public void PrintTitleDuplicationError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("  이미 있는 도서입니다!! ");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void PrintGetBookPublisher()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.Write("  출판사 : ");
        }

        public void PrintGetBookAuthor()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.Write("  도서 저자 : ");
        }

        public void PrintGetBookPrice()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.Write("  도서 가격 : ");
        }

        public void PrintBookPriceError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("  너무 비싸지 않나요..? ");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void PrintGetBookCount()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.Write("  등록 권수 : ");
        }

        public void PrintBookCountError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("  너무 많지 않나요..? ");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void PrintSuccessRegisterBook()
        {
            Console.WriteLine("\n");
            Console.WriteLine("\n");
            Console.WriteLine("  도서 등록 성공!!");
            Console.WriteLine("  계속 진행하시려면 아무키나 눌러주세요 ");
        }

        /// <summary>
        /// 관리자 화면 출력 
        /// </summary>
        public void PrintManagerMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(new String(' ', 20) + "[1] 회원 조회");
            Console.WriteLine("\n");
            Console.WriteLine(new String(' ', 20) + "[2] 회원 정보 수정");
            Console.WriteLine("\n");
            Console.WriteLine(new String(' ', 20) + "[3] 회원 삭제");
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(new String(' ', 20) + "[4] 도서 조회");
            Console.WriteLine("\n");
            Console.WriteLine(new String(' ', 20) + "[5] 도서 등록");
            Console.WriteLine("\n");
            Console.WriteLine(new String(' ', 20) + "[6] 도서 수정");
            Console.WriteLine("\n");
            Console.WriteLine(new String(' ', 20) + "[7] 도서 삭제");
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(new String(' ', 20) + "[8] 뒤로 가기");
        }

        public void PrintModifyBookMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(new String(' ', 20) + "[1] 도서 가격 수정");
            Console.WriteLine("\n");
            Console.WriteLine(new String(' ', 20) + "[2] 도서 수량 수정");
            Console.WriteLine("\n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(new String(' ', 20) + "[3] 뒤로 가기");
        }

        public void PrintSearchBookMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(new String(' ', 20) + "[1] 도서명 검색");
            Console.WriteLine("\n");
            Console.WriteLine(new String(' ', 20) + "[2] 출판사 검색");
            Console.WriteLine("\n");
            Console.WriteLine(new String(' ', 20) + "[3] 저자 검색");
            Console.WriteLine("\n");
            Console.WriteLine(new String(' ', 20) + "[4] 전체 조회"); 
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n");
            Console.WriteLine(new String(' ', 20) + "[5] 뒤로 가기");

        }

        public void PrintModifyMemberMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(new String(' ', 20) + "[1] 회원 전화번호 수정");
            Console.WriteLine("\n");
            Console.WriteLine(new String(' ', 20) + "[2] 회원 주소 수정");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n");
            Console.WriteLine(new String(' ', 20) + "[3] 뒤로 가기");
            Console.WriteLine("\n");
        }

        public void PrintInquiryMemberMenu()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(new String(' ', 20) + "[1] 회원 이름 검색");
            Console.WriteLine("\n");
            Console.WriteLine(new String(' ', 20) + "[2] 회원 나이 검색");
            Console.WriteLine("\n");
            Console.WriteLine(new String(' ', 20) + "[3] 회원 주소 검색");
            Console.WriteLine("\n");
            Console.WriteLine(new String(' ', 20) + "[4] 회원 전체 조회");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n");
            Console.WriteLine(new String(' ', 20) + "[5] 뒤로 가기");
            Console.WriteLine("\n");
        }


        // 도서 수정 관련
        public void PrintGetModifingBookId()
        {
            Console.WriteLine("\n");
            Console.WriteLine("  수정하려는 도서번호를 입력해주세요");
            Console.WriteLine("\n");
            Console.Write("  도서 번호 : ");
        }

        public void PrintGetModifingBookPrice()
        {
            Console.WriteLine("\n");
            Console.WriteLine("  수정하려는 도서 가격 입력해주세요");
            Console.WriteLine("\n");
            Console.Write("  도서 가격 : ");
        }

        public void PrintGetModifingBookCount()
        {
            Console.WriteLine("\n");
            Console.WriteLine("  수정하려는 도서 권수 입력해주세요");
            Console.WriteLine("\n");
            Console.Write("  도서 권수 : ");
        }

        // 도서 삭제 관련
        public void PrintGetDeleteBookId()
        {
            Console.WriteLine("\n");
            Console.WriteLine("  삭제하려는 도서번호를 입력해주세요");
            Console.WriteLine("\n");
            Console.Write("  도서 번호 : ");
        }

        /// <summary>
        /// 프로그램 전반적으로 쓰는 화면 
        /// </summary>
        public void PrintInputError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("  다시 입력해주세요!! ");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void PrintInput()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n");
            Console.Write(new String(' ', 20) + "입력 : ");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void PrintMenuInputError()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(new String(' ', 20) + "다시 입력해주세요!!");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void PrintBar()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(new string('=', 150));
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void PrintBookLabel()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(" NO");
            Console.Write(new String(' ', 7) + "도서 제목");
            Console.Write(new String(' ', 46) + "출판사");
            Console.Write(new String(' ', 19) + "도서 저자");
            Console.Write(new String(' ', 31) + "도서 가격");
            Console.Write(new String(' ', 3) + "권수");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n");
        }

        public void PrintMemberLabel()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(" ID");
            Console.Write(new String(' ', 16) + "이름");
            Console.Write(new String(' ', 22) + "전화 번호");
            Console.Write(new String(' ', 17) + "주소");
            Console.Write(new String(' ', 22) + "나이");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\n");
        }


        public void PrintNext()
        {
            Console.WriteLine("  계속 진행하시려면 아무키나 눌러주세요 ");
        }

        public void PrintExit()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("  종료는 q 입력하면 되요");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public void PrintNoFindBook()
        {
            Console.WriteLine("\n");
            Console.WriteLine("  해당 도서는 존재하지 않습니다.");
            Console.WriteLine("\n");
        }

        public void PrintNoFIndMember()
        {
            Console.WriteLine("\n");
            Console.WriteLine("  해당 회원은 존재하지 않습니다.");
            Console.WriteLine("\n");
        }

        public void PrintModifingNotice()
        {

            Console.WriteLine("\n");
            Console.WriteLine("  성공적으로 변경되었습니다!!.");
            Console.WriteLine("\n");
        }

        public void PrintDeletingNotice()
        {

            Console.WriteLine("\n");
            Console.WriteLine("  성공적으로 삭제되었습니다!!.");
            Console.WriteLine("\n");
        }

        public void PrintNoFindBookNOtice()
        {
            Initialization.screen.PrintNoFindBook();
            Initialization.screen.PrintNext();
            Console.ReadKey();
        }

        public void PrintNoFindMemberNOtice()
        {
            Initialization.screen.PrintNoFIndMember();
            Initialization.screen.PrintNext();
            Console.ReadKey();
        }
    }
}
