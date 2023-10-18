using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryApp.Models
{
    internal class User : NotifyProperty
    {
        int id;
        string name;
        string surname;
        ObservableCollection<Book> books;

        public User(int id, string name, string surname, ObservableCollection<Book> books)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Books = books;
        }

        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged(nameof(Id));
            }
        }
        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Surname
        {
            get { return surname; }
            set
            {
                surname = value;
                OnPropertyChanged(nameof(Surname));
            }
        }
        public ObservableCollection<Book> Books
        {
            get { return books; }
            set
            {
                books = value;
                OnPropertyChanged(nameof(Books));
            }
        }
    }
}
