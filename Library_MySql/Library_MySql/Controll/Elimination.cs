using Library_MySql.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_MySql.Controll
{
    class Elimination
    {
        private BookData bookData;

        public Elimination()
        {
            this.bookData = new BookData();
        }

        public void RunDeletBook(BookData bookData)
        {
            string bookId;
            string decision;

            Console.Clear();
            Initialization.screen.PrintExit();
            Initialization.screen.PrintGetDeleteBookId();
            bookId = Get(Initialization.exception.HandleGetBookIdInModification);

            if (bookId != "q")
            {
                if (bookData.IsBookIdDuplication(bookId))
                {
                    Initialization.screen.PrintGetDecision();
                    decision = Get(Initialization.exception.HandleGetDecision);
                    if (decision == "1")
                    {
                        bookData.DeletBookdata(bookId);
                        Initialization.log.RecordWithBookWithBookId("관리자",bookId,"삭제");
                        Initialization.screen.PrintDeletingNotice();
                        Initialization.screen.PrintNext();
                        Console.ReadKey();
                    }
                    else { }

                }

                else
                {
                    Initialization.screen.PrintNoFindBookNOtice();
                }
            }

            else { }
        }

        public void RunDeleteMember(MemberData memberData)
        {
            string Id;
            string decision;

            Console.Clear();
            Initialization.screen.PrintExit();
            Initialization.screen.PrintGetDeleteId();
            Id = Get(Initialization.exception.HandleGetIdInDelete);

            if (Id != "q")
            {
                if (memberData.IsCheckMemberId(Id))
                {
                    Initialization.screen.PrintGetDecision();
                    decision = Get(Initialization.exception.HandleGetDecision);
                    if (decision == "1")
                    {
                        memberData.DeletMemberData(Id);
                        Initialization.log.RecordWithBook("관리자", Id, "삭제");
                        Initialization.screen.PrintDeletingNotice();
                        Initialization.screen.PrintNext();
                        Console.ReadKey();
                    }
                }

                else
                {
                    Initialization.screen.PrintNoFindMemberNOtice();
                }
            }

            else { }
        }

        public bool RunWithdraw(MemberData memberData,BorrowingData borrowingData, string id)
        {
            string password;
            string decision;
            bool isDone = false;

            Console.Clear();
            Initialization.screen.PrintExit();
            Initialization.screen.PrintGetPassword();
            password = Get(Initialization.exception.HandleGetPassword);
            if (password != "q")
            {
                if (memberData.IsCheckMemberPassword(id, password))
                {
                    Initialization.screen.PrintGetDecision();
                    decision = Get(Initialization.exception.HandleGetDecision);
                    if (decision == "1")
                    {
                        memberData.DeletMemberData(id);
                        borrowingData.DeletMemberData(id);
                        Initialization.log.RecordWithNoBook(id, "탈퇴");
                        isDone = true;
                        Initialization.screen.PrintDeletingNotice();
                        Initialization.screen.PrintNextProccess();
                        
                    }
                }

                else
                {
                    Initialization.screen.PrintLoginError();
                    Initialization.screen.PrintNextProccess();
                }
            }

            return isDone;
        }

        public string Get(Func<string, string> methodName)
        {
            string str;
            str = Console.ReadLine();
            str = methodName(str);

            return str;
        }

    }
}
