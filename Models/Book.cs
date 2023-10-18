using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryApp.Models
{
    internal class Book : NotifyProperty
    {
        short art;
        string author;
        string name;
        DateTime age;
        int count;

        public Book(short art, string author, string name, DateTime age, int count)
        {
            Art = art;
            Author = author;
            Name = name;
            Age = age;
            Count = count;
        }

        public short Art
        {
            get { return art; }
            set { 
                art = value;
                OnPropertyChanged(nameof(Art));
            }
        }
        public string Author
        {
            get => author;
            set
            {
                author = value;
                OnPropertyChanged(nameof(Author));
            }
        }
        public string Name
        {
            get => name;
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public DateTime Age
        {
            get => age; 
            set
            {
                age = value;
                OnPropertyChanged(nameof(Age));
            }
        }
        public int Count
        {
            get => count;
            set { 
                count = value;
                OnPropertyChanged(nameof(Count));
            }
        }
    }
}
