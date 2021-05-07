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

        public string GetBookId()
        {
            string bookIdCheck;
            string bookId;

            Console.Clear();
            Initialization.screen.PrintExit();
            Initialization.screen.PrintGetDeleteBookId();
            bookIdCheck = Console.ReadLine();
            bookId = Initialization.exception.HandleGetBookIdInModification(bookIdCheck);

            return bookId;
        }

        public void RunDeletBook(BookData bookData)
        {
            string bookId;
            string decision;
            bookId = GetBookId();

            if (bookId != "q")
            {
                if (bookData.IsBookIdDuplication(bookId))
                {
                    decision = GetDecision();
                    if (decision == "1")
                    {
                        bookData.DeletBookdata(bookId);
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

        public string GetMemberId()
        {
            string IdCheck;
            string Id;

            Console.Clear();
            Initialization.screen.PrintExit();
            Initialization.screen.PrintGetDeleteId();
            IdCheck = Console.ReadLine();
            Id = Initialization.exception.HandleGetIdInDelete(IdCheck);

            return Id;
        }

        public void RunDeleteMember(MemberData memberData)
        {
            string Id;
            string decision;
            Id = GetMemberId();

            if (Id != "q")
            {
                if (memberData.IsMemberIdDuplication(Id))
                {
                    decision = GetDecision();
                    if (decision == "1")
                    {
                        memberData.DeletMemberData(Id);
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

        public bool RunWithdraw(MemberData memberData, string id)
        {
            string password;
            string decision;
            bool isDone = false;

            Console.Clear();
            Initialization.screen.PrintExit();
            password = GetPassword();
            if (password != "q")
            {
                if (memberData.IsMemberPasswordDuplication(id, password))
                {
                    decision = GetDecision();
                    if (decision == "1")
                    {
                        memberData.DeletMemberData(id);
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

        public string GetDecision()
        {
            string decisionCheck;
            string decision;

            Initialization.screen.PrintGetDecision();
            decisionCheck = Console.ReadLine();
            decision = Initialization.exception.HandleGetDecision(decisionCheck);

            return decision;
        }

        public string GetPassword()
        {
            string passwordCheck;
            string password;

            Initialization.screen.PrintGetPassword();
            passwordCheck = Console.ReadLine();
            password = Initialization.exception.HandleGetPassword(passwordCheck);

            return password;
        }
    }
}
