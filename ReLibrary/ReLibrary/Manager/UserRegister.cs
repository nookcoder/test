using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReLibrary.VO;
using ReLibrary.Controller;

namespace ReLibrary.Manager
{
    class UserRegister
    {
        List<UserVO> userList;
        List<BooksVO> bookList;

        // 관리자가 유저 회원 등록을 할 때 나올 화면 
        public UserRegister(List<UserVO> userList, List<BooksVO> bookList)
        {
            this.userList = userList;
            this.bookList = bookList;
        }

        public void RegisterUser()
        {
            SignUp signUp = new SignUp(userList, bookList);

            string name;
            string phoneNumber;
            string address;
            string id;
            string password;
            string hint;

            name = signUp.InputName();
            phoneNumber = signUp.InputNumber(name);
            address = signUp.InputAdress(name, phoneNumber);
            id = signUp.InputId(name, phoneNumber, address);
            password = signUp.InputPassword(name, phoneNumber, address, id);
            hint = signUp.InputHint(name, phoneNumber, address, id, password);

            UserVO user = new UserVO(name, phoneNumber, address, id, password, hint);
            userList.Add(user);

            Console.Clear();

            ManagerMenu managerMenu = new ManagerMenu(userList, bookList);
            managerMenu.LoadMangerMenu();
        }
    }
}
