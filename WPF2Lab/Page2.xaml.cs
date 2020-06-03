using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPF2Lab
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {

        int d = 1,p = 1,i = 1;

        public Page2()
        {
            
            InitializeComponent();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            ((MainWindow)Application.Current.MainWindow).Content = new Page1();
        }

        private void TreeView_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            ContextMenu crm = this.FindResource("crmButton") as ContextMenu;
            crm.PlacementTarget = sender as TreeView;
            crm.IsOpen = true;

        }

        private void MenuItem_Click_3(object sender, RoutedEventArgs e)
        {
            string img = $"New Image {i}";
            TreeViewItem treeItem = null;
            treeItem = new TreeViewItem();
            treeItem.Header = img;
            Tree.Items.Add(treeItem);
            i++;
        }

        private void Tree_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            string elem = Tree.SelectedItem.ToString();
            if(elem.Contains("Directory"))
            {

            }
            if (elem.Contains("Image"))
            {
                TopSecretImage.Visibility = Visibility.Visible;
            }
            if (elem.Contains("Password"))
            {
                
            }
        }

        private void MenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            string dir = $"New Directory {d}";
            TreeViewItem treeItem = null;
            treeItem = new TreeViewItem();
            treeItem.Header = dir;
            treeItem.MouseRightButtonUp += treeItem_MouseRightButtonUp;
            Tree.Items.Add(treeItem);
            d++;
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {

        }

        private void treeItem_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            ContextMenu crm = this.FindResource("crmDir") as ContextMenu;
            crm.PlacementTarget = sender as TreeViewItem;
            crm.IsOpen = true;
        }

        private void MenuItem_Click_2(object sender, RoutedEventArgs e)
        {
            string pass = $"New Password {p}";
            TreeViewItem treeItem = null;
            treeItem = new TreeViewItem();
            treeItem.Header = pass;
            Tree.Items.Add(treeItem);
            p++;
        }
    }
}
