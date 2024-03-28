using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FicBook.Model
{
    public class User
    {
        ObservableCollection<Fanfic> defaultFics = new ObservableCollection<Fanfic>();
        public User(string username, string password) {
            Username = username;
            Password = password;
            MyFics = defaultFics;
            Liked = defaultFics;
        }
        public User() { }
        public string Username {  get; set; }
        public string Password { get; set; }
        public ObservableCollection<Fanfic> MyFics { get; set; }
        public ObservableCollection<Fanfic> Liked {  get; set; }
    }
}
