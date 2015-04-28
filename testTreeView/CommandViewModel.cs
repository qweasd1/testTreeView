using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;

namespace testTreeView
{
    public class CommandViewModel
    {
      

        public CommandViewModel(string name, Action execute)
        {
            // TODO: Complete member initialization
            this.Name = name;
            this.Command = new DelegateCommand(execute);
        }
        public string Name { get; set; }
        public ICommand Command { get; set; }
    }
}
