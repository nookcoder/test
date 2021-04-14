using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReLibrary.Controller
{
    class Input
    {
        public Input()
        {
        }
        public string RequestInput()
        {
            string menu;
            menu = Console.ReadLine();

            return menu;
        }
    }
}
