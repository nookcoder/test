﻿using Library_MySql.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_MySql.Controll
{
    class Modification
    {
        private MemberData memberData;

        public Modification()
        {
            this.memberData = new MemberData();
        }

        /// <summary>
        ///  책 정보 수정 관련 함수 
        /// </summary>
        /// <param name="bookdata"></param>
        public void RunModiftBookPrice(BookData bookdata)
        {
            string bookId;
            string bookPrice;

            bookId = GetModifyBookId();
            if (bookId == "q")
            {
                // 이전 메뉴로 돌아감
            }

            else
            {
                // 책을 찾았을 때 
                if (bookdata.IsBookIdDuplication(bookId))
                {
                    bookPrice = GetModifyPrice();
                    if (bookPrice != "q")
                    {
                        bookdata.UpdateBookPricedate(bookId, bookPrice);
                        Initialization.log.RecordWithBookWithBookId("관리자", bookId, "수정");
                        Initialization.screen.PrintModifingNotice();
                        Initialization.screen.PrintNext();
                        Console.ReadKey();
                    }
                    else { }
                }

                // 못 찾았당...ㅠㅠ
                else
                {
                    Initialization.screen.PrintNoFindBookNOtice();
                }
            }
        }

        public void RunModiftBookCount(BookData bookdata)
        {
            string bookId;
            string bookCount;

            bookId = GetModifyBookId();
            if (bookId == "q")
            {
                // 이전 메뉴로 돌아감
            }

            else
            {
                // 책을 찾았을 때 
                if (bookdata.IsBookIdDuplication(bookId))
                {
                    bookCount = GetModifyCount();
                    if (bookCount != "q")
                    {
                        bookdata.UpdateBookCountdate(bookId, bookCount);
                        Initialization.log.RecordWithBookWithBookId("관리자", bookId, "수정");
                        Initialization.screen.PrintModifingNotice();
                        Initialization.screen.PrintNext();
                        Console.ReadKey();
                    }
                    else { }
                }

                // 못 찾았당...ㅠㅠ
                else
                {
                    Initialization.screen.PrintNoFindBookNOtice();
                }
            }
        }
       
        public string GetModifyBookId()
        {
            string bookIdCheck;
            string bookId;

            Console.Clear();
            Initialization.screen.PrintExit();
            Initialization.screen.PrintGetModifingBookId();
            bookIdCheck = Console.ReadLine();
            bookId = Initialization.exception.HandleGetBookIdInModification(bookIdCheck);

            return bookId;
        }

        public string GetModifyPrice()
        {
            string bookPriceCheck;
            string bookPrice;

            Console.Clear();
            Initialization.screen.PrintExit();
            Initialization.screen.PrintGetModifingBookPrice();
            bookPriceCheck = Console.ReadLine();
            bookPrice = Initialization.exception.HandleGetBookPriceInModification(bookPriceCheck);

            return bookPrice;
        }

        public string GetModifyCount()
        {
            string bookCountCheck;
            string bookCount;

            Console.Clear();
            Initialization.screen.PrintExit();
            Initialization.screen.PrintGetModifingBookCount();
            bookCountCheck = Console.ReadLine();
            bookCount = Initialization.exception.HandleGetBookCountInModification(bookCountCheck);

            return bookCount;
        }

        /// <summary>
        /// 회원 정보 수정 관련 함수 
        /// </summary>
        /// <param name="memberData"></param>
        
        public void RunModifyMemberBySelf(string id,MemberData memberData)
        {
            string menuCheck;
            int menu; 

            memberData.ShowMyData(id);
            menuCheck = GetTwoMenu();
            
            if (menuCheck != "q")
            {
                menu = int.Parse(menuCheck);
                switch(menu)
                {
                    case (int)Initialization.ModifyMember.PHONENUMBER:
                        ModifyPhoneNumber(id,memberData);
                        break;

                    case (int)Initialization.ModifyMember.ADDRESS:
                        ModifyAddress(id, memberData);
                        break;
                }
            }

            else { }
        }

        public void ModifyPhoneNumber(string id,MemberData memberData)
        {
            string phoneNumber;

            Initialization.screen.PrintGetModifingPhoneNumber();
            phoneNumber = GetWithMemberData(Initialization.exception.HandleGetPhoneNumberInModificationBySelf);
            if(phoneNumber != "q")
            {
                Modify(id, phoneNumber, "phoneNumber");
                Initialization.log.RecordWithNoBook(id, "전화번호 수정");
            }
        }

        public void ModifyAddress(string id, MemberData member)
        {
            string address;

            Initialization.screen.PrintGetModifingAddress();
            address = Get(Initialization.exception.HandleGetAddressInModificationBySelf);
            if(address != "q")
            {
                Modify(id, address, "address");
                Initialization.log.RecordWithNoBook(id, "주소 수정");

            }
        }

        // 수정해주는 함수 
        public void Modify(string id, string input, string type)
        {
            memberData.UpdateMember(id, type, input);
            Initialization.screen.PrintModifingNotice();
            Initialization.screen.PrintNextProccess();
        }
        
        public void RunModifyMemberAddress(MemberData memberData)
        {
            string memberId;
            string memeberAddress;

            Console.Clear();
            Initialization.screen.PrintExit();
            Initialization.screen.PrintGetModifingMemberId();
            memberId = Get(Initialization.exception.HandleGetIdInModifing);

            // 종류 아닐 때 
            if (memberId != "q")
            {
                // 해당 되는 회원 아이디가 있을 때
                if (memberData.IsCheckMemberId(memberId))
                {
                    Console.Clear();
                    Initialization.screen.PrintExit();
                    Initialization.screen.PrintGetModifingAddress();
                    memeberAddress = Get(Initialization.exception.HandleGetAddressInModification);

                    // 종료 아닐 때 
                    if (memeberAddress != "q")
                    {
                        memberData.UpdateMember(memberId,"address" ,memeberAddress);
                        Initialization.log.RecordWithBook("관리자", memberId, "수정");
                        Initialization.screen.PrintModifingNotice();
                        Initialization.screen.PrintNext();
                        Console.ReadKey();
                    }

                    else { }
                }

                else
                {
                    Initialization.screen.PrintNoFindMemberNOtice();
                }
            }

            else { }
        }

        public void RunModifyMemberPhoneNumber(MemberData memberData)
        {
            string memberId;
            string memeberPhoneNumber;

            memberId = Get(Initialization.exception.HandleGetIdInModifing);

            // 종류 아닐 때 
            if (memberId != "q")
            {
                // 해당 되는 회원 아이디가 있을 때
                if (memberData.IsCheckMemberId(memberId))
                {
                    Console.Clear();
                    Initialization.screen.PrintExit();
                    Initialization.screen.PrintGetModifingAddress();
                    memeberPhoneNumber = Get(Initialization.exception.HandleGetAddressInModification);

                    // 종료 아닐 때 
                    if (memeberPhoneNumber != "q")
                    {
                        memberData.UpdateMember(memberId, "phoneNumber", memeberPhoneNumber);
                        Initialization.log.RecordWithBook("관리자", memberId, "수정");
                        Initialization.screen.PrintModifingNotice();
                        Initialization.screen.PrintNext();
                        Console.ReadKey();
                    }

                    else { }
                }

                else
                {
                    Initialization.screen.PrintNoFindMemberNOtice();
                }
            }

            else { }
        }

        /// <summary>
        /// 무언가를 얻어올 때 쓰는 함수들 
        /// </summary>
        /// <param name="MethodName"></param>
        /// <returns></returns>
        public string Get(Func<string, string>MethodName)
        {
            string str;
            str = Console.ReadLine();
            str = MethodName(str);

            return str;
        }

        public string GetWithMemberData(Func<string, MemberData,string>MethodName)
        {
            string str;
            MemberData memberData = new MemberData();
            str = Console.ReadLine();
            str = MethodName(str, memberData);

            return str;
        }

        public string GetTwoMenu()
        {
            string menuCheck;
            string menu;
            Initialization.screen.PrintExit();
            Initialization.screen.PrintKindOfModifing();
            Initialization.screen.PrintInput();
            menuCheck = Console.ReadLine();
            menu = Initialization.exception.HandleGetTwoMenu(menuCheck);

            return menu;
        }

    }
}
