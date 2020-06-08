using Microsoft.Win32;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public class Contact : INotifyPropertyChanged
    {
        private ImageSource _icon;
        public ImageSource Icon
        {
            get { return _icon; }
            set
            {
                _icon = value;
                RaisePropertyChanged("Icon");
            }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                RaisePropertyChanged("Name");
            }
        }

        private string _email;
        public string Email
        {
            get { return _email; }
            set
            {
                _email = value;
                RaisePropertyChanged("Email");
            }
        }

        private string _login;
        public string Login
        {
            get { return _login; }
            set
            {
                _login = value;
                RaisePropertyChanged("Login");
            }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                RaisePropertyChanged("Password");
            }
        }
        private string _website;
        public string Website
        {
            get { return _website; }
            set
            {
                _website = value;
                RaisePropertyChanged("Website");
            }
        }
        private string _notes;
        public string Notes
        {
            get { return _notes; }
            set
            {
                _notes = value;
                RaisePropertyChanged("Notes");
            }
        }

        public Contact() { }
        public Contact(ImageSource icon, string name, string email, string login, string password, string website, string notes)
        {
            Icon = icon;
            Name = name;
            Email = email;
            Login = login;
            Password = password;
            Website = website;
            Notes = notes;
        }
        //public Contact(Contact previousContact)
        //{
        //    Icon = previousContact.Icon;
        //    Name = previousContact.Name;
        //    Email = previousContact.Email;
        //    Login = previousContact.Login;
        //    Password = previousContact.Password;
        //    Website = previousContact.Website;
        //    Notes = previousContact.Notes;
        //}

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

    /// <summary>
    /// Interaction logic for Page2pass.xaml
    /// </summary>
    public partial class Page2pass : Page
    {
        ObservableCollection<Contact> contacts = new ObservableCollection<Contact>();
        Contact currentContact;


        public Page2pass()
        {
            InitializeComponent();
            accListBox.ItemsSource = contacts;
            currentContact = new Contact();
            currentContact.PropertyChanged += updateListItem;
            FormGrid.DataContext = currentContact;
        }

        private void imgButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog fdial = new OpenFileDialog();
            fdial.Filter = "Image files|*.bmp;*.jpg;*.gif;*.png;*.tif|All files|*.*";
            if (fdial.ShowDialog() == true)
                currentContact.Icon = new BitmapImage(new Uri(fdial.FileName));
        }

        private void addButton_Click(object sender, RoutedEventArgs e)
        {
            contacts.Add(new Contact() { Name = "Account Name" });
            accListBox.SelectedItem = accListBox.Items.GetItemAt(contacts.Count - 1);
            FormGrid.Visibility = Visibility.Visible;
        }

        private void accListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (accListBox.SelectedItem != null)
            {
                Contact indexContact = accListBox.SelectedItem as Contact;
                currentContact.Icon = indexContact.Icon;
                currentContact.Name = indexContact.Name;
                currentContact.Email = indexContact.Email;
                currentContact.Login = indexContact.Login;
                currentContact.Password = indexContact.Password;
                currentContact.Website = indexContact.Website;
                currentContact.Notes = indexContact.Notes;
            }
        }

        private void updateListItem(object sender, PropertyChangedEventArgs e)
        {
            var index = accListBox.SelectedIndex;
            switch (e.PropertyName)
            {
                case "Icon":
                    contacts[index].Icon = currentContact.Icon;
                    break;
                case "Name":
                    contacts[index].Name = currentContact.Name;
                    break;
                case "Email":
                    contacts[index].Email = currentContact.Email;
                    break;
                case "Login":
                    contacts[index].Login = currentContact.Login;
                    break;
                case "Password":
                    contacts[index].Password = currentContact.Password;
                    break;
                case "Website":
                    contacts[index].Website = currentContact.Website;
                    break;
                case "Notes":
                    contacts[index].Notes = currentContact.Notes;
                    break;
                default:
                    break;
            }
        }
    }
}