using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceUser_WebAPI_.Models;

namespace ServiceUser_WebAPI_.Models
{
    public class Repository
    {
        List<User> users = new List<User>();
        public IEnumerable<User> GetUsers()
        {
            ReadFromFile();
            return users;
        }

        public void AddUser(User user)
        {
            users.Add(user);
            WriteToFile(false, users.Count() - 1);
        }

        public void UpdateUser(int id, User user)
        {
            ReadFromFile();
            if (users.Exists(u => u.Id == id))
            {
                int index = users.FindIndex(u => u.Id == id);
                users[index] = user;
                WriteToFile(true, index);
            }
            else throw new Exception("Not found item with this index " + id.ToString());
        }

        public void DeleteUser(int id)
        {
            ReadFromFile();
            if (users.Exists(user => user.Id == id))
            {
                users.Remove(users.Find(user => user.Id == id));
                WriteToFile(true);
            }
            else throw new Exception("Not found item with this index " + id.ToString());
        }

        private void WriteToFile(bool rewrite, int id = 0)
        {
            string text = null;
            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(@"C:\Users\Владимир Кущев\source\repos\ServiceUser(WebAPI)\ServiceUser(WebAPI)\Content\SavedUser.txt", !rewrite))
            {
                if (rewrite)
                {
                    foreach (User user in users)
                    {
                        text = user.Id + " " + user.Name + " " + user.Surname + " " + user.Age.ToString();
                        file.WriteLine(text);
                    }
                }
                else
                {
                    text = users[id].Id + " " + users[id].Name + " " + users[id].Surname + " " + users[id].Age.ToString();
                    file.WriteLine(text);
                }
               
            }
        }
        private void ReadFromFile()
        {
            string[] text = System.IO.File.ReadAllLines(@"C:\Users\Владимир Кущев\source\repos\ServiceUser(WebAPI)\ServiceUser(WebAPI)\Content\SavedUser.txt");
            int age, id;
            foreach (string line in text)
            {
                string[] user = line.Split(' ');
                Int32.TryParse(user[0], out id);
                Int32.TryParse(user[3], out age);
                users.Add(new User(id, user[1], user[2], age));
            }
        }
    }
}