using LibaryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryApp.ViewModels
{
    internal class MainWindow
    {
        Database Data = new();
        public List<User> UpdateUsers(string search = "")
        {
            if (search == "") return Data.Users;
            var users = new List<User>();
            foreach (User user in Data.Users)
                if (user.Name.Contains(search) | user.Famaly.Contains(search))
                    users.Add(user);
            return users;
        }
        public List<Book> UpdateUserBooks(User user)
        {
            var books = new List<Book>();
            if (user == null)
                return new();

            foreach (short i in user.BookList)
                foreach (Book book in Data.Books)
                    if (book.Art == i)
                        books.Add(book);
            return books;
        }
        public List<Book> UpdateBooks(string search = "")
        {
            if (search == "") return Data.Books;
            var books = new List<Book>();
            foreach (var book in Data.Books)
                if (book.Name.Contains(search) | book.Author.Contains(search))
                    books.Add(book);
            return books;
        }
        public List<Book> AddBook(Book book, User user)
        {
            if (book == null || user == null || book.Count<=0)
                return null;

            user.BookList.Add(book.Art);
            book.Count--;
            return UpdateUserBooks(user);

        }
        public List<Book> ReturnBook(Book book, User user)
        {
            if (book == null | user == null)
                return null;

            user.BookList.Remove(book.Art);
            book.Count++;
            return UpdateUserBooks(user);

        }
    }

}
