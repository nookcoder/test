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
        public Set()
        {
            this.userList = new List<UserVO>();
            FirstPage firstPage = new FirstPage(this.userList);
            
        }
    }
}
