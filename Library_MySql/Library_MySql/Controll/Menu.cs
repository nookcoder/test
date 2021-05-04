using Library_MySql.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_MySql.Controll
{
    class Menu
    {
        private Registration registration;
        private Inquiry inquiry;
        private Modification modification;
        private Elimination elimination;
        private BookData bookdata;
        private MemberData memberData;

        public Menu()
        {
            Console.SetWindowSize(60, 45);
            this.registration = new Registration();
            this.inquiry = new Inquiry();
            this.modification = new Modification();
            this.bookdata = new BookData();
            this.elimination = new Elimination();
            this.memberData = new MemberData();
            //RunMenu(registration);
            RunManagerMenu();
        }

        /// <summary>
        /// 프로그램 시작 시 메뉴 화면 
        /// </summary>
        /// <param name="registration"></param>
        public void RunMenu(Registration registration)
        {
            int menu;

            Console.Clear();
            Initialization.screen.PrintLabel();
            Initialization.screen.PrintInitalMenu();
            Initialization.screen.PrintInput();
            menu = GetFourMenu();

            switch (menu)
            {
                case (int)Initialization.InitalMenu.MEMBERLOGIN:

                    break;

                case (int)Initialization.InitalMenu.JOIN:
                    registration.RunRegisterMember();
                    RunMenu(registration);
                    break;

                case (int)Initialization.InitalMenu.MANAGERLOGIN:
                    break;

                case (int)Initialization.InitalMenu.EXIT:
                    Environment.Exit(0);
                    break;
            }
        }

        // 관리자 메뉴
        public void RunManagerMenu()
        {
            int menu;

            Console.Clear();
            Initialization.screen.PrintLabel();
            Initialization.screen.PrintManagerMenu();
            Initialization.screen.PrintInput();
            menu = GetManagerMenu();

            switch (menu)
            {
                case (int)Initialization.ManagerMenu.INQUIRYMEMBER:
                    RunInquiryMemberMenu(inquiry);
                    break;

                case (int)Initialization.ManagerMenu.MODIFYMEMBER:
                    RunModifyMember(modification);
                    break;

                case (int)Initialization.ManagerMenu.ELIMINATEMEMBER:
                    break;

                case (int)Initialization.ManagerMenu.INQUIRYBOOK:
                    RunInquiryBookMenu(inquiry);
                    break;

                case (int)Initialization.ManagerMenu.REGISTERBOO:
                    registration.RunRegisterBook();
                    RunManagerMenu();
                    break;

                case (int)Initialization.ManagerMenu.MODIFYBOOK:
                    RunModifyBookMenu(modification);
                    
                    break;

                case (int)Initialization.ManagerMenu.ELIMINATEBOOK:
                    RunDeleteBookMenu(elimination);
                    break;

                case (int)Initialization.ManagerMenu.BACK:
                    RunMenu(registration);
                    break;

            }

        }

        // 회원 조회 메뉴
        public void RunInquiryMemberMenu(Inquiry inquiry)
        {
            int menu;

            Console.Clear();
            Initialization.screen.PrintLabel();
            Initialization.screen.PrintInquiryMemberMenu();
            Initialization.screen.PrintInput();
            menu = GetFourMenu();

            switch(menu)
            {
                case (int)Initialization.InquiryMemberMenu.NAME:
                    inquiry.ShowMemberByName();
                    RunInquiryMemberMenu(inquiry);
                    break;

                case (int)Initialization.InquiryMemberMenu.AGE:
                    inquiry.ShowMemberByAge();
                    RunInquiryMemberMenu(inquiry);
                    break;

                case (int)Initialization.InquiryMemberMenu.ADDRESS:
                    inquiry.ShowMemberByAddress();
                    RunInquiryMemberMenu(inquiry);
                    break;

                case (int)Initialization.InquiryMemberMenu.ALL:
                    inquiry.ShowAllMember();
                    RunInquiryMemberMenu(inquiry);
                    break;

                case (int)Initialization.InquiryMemberMenu.BACK:
                    RunManagerMenu();
                    break;

            }
        }

        // 회원 정보 수정 메뉴
        public void RunModifyMember(Modification modification)
        {
            int menu;

            Console.Clear();
            Initialization.screen.PrintLabel();
            Initialization.screen.PrintModifyMemberMenu();
            Initialization.screen.PrintInput();
            menu = GetThreeMenu();

            switch(menu)
            {
                case (int)Initialization.ModifyMember.PHONENUMBER:
                    modification.RunModifyMemberPhoneNumber(memberData);
                    RunManagerMenu(); 
                    break;

                case (int)Initialization.ModifyMember.ADDRESS:
                    modification.RunModifyMemberAddress(memberData);
                    RunManagerMenu();
                    break;

                case (int)Initialization.ModifyMember.BACK:
                    RunManagerMenu();
                    break;
            }
            modification.RunModifyMemberPhoneNumber(memberData);
            
        }

        // 도서 조회 메뉴
        public void RunInquiryBookMenu(Inquiry inquiry)
        {
            int menu;

            Console.Clear();
            Initialization.screen.PrintLabel();
            Initialization.screen.PrintSearchBookMenu();
            Initialization.screen.PrintInput();
            menu = GetFiveMenu();

            switch (menu)
            {
                case (int)Initialization.SearchBookMenu.TITLE:
                    inquiry.ShowBookyTitle();
                    RunInquiryBookMenu(inquiry);
                    break;

                case (int)Initialization.SearchBookMenu.PUBLISHER:
                    inquiry.ShowBookByPublisher();
                    RunInquiryBookMenu(inquiry);
                    break;

                case (int)Initialization.SearchBookMenu.AUTHOR:
                    inquiry.ShowBookByAuthor();
                    RunInquiryBookMenu(inquiry);
                    break;

                case (int)Initialization.SearchBookMenu.ALL:
                    inquiry.ShowAllBook();
                    RunInquiryBookMenu(inquiry);
                    break;

                case (int)Initialization.SearchBookMenu.BACK:
                    RunManagerMenu();
                    break;
            }
        }
        
        // 도서 수정 메뉴
        public void RunModifyBookMenu(Modification modification)
        {
            int menu;

            Console.Clear();
            Initialization.screen.PrintLabel();
            Initialization.screen.PrintModifyBookMenu();
            Initialization.screen.PrintInput();
            menu = GetThreeMenu();

            switch (menu)
            {
                case (int)Initialization.ModifyBookMenu.PRICE:
                    modification.RunModiftBookPrice(bookdata);
                    RunModifyBookMenu(modification);
                    break;

                case (int)Initialization.ModifyBookMenu.COUNT:
                    modification.RunModiftBookCount(bookdata);
                    RunModifyBookMenu(modification);
                    break;

                case (int)Initialization.ModifyBookMenu.BACK:
                    RunManagerMenu();
                    break;
            }
        }

        // 도서 삭제 메뉴
        public void RunDeleteBookMenu(Elimination elimination)
        {
            elimination.RunDeletBook(bookdata);
            RunManagerMenu();
        }

        public int GetThreeMenu()
        {
            string menuCheck;
            int menu = 1;

            menuCheck = Console.ReadLine();
            menu = Convert.ToInt32(Initialization.exception.HandleGetThreeMenu(menuCheck));

            return menu;
        }

        public int GetFourMenu()
        {
            string menucheck;
            int menu;

            menucheck = Console.ReadLine();
            menu = Convert.ToInt32(Initialization.exception.HandleGetFourMenu(menucheck));

            return menu;
        }

        public int GetFiveMenu()
        {

            string menucheck;
            int menu;

            menucheck = Console.ReadLine();
            menu = Convert.ToInt32(Initialization.exception.HandleGetFiveMenu(menucheck));

            return menu;
        }

        public int GetManagerMenu()
        {
            string menucheck;
            int menu;

            menucheck = Console.ReadLine();
            menu = Convert.ToInt32(Initialization.exception.HandleManagerMenuInput(menucheck));

            return menu;
        }

    }
}
