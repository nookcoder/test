using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_MySql
{
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



    }
}
