using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReLibrary.Controller;
using ReLibrary.View;


namespace ReLibrary.Model
{
    class FirstPageModel : Constants
    {
        public FirstPageModel()
        {
        
        }

        public void TakeFirstPageMenu(int menu)
        {
            switch(menu)
            {
                case Constants.USERMENU:
                    break;

                case Constants.MANAGERMENU:
                    break;

                case Constants.QUIT:
                    Environment.Exit(0);
                    break;
            }
        }
            
    }

}
