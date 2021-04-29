using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LectureTimeTable2.Registeration
{
    class RegistrationException
    {
        private RegistrationScreen RegistrationScreen; 

        public RegistrationException()
        {
            this.RegistrationScreen = new RegistrationScreen();
        }

        public int HandleGetRegistrationMenu(string menuCheck)
        {
            int menu;
            
            Regex regex = new Regex(@"^[1-4]{1}$");
            
            while(!regex.IsMatch(menuCheck))
            {
                RegistrationScreen.PrintRegistrationMenu();
                RegistrationScreen.PrintMenuError();
                menuCheck = Console.ReadLine();
            }

            menu = Convert.ToInt32(menuCheck);
    
            return menu;
        }

        public string HandleGetReviseAttentionCourse(string attentionCourseNubmerCheck)
        {
            Regex regex = new Regex(@"^[q1-9]{1,2}$");

            while (!regex.IsMatch(attentionCourseNubmerCheck))
            {
                RegistrationScreen.PrintRegisterCourseNumberError();
                attentionCourseNubmerCheck = Console.ReadLine();
            }

            return attentionCourseNubmerCheck;
        }
    }
}
