using LibaryApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibaryApp.ViewModels
{
    internal class Database
    {
        public List<User> Users = new List<User>()
        {
            new User(0, "Miha", "Pupkin", new(){12, 20}),
            new User(1, "Vasya", "Ivanov", new()),
            new User(2, "Nekit", "Kashin", new()),
            new User(2, "Dima", "Andreev", new()),
            new User(2, "Vsevolod", "Keshin", new()),
        };
        public List<Book> Books = new List<Book>()
        {
            new Book(12, "Pushkin", "Onegin", new(1921, 2, 1), 5),
            new Book(20, "Gogol", "Something", new(1913, 1, 12), 15),
            new Book(13, "Oleg", "Good book", new(2021, 12, 1), 5),
            new Book(1, "Dimitry", "Anything", new(2021, 12, 1), 5),
            new Book(33, "Roaling", "Harry Potter", new(2021, 12, 1), 5),
        };
    }
}
