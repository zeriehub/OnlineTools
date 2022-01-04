using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialTools.MVVM
{
    interface ITodoHandler
    {
        /*List of Items for priority-1*/

      public List<string> TodoItems { get;  set; }

        public void AddItem(string item);
        public void ShowInputCard();



    }
}
