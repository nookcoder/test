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

        public void GuideFirstPageMenu(int menu)
        {
            switch(menu)
            {
                case Constants.USER_MENU:
                    UserLogin userLogin = new UserLogin();
                    break;

                case Constants.MANAGER_MENU:
                    break;

                case Constants.QUIT:
                    Environment.Exit(0);
                    break;
            }
        }
            
    }

}
