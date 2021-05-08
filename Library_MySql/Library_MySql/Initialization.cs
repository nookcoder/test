using Library_MySql.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_MySql
{
    // 싱글턴 사용, Constants 관리 
    class Initialization
    {
        public static Screen screen = Screen.Instance();
        public static Exception exception = Exception.Instance();
        public static Log log = Log.Instance();
        public enum InitalMenu
        {
            MEMBERLOGIN = 1,
            JOIN,
            MANAGERLOGIN,
            EXIT
        }

        public enum ManagerMenu
        {
            SEARCHMEMBER = 1,
            MODIFYMEMBER,
            ELIMINATEMEMBER,
            SEARCHBOOK,
            REGISTERBOO,
            MODIFYBOOK,
            ELIMINATEBOOK,
            BACK
        }

        public enum InquiryMemberMenu
        {
            NAME = 1,
            ID,
            ALL,
            BACK
        }

        public enum ModifyMember
        {
            PHONENUMBER = 1,
            ADDRESS,
            BACK
        }

        public enum ModifyBookMenu
        {
            PRICE = 1,
            COUNT,
            BACK
        }

        public enum SearchBookMenu
        {
            TITLE = 1,
            PUBLISHER,
            AUTHOR,
            NAVERAPI,
            ALL,
            BACK
        }
        public enum SearchBookMenuByMember
        {
            TITLE = 1,
            PUBLISHER,
            AUTHOR,
            ALL,
            BACK
        }


        public enum MemberMenu
        {
            INQUIRTBOOK = 1,
            BORROW,
            RETURN,
            SEARCHINFO,
            WITHDARWING,
            BACK
        }

        public enum RegisterBook
        {
            DIRECTION = 1,
            SEARCH, 
            BACK
        }


        public const bool FIND = true;
        public const bool NOFIND = false;
        public const string CONNECTION = "Server=localhost;Database=member;Uid=root;Pwd=0000;Charset=utf8;Allow User Variables=True";
        public const int MEMBER = 1;
        public const int MANAGER = 2;
        public const string NAVERURL = "https://openapi.naver.com/v1/search/book.json?query=";
        public const string CLIENTID = "Zl4hxjmmQUTpgabjSSpf";
        public const string CLIENTPASSWORD = "2BCZvyEaSw";

    }
}
