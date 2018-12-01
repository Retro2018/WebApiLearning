using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServiceUser_WebAPI_.Models
{
    public class User
    {
        public int Id { set; get; }
        public string Name { set; get; }
        public string Surname { set; get; }
        public int Age { set; get; }
        public User(int id, string name, string surname, int age)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Age = age;
        }
    }
}