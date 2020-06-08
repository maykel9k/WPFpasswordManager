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
using System.Xml;

namespace WPF2Lab
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {

        int d = 1,p = 1,i = 1;

        public string currdir { get; set; }
        TreeViewItem currit;
        
        

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

            DependencyObject obj = e.OriginalSource as DependencyObject;
            TreeViewItem item = GetDependencyObjectFromVisualTree(obj, typeof(TreeViewItem)) as TreeViewItem;
            currit = item;
            try
            {
                string header = (string)item.Header;
                if (header.Contains("Directory"))
                {

                    ContextMenu crm = this.FindResource("crmDir") as ContextMenu;
                    crm.PlacementTarget = sender as TreeViewItem;
                    currdir = header;
                    crm.IsOpen = true;
                    

                }
            }
           catch(NullReferenceException excep)
            {
                ContextMenu crm = this.FindResource("crmButton") as ContextMenu;
                crm.PlacementTarget = sender as TreeView;
                crm.IsOpen = true;
            }

        }

        private static DependencyObject GetDependencyObjectFromVisualTree(DependencyObject startObject, Type type)
        {
            var parent = startObject;
            while (parent != null)
            {
                if (type.IsInstanceOfType(parent))
                    break;
                parent = VisualTreeHelper.GetParent(parent);
            }
            return parent;
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
            treeItem.FontWeight = FontWeights.Bold;
            //treeItem.MouseRightButtonUp += treeItem_MouseRightButtonUp;
            Tree.Items.Add(treeItem);
            d++;
        }

        private void MenuItem_Click_4(object sender, RoutedEventArgs e)
        {
            string dir = $"New Directory {d}";
            TreeViewItem treeItem = null;
            treeItem = new TreeViewItem();
            treeItem.Header = dir;
            //treeItem.MouseRightButtonUp += treeItem_MouseRightButtonUp;
            currit.Items.Add(treeItem);
            d++;
        }

        private void Page_ContextMenuOpening(object sender, ContextMenuEventArgs e)
        {
            
        }

        private void treeItem_MouseRightButtonUp(object sender, MouseButtonEventArgs e)
        {
            /*
            ContextMenu crm = this.FindResource("crmDir") as ContextMenu;
            crm.PlacementTarget = sender as TreeViewItem;
            crm.IsOpen = true;
            */
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
