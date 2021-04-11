using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    class BookMain
    {
        public BookMain()
        {
        
        }

        private int menu; 

        public void ShowBookMain()
        {
            Console.WriteLine("[1] 도서 등록");
            Console.WriteLine("[2] 도서 수정");
            Console.WriteLine("[3] 도서 검색");
            Console.WriteLine("[4] 도서 출력");
            Console.WriteLine("[5] 도서 대여");
            Console.WriteLine("[6] 도서 반납");
            Console.WriteLine("[7] 뒤로 가기");
            Console.Write("메뉴로 이동: ");
            menu = int.Parse(Console.ReadLine());
        }
    }
}
