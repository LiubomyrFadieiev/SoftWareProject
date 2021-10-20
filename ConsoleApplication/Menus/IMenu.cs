using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication.Menus
{
    interface IMenu
    {
        public int CreateRow();
        public void ShowAllRows();
        public void ShowRowByID();
        public int ChangeRow();
        public int DeleteRow();
        public string[] ReturnMenu();
    }
}
