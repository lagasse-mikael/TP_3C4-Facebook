using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Facebook
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static new App Current { get { return Application.Current as App; } }

        public Dictionary<string, User> Users { get { return _users; } }
        private Dictionary<string, User> _users = new Dictionary<string, User>()
        {
            {"tom@mail.com",new User(){FirstName="Tom",LastName="Richards",Email="tom@mail.com",Password="passtom",ProfileSrc=new Uri("./Users/user1.jpg",UriKind.Relative),FriendsEmails={ "elliot@mail.com", "rachel@mail.com", "myriam@mail.com" } } },
            {"elliot@mail.com",new User(){FirstName="Elliot",LastName="Hart",Email="elliot@mail.com",Password="passelliot",ProfileSrc=new Uri("./Users/user2.jpg",UriKind.Relative),FriendsEmails={ "tom@mail.com", "rachel@mail.com"}} },
            {"rachel@mail.com",new User(){FirstName="Rachel",LastName="Chapman",Email="rachel@mail.com",Password="passrachel",ProfileSrc=new Uri("./Users/user3.jpg",UriKind.Relative),FriendsEmails={ "tom@mail.com", "myriam@mail.com" } } },
            {"myriam@mail.com",new User(){FirstName="Myriam",LastName="Leblanc",Email="myriam@mail.com",Password="passmyriam",ProfileSrc=new Uri("./Users/user4.jpg",UriKind.Relative),FriendsEmails={ "tom@mail.com", "rachel@mail.com" } } },
            {"paul@mail.com",new User(){FirstName="Paul",LastName="Burnham",Email="paul@mail.com",Password="passpaul",ProfileSrc=new Uri("./Users/user5.jpg",UriKind.Relative)} }
        };

    }
}
