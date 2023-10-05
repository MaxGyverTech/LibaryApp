using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryApp.Models
{
    internal class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Famaly { get; set; }
        public List<short> BookList { get; set; }

        public User(int id, string name, string famaly, List<short> bookList)
        {
            Id = id;
            Name = name;
            Famaly = famaly;
            BookList = bookList;
        }
    }
}
