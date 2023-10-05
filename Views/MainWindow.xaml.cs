using LibaryApp.Models;
using LibaryApp.ViewModels;
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

namespace LibaryApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ViewModels.MainWindow View = new();
        public MainWindow()
        {
            InitializeComponent();
            BooksListView.ItemsSource = View.UpdateBooks();
            UsersListView.ItemsSource = View.UpdateUsers();
        }

        private void BooksListView_SelectionChanged(object sender, SelectionChangedEventArgs e) {}
        private void UserBooksListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserBooksListView.ItemsSource =  View.UpdateUserBooks(UsersListView.SelectedItem as User);
            BooksListView.Items.Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var res = View.AddBook(BooksListView.SelectedItem as Book, UsersListView.SelectedItem as User);
            if (res != null) UserBooksListView.ItemsSource = res;
            BooksListView.Items.Refresh();
        }

        private void UserName_TextChanged(object sender, TextChangedEventArgs e)
        {
            UsersListView.ItemsSource = View.UpdateUsers(UserName.Text);
        }

        private void BookName_TextChanged(object sender, TextChangedEventArgs e)
        {
            BooksListView.ItemsSource = View.UpdateBooks(BookName.Text);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var res = View.ReturnBook(UserBooksListView.SelectedItem as Book, UsersListView.SelectedItem as User);
            if (res != null) UserBooksListView.ItemsSource = res;
            BooksListView.Items.Refresh();

        }
    }
}
