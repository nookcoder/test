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

        public enum InitalMenu
        {
            MEMBERLOGIN = 1,
            JOIN,
            MANAGERLOGIN,
            EXIT
        }

        public enum ManagerMenu
        {
            INQUIRYMEMBER = 1,
            MODIFYMEMBER,
            ELIMINATEMEMBER,
            INQUIRYBOOK,
            REGISTERBOO,
            MODIFYBOOK,
            ELIMINATEBOOK,
            BACK
        }

        public enum InquiryMemberMenu
        {
            NAME = 1,
            AGE,
            ADDRESS,
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
            ALL,
            BACK
        }

        public enum MemberMenu
        {
            INQUIRTBOOK = 1,
            BORROW,
            RETURN,
            INQUIRTMEMBER,
            BACK
        }


        public const bool FIND = true;
        public const bool NOFIND = false;
    }
}
