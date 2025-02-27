﻿using Library_MySql.Model;
using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_MySql.Controll
{
    class Menu
    {
        private Registration registration;
        private Search inquiry;
        private Modification modification;
        private Elimination elimination;
        private BookData bookdata;
        private MemberData memberData;
        private LogIn login;
        private Borrowing borrowing;
        private BorrowingData borrowingData;
        private Api api;

        public Menu()
        {
            Console.SetWindowSize(60, 45);
            this.registration = new Registration();
            this.inquiry = new Search();
            this.modification = new Modification();
            this.bookdata = new BookData();
            this.elimination = new Elimination();
            this.memberData = new MemberData();
            this.login = new LogIn(); ;
            this.borrowing = new Borrowing();
            this.borrowingData = new BorrowingData();
            this.api = new Api();
            RunMenu(registration);
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
            menu = GetMenu(Initialization.exception.HandleGetFourMenu);

            switch (menu)
            {
                case (int)Initialization.InitalMenu.MEMBERLOGIN:
                    RunMemberLogin(login);
                    break;

                case (int)Initialization.InitalMenu.JOIN:
                    registration.RunRegisterMember();
                    RunMenu(registration);
                    break;

                case (int)Initialization.InitalMenu.MANAGERLOGIN:
                    RunManagerLogin(login);
                    break;

                case (int)Initialization.InitalMenu.EXIT:
                    Environment.Exit(0);
                    break;
            }
        }
        
        public void RunMemberLogin(LogIn logIn)
        {
            var isSuccess = logIn.RunCheckMember(memberData); ;
            Console.Clear();
            if(isSuccess.Item1)
            {
               RunMemberMenu(isSuccess.Item2);
            }

            else
            {
                RunMenu(registration);
            }
        }

        public void RunManagerLogin(LogIn logIn)
        {
            bool isSuccess;
            isSuccess = logIn.RunCheckManager();
            if(isSuccess)
            {
                RunManagerMenu();
            }

            else
            {
                RunMenu(registration);
            }
        }

        public void RunMemberMenu(string id)
        {
            int menu;

            Console.Clear();
            Initialization.screen.PrintLabel();
            Initialization.screen.PrintMemberMenu();
            Initialization.screen.PrintInput();

            menu = GetMenu(Initialization.exception.HandleGetSixMenu);

            switch(menu)
            {
                case (int)Initialization.MemberMenu.INQUIRTBOOK:
                    RunInquiryBookMenuInMember(inquiry,id);
                    break;

                case (int)Initialization.MemberMenu.BORROW:
                    RunBorrowing(borrowing,id);
                    RunMemberMenu(id);
                    break;

                case (int)Initialization.MemberMenu.RETURN:
                    RunReturn(borrowing, id);
                    RunMemberMenu(id);
                    break;

                case (int)Initialization.MemberMenu.SEARCHINFO:
                    RunModifyMemberM(modification, id);
                    break;
              
                case (int)Initialization.MemberMenu.WITHDARWING:
                    RunWithdrawMenu(elimination,id,registration,borrowingData);
                    break;

                case (int)Initialization.MemberMenu.BACK:
                    RunMenu(registration);
                    break;

            }
        }

        public void RunModifyMemberM(Modification modification,string id)
        {
            modification.RunModifyMemberBySelf(id, memberData);
            RunMemberMenu(id);
        }

        public void RunBorrowing(Borrowing borrowing, string id)
        {
            borrowing.RunBorrowing(id, borrowingData, bookdata);
        }

        public void RunReturn(Borrowing borrowing, string id)
        {
            bool isFind = true;
            isFind = borrowing.ShowBookForReturn(id);
            if(isFind)
            {
                borrowing.ReturnBook(id, borrowingData,bookdata);
            }
            
            RunMemberMenu(id);
        }

        public void RunWithdrawMenu(Elimination elimination,string id,Registration registration,BorrowingData borrowingData)
        {
            if(elimination.RunWithdraw(memberData, borrowingData,id))
            {
                RunMenu(registration);
            }

            else
            {
                RunMemberMenu(id);
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
            menu = GetMenu(Initialization.exception.HandleManagerMenuInput);

            switch (menu)
            {
                case (int)Initialization.ManagerMenu.SEARCHMEMBER:
                    RunInquiryMemberMenu(inquiry);
                    break;

                case (int)Initialization.ManagerMenu.MODIFYMEMBER:
                    RunModifyMember(modification);
                    break;

                case (int)Initialization.ManagerMenu.ELIMINATEMEMBER:
                    RunDeleteMemberMenu(elimination);
                    break;

                case (int)Initialization.ManagerMenu.SEARCHBOOK:
                    RunSearchBookMenu(inquiry);
                    break;

                case (int)Initialization.ManagerMenu.REGISTERBOO:
                    RunGetMethodOfRegister(registration);
                    break;

                case (int)Initialization.ManagerMenu.MODIFYBOOK:
                    RunModifyBookMenu(modification);

                    break;

                case (int)Initialization.ManagerMenu.ELIMINATEBOOK:
                    RunDeleteBookMenu(elimination);
                    break;

                case (int)Initialization.ManagerMenu.RECORD:
                    RunRecordMenu();
                    break;

                case (int)Initialization.ManagerMenu.BACK:
                    RunMenu(registration);
                    break;

            }

        }

        // 회원 조회 메뉴
        public void RunInquiryMemberMenu(Search inquiry)
        {
            int menu;

            Console.Clear();
            Initialization.screen.PrintLabel();
            Initialization.screen.PrintInquiryMemberMenu();
            Initialization.screen.PrintInput();
            menu = GetMenu(Initialization.exception.HandleGetFiveMenu);

            switch (menu)
            {
                case (int)Initialization.InquiryMemberMenu.NAME:
                    inquiry.ShowMemberByName();
                    RunInquiryMemberMenu(inquiry);
                    break;

                case (int)Initialization.InquiryMemberMenu.ID:
                    inquiry.ShowMemberById(memberData);
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
            menu = GetMenu(Initialization.exception.HandleGetThreeMenu);

            switch (menu)
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
        }

        // 회원 삭제 메뉴
        public void RunDeleteMemberMenu(Elimination elimination)
        {
                elimination.RunDeleteMember(memberData);
                RunManagerMenu();
        }

        // 도서 등록 메뉴
        public void RunGetMethodOfRegister(Registration registration)
        {
            int menu;
            Console.Clear();
            Initialization.screen.PrintLabel();
            Initialization.screen.PrintMethodRegister();
            Initialization.screen.PrintInput();
            menu = GetMenu(Initialization.exception.HandleGetThreeMenu);
            switch (menu)
            {
                case (int)Initialization.RegisterBook.DIRECTION:
                    registration.RunRegisterBook();
                    RunGetMethodOfRegister(registration);
                    break;
                case (int)Initialization.RegisterBook.SEARCH:
                    registration.RunRegisterFromSearch(api,bookdata);
                    RunGetMethodOfRegister(registration);
                    break;
                case (int)Initialization.RegisterBook.BACK:
                    RunManagerMenu();
                    break;

            }
            
        }

        // 도서 조회 메뉴
        public void RunSearchBookMenu(Search search)
        {
            int menu;

            Console.Clear();
            Initialization.screen.PrintLabel();
            Initialization.screen.PrintSearchBookMenu();
            Initialization.screen.PrintInput();
            menu = GetMenu(Initialization.exception.HandleGetSixMenu);

            switch (menu)
            {
                case (int)Initialization.SearchBookMenu.TITLE:
                    inquiry.ShowBookyTitle(bookdata,"q");
                    RunSearchBookMenu(inquiry);
                    break;

                case (int)Initialization.SearchBookMenu.PUBLISHER:
                    inquiry.ShowBookByPublisher(bookdata, "q");
                    RunSearchBookMenu(inquiry);
                    break;

                case (int)Initialization.SearchBookMenu.AUTHOR:
                    inquiry.ShowBookByAuthor(bookdata, "q");
                    RunSearchBookMenu(inquiry);
                    break;

                case (int)Initialization.SearchBookMenu.NAVERAPI:
                    inquiry.ShowBookByNaverApi(api);
                    RunSearchBookMenu(inquiry);
                    break;


                case (int)Initialization.SearchBookMenu.ALL:
                    inquiry.ShowAllBook("q");
                    RunSearchBookMenu(inquiry);
                    break;

                case (int)Initialization.SearchBookMenu.BACK:
                    RunManagerMenu();
                    break;
            }
        }

        // 활동내역조회 메뉴
        public void RunRecordMenu()
        {
            int menu;

            Console.Clear();
            Initialization.screen.PrintLabel();
            Initialization.screen.PrintRecordMenu();
            Initialization.screen.PrintInput();
            menu = GetMenu(Initialization.exception.HandleGetFourMenu);

            switch(menu)
            {
                case (int)Initialization.Record.SHOW:
                    Initialization.log.ShowRecord();
                    RunRecordMenu();
                    break;

                case (int)Initialization.Record.SAVE:
                    Initialization.log.SaveRecord();
                    RunRecordMenu();
                    break;

                case (int)Initialization.Record.RESET:
                    Initialization.log.ResetRecord();
                    RunManagerMenu();
                    break;

                case (int)Initialization.Record.BACK:
                    RunManagerMenu();
                    break;
            }
        }

        // 회원의 도서 조회 메뉴
        public void RunInquiryBookMenuInMember(Search inquiry,string id)
        {
            int menu;

            Console.Clear();
            Initialization.screen.PrintLabel();
            Initialization.screen.PrintSearchBookByMember();
            Initialization.screen.PrintInput();
            menu = GetMenu(Initialization.exception.HandleGetFiveMenu);

            switch (menu)
            {
                case (int)Initialization.SearchBookMenuByMember.TITLE:
                    inquiry.ShowBookyTitle(bookdata,id);
                    RunInquiryBookMenuInMember(inquiry,id);
                    break;

                case (int)Initialization.SearchBookMenuByMember.PUBLISHER:
                    inquiry.ShowBookByPublisher(bookdata,id);
                    RunInquiryBookMenuInMember(inquiry,id);
                    break;

                case (int)Initialization.SearchBookMenuByMember.AUTHOR:
                    inquiry.ShowBookByAuthor(bookdata,id);
                    RunInquiryBookMenuInMember(inquiry,id);
                    break;

                case (int)Initialization.SearchBookMenuByMember.ALL:
                    inquiry.ShowAllBook(id);
                    RunInquiryBookMenuInMember(inquiry,id);
                    break;

                case (int)Initialization.SearchBookMenuByMember.BACK:
                    RunMemberMenu(id);
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
            menu = GetMenu(Initialization.exception.HandleGetThreeMenu);

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

        public int GetMenu(Func<string,string> MethodName)
        {
            string menuCheck;
            int menu;

            menuCheck = Console.ReadLine();
            menu = Convert.ToInt32(MethodName(menuCheck));

            return menu;
        }
    }
}
