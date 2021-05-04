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
        string mySqlConnection;
        public Modification()
        {
            this.mySqlConnection = "Server=localhost;Database=member;Uid=root;Pwd=0000;Charset=utf8";
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
                        bookdata.UpdateBookdate(bookId, bookPrice);
                        Initialization.screen.PrintModifingNotice();
                        Initialization.screen.PrintNext();
                        Console.ReadKey();
                    }
                    else { }
                }

                // 못 찾았당...ㅠㅠ
                else
                {
                    Initialization.screen.PrintNoFind();
                    Initialization.screen.PrintNext();
                    Console.ReadKey();
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
                        bookdata.UpdateBookdate(bookId, bookCount);
                        Initialization.screen.PrintModifingNotice();
                        Initialization.screen.PrintNext();
                        Console.ReadKey();
                    }
                    else { }
                }

                // 못 찾았당...ㅠㅠ
                else
                {
                    Initialization.screen.PrintNoFind();
                    Initialization.screen.PrintNext();
                    Console.ReadKey();
                }
            }
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

    }
}
