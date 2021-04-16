using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReLibrary.VO;
using ReLibrary.Controller;

namespace ReLibrary.Model
{
    class Set
    {
        List<UserVO> userList;
        List<BooksVO> bookList;
        
        // 초기 설정 
        public Set()
        {
            this.userList = new List<UserVO>();
            this.bookList = new List<BooksVO>();
            if (this.userList.Count == 0)
            {
                this.userList.Add(new UserVO("김현욱", "01050477361", "사우", "qwe123qwe123", "qwe123qwe123", "김포고"));
            }
            if(this.bookList.Count == 0)
            {
                this.bookList.Add(new BooksVO("1", "컴포즈커피", "초코라떼", "휘핑추가"));
                this.bookList.Add(new BooksVO("2", "빽다방", "아이스", "아메리카노"));
                this.bookList.Add(new BooksVO("3", "오븐속", "파스타", "크림파스타") );
            }
            FirstPage firstPage = new FirstPage(this.userList,this.bookList);
        }
    }
}
