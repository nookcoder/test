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

            bookId = GetBookId();

            if (bookId != "q")
            {
                if(bookData.IsBookIdDuplication(bookId))
                {
                    bookData.DeletBookdata(bookId);
                    Initialization.screen.PrintDeletingNotice();
                    Initialization.screen.PrintNext();
                    Console.ReadKey();
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

            Id = GetMemberId();

            if (Id != "q")
            {
                if (memberData.IsMemberIdDuplication(Id))
                {
                    memberData.DeletMemberData(Id);
                    Initialization.screen.PrintDeletingNotice();
                    Initialization.screen.PrintNext();
                    Console.ReadKey();
                }

                else
                {
                    Initialization.screen.PrintNoFindMemberNOtice();
                }
            }

            else { }
        }
    }
}
