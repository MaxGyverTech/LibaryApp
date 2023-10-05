using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryApp.Models
{
    internal class Book
    {
        public short Art {  get; set; }
        public string Author { get; set; }
        public string Name { get; set; }
        public DateTime Age { get; set; }
        public int Count { get; set; }

        public Book(short art, string author, string name, DateTime age, int count)
        {
            Art = art;
            Author = author;
            Name = name;
            Age = age;
            Count = count;
        }
    }
}
