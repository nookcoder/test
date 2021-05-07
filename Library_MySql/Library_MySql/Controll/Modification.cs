using Library_MySql.Model;
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
                        
                        break;
                }
            }

            else { }
        }

        public void ModifyPhoneNumber(string id,MemberData memberData)
        {
            string phoneNumber;

            phoneNumber = GetMemberPhoneNumber();
            if(phoneNumber != "q")
            {
                memberData.UpdateMember(id, "phoneNumber", phoneNumber);
                Initialization.screen.PrintModifingNotice();
                Initialization.screen.PrintNextProccess();
            }
        }

        public void RunModifyMemberAddress(MemberData memberData)
        {
            string memberId;
            string memeberAddress;

            memberId = GetMemberId();

            // 종류 아닐 때 
            if (memberId != "q")
            {
                // 해당 되는 회원 아이디가 있을 때
                if (memberData.IsMemberIdDuplication(memberId))
                {
                    memeberAddress = GetMemberAddress();

                    // 종료 아닐 때 
                    if (memeberAddress != "q")
                    {
                        memberData.UpdateMember(memberId,"address" ,memeberAddress);
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

            memberId = GetMemberId();

            // 종류 아닐 때 
            if (memberId != "q")
            {
                // 해당 되는 회원 아이디가 있을 때
                if (memberData.IsMemberIdDuplication(memberId))
                {
                    memeberPhoneNumber = GetMemberAddress();

                    // 종료 아닐 때 
                    if (memeberPhoneNumber != "q")
                    {
                        memberData.UpdateMember(memberId,"phoneNumber" , memeberPhoneNumber);
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

        public string GetMemberId()
        {
            string memberIdCheck;
            string memberId;

            Console.Clear();
            Initialization.screen.PrintExit();
            Initialization.screen.PrintGetModifingMemberId();
            memberIdCheck = Console.ReadLine();
            memberId = Initialization.exception.HandleGetIdInModifing(memberIdCheck);

            return memberId;
        }

        public string GetMemberPhoneNumber()
        {
            string phoneNumberCheck;
            string phoneNumber;

            Initialization.screen.PrintGetModifingPhoneNumber();
            phoneNumberCheck = Console.ReadLine();
            phoneNumber = Initialization.exception.HandleGetPhoneNumberInModificationBySelf(phoneNumberCheck,memberData);

            return phoneNumber;
        }

        // 관리자 
        public string GetMemberPhoneNumberM()
        {
            string phoneNumberCheck;
            string phoneNumber;

            Console.Clear();
            Initialization.screen.PrintExit();
            Initialization.screen.PrintGetModifingPhoneNumber();
            phoneNumberCheck = Console.ReadLine();
            phoneNumber = Initialization.exception.HandleGetPhoneNumberInModification(phoneNumberCheck, memberData);

            return phoneNumber;
        }

        public string GetMemberAddress()
        {
            string addressCheck;
            string address;

            Console.Clear();
            Initialization.screen.PrintExit();
            Initialization.screen.PrintGetModifingAddress();
            addressCheck = Console.ReadLine();
            address = Initialization.exception.HandleGetAddressInModification(addressCheck);

            return address;
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
