using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using Microsoft.Practices.Prism.Commands;


namespace testTreeView
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        
        private void test(object sender, RoutedEventArgs e)
        {
            mainVM = new ItemViewModel("root");


            var itemVM = mainVM.CreateSubItem("item1");
            itemVM.AddCommand("show messageBox", () => MessageBox.Show("test"));

            itemVM.CreateSubItem("sub1");
            itemVM.CreateSubItem("longerName");
            var sub2 = itemVM.CreateSubItem("sub2");
            sub2.CreateSubItem("sub-sub1");

            
            tv_test.ItemsSource = mainVM.SubItems;
        }

        ItemViewModel mainVM;

        private void Filter(object sender, RoutedEventArgs e)
        {
            mainVM.Filter((o)=>((ItemViewModel)o).Name.Length > 5);   
        }

        private void tb_filter_TextChanged(object sender, TextChangedEventArgs e)
        {
            mainVM.Filter((o) => ((ItemViewModel)o).Name.Contains(tb_filter.Text));
        }
    }
}
