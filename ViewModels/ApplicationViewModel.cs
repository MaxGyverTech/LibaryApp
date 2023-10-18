using LibaryApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LibaryApp.ViewModels
{
    internal class ApplicationViewModel : NotifyProperty
    {
        private User selectedUser;
        private Book selectedBook;
        private Book selectedUserBook;
        private string userSearchText;
        private string bookSearchText;

        public ObservableCollection<Book> Books { get; set; }
        public ObservableCollection<User> Users { get; set; }


        public User SelectedUser
        {
            get { return  selectedUser;  }
            set
            {
                selectedUser = value;
                OnPropertyChanged(nameof(SelectedUser));
            }
        }
        public Book SelectedBook
        {
            get { return selectedBook; }
            set
            {
                selectedBook = value;
                OnPropertyChanged(nameof(SelectedBook));
            }
        }
        public Book SelectedUserBook
        {
            get { return selectedUserBook; }
            set
            {
                selectedUserBook = value;
                OnPropertyChanged(nameof(SelectedUserBook));
            }
        }
        public string UserSearchText
        {
            get { return userSearchText; }
            set
            {
                userSearchText = value;
                OnPropertyChanged(nameof(UserSearchText));
                OnPropertyChanged(nameof(FilteredUsers));
            }
        }
        public ObservableCollection<User> FilteredUsers
        {
            get
            {
                if (userSearchText == null)
                    return Users;
                return new(Users.Where(x => x.Name.Contains(userSearchText, StringComparison.OrdinalIgnoreCase) || x.Surname.Contains(userSearchText, StringComparison.OrdinalIgnoreCase)));
            }
        }
        public string BookSearchText
        {
            get { return bookSearchText; }
            set
            {
                bookSearchText = value;
                OnPropertyChanged(nameof(BookSearchText));
                OnPropertyChanged(nameof(FilteredBooks));
            }
        }
        public ObservableCollection<Book> FilteredBooks
        {
            get
            {
                if (bookSearchText == null)
                    return Books;
                return new(Books.Where(x => x.Name.Contains(bookSearchText, StringComparison.OrdinalIgnoreCase) || x.Author.Contains(bookSearchText, StringComparison.OrdinalIgnoreCase) || x.Art.ToString().Contains(bookSearchText, StringComparison.OrdinalIgnoreCase)));
            }
        }



        private RelayCommand addCommand;
        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ?? (addCommand = new RelayCommand(obj =>
                {
                    selectedBook.Count--;
                    selectedUser.Books.Add(selectedBook);
                    var res = "";
                    foreach (var i in selectedUser.Books)
                        res += i.Name + ", ";
                    //MessageBox.Show(res);
                }, 
                (obj) => selectedBook!=null && selectedUser!=null && selectedBook.Count>0));
            }
        }
        private RelayCommand removeCommand;
        public RelayCommand RemoveCommand
        {
            get
            {
                return removeCommand ??
                  (removeCommand = new RelayCommand(obj =>
                  {
                      selectedUserBook.Count++;
                      selectedUser.Books.Remove(selectedUserBook);
                  },
                 (obj) => selectedUser!=null && selectedUserBook!=null));
            }
        }
       
        public ApplicationViewModel()
        {
            Books = new()
            {
                new Book(123, "Pushkin", "Onegin", new(1921, 1, 3), 5),
                new Book(456, "Tolstoy", "War and Peace", new DateTime(1869, 1, 20), 3),
                new Book(789, "Dostoevsky", "Crime and Punishment", new DateTime(1866, 1, 1), 2),
                new Book(101, "Gogol", "Dead Souls", new DateTime(1842, 2, 1), 4),
                new Book(111, "Chekhov", "Three Sisters", new DateTime(1901, 1, 31), 6),
                new Book(222, "Turgenev", "Fathers and Sons", new DateTime(1862, 6, 1), 1),
                new Book(333, "Goncharov", "Oblomov", new DateTime(1859, 1, 15), 7)
            };
            Users = new() {
                new User(1, "Vanya", "Petrov", new() { Books[2], Books[6], Books[0] }),
                new User(2, "Petr", "Ivanov", new()),
                new User(3, "Kira", "Shmelenko", new()  { Books[1], Books[4] }),
                new User(4, "Max", "Sidorov", new()),
            };
        }
    }
}
