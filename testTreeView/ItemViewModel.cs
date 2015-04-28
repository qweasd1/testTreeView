using System;
using System.Collections.Generic;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Practices.Prism.Commands;
using System.Windows;

namespace testTreeView
{
    public class ItemViewModel
    {
        public string Name { get; set; }

        public ItemViewModel Parent { get; set; }
       

        public ListCollectionView SubItems { get; set; }

        private ObservableCollection<ItemViewModel> _subItems;
        public ObservableCollection<CommandViewModel> ContextCommands { get; set; }
        
        private ItemViewModel()
        {           
            _subItems = new ObservableCollection<ItemViewModel>();
            SubItems = new ListCollectionView(_subItems);
            ContextCommands = new ObservableCollection<CommandViewModel>();
        }

        public ItemViewModel(string name)
            :this()
        {
            Name = name;
        }

        #region Create
        public void AddCommand(string name, Action execute)
        {
            var cmdVM = new CommandViewModel(name, execute);
            ContextCommands.Add(cmdVM);
        }

        public ItemViewModel CreateSubItem(string name)
        {
            var subItem = new ItemViewModel(name);
            subItem.Parent = this;
            _subItems.Add(subItem);

            return subItem;
        }

        #endregion


        #region View Operation

        public void Filter(Predicate<object> filter)
        {
            SubItems.Filter = (o)=>((ItemViewModel)o).PassFilter(filter);
            foreach (ItemViewModel sItem in SubItems)
            {
                sItem.Filter(filter);
            }
        }

        private bool PassFilter(Predicate<object> filter)
        {
            if (SubItems.Count > 0)
            {
                return SubItems.OfType<ItemViewModel>().Any(i=>i.PassFilter(filter)) || filter.Invoke(this);
            }
            else
            {
                return filter.Invoke(this);
            }

           
        }

        #endregion


    }
}
