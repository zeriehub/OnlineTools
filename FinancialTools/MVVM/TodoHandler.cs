using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialTools.MVVM
{
    public class TodoHandler:ITodoHandler
    {

        public List<string> TodoItems { get; set; } = new  List<string>();

        public void AddItem(string item)
        {

            if (TodoItems.Contains(item))
                return;
            TodoItems.Add(item);
         }

        public void ShowInputCard()
        {
            
        }
    }
}
