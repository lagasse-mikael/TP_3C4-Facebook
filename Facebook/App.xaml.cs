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
            {"tom@mail.com",new User(){FirstName="Tom",LastName="Richards",Email="tom@mail.com",Password="passtom",ProfileSrc=new Uri("../Assets/Users/user1.jpg",UriKind.Relative),FriendsEmails=new List<string>{ "elliot@mail.com", "rachel@mail.com", "myriam@mail.com" } } },
            {"elliot@mail.com",new User(){FirstName="Elliot",LastName="Hart",Email="elliot@mail.com",Password="passelliot",ProfileSrc=new Uri("../Assets/Users/user2.jpg",UriKind.Relative),FriendsEmails=new List<string>{ "tom@mail.com", "rachel@mail.com"}} },
            {"rachel@mail.com",new User(){FirstName="Rachel",LastName="Chapman",Email="rachel@mail.com",Password="passrachel",ProfileSrc=new Uri("../Assets/Users/user3.jpg",UriKind.Relative),FriendsEmails=new List<string>{ "tom@mail.com", "myriam@mail.com" } } },
            {"myriam@mail.com",new User(){FirstName="Myriam",LastName="Leblanc",Email="myriam@mail.com",Password="passmyriam",ProfileSrc=new Uri("../Assets/Users/user4.jpg",UriKind.Relative),FriendsEmails=new List<string>{ "tom@mail.com", "rachel@mail.com" } } },
            {"paul@mail.com",new User(){FirstName="Paul",LastName="Burnham",Email="paul@mail.com",Password="passpaul",ProfileSrc=new Uri("../Assets/Users/user5.jpg",UriKind.Relative)} }
        };

        public Dictionary<int, Post> Posts { get { return _posts; } }
        private Dictionary<int, Post> _posts = new Dictionary<int, Post>()
        {
            {1,new Post(){OwnerEmail="tom@mail.com",Title="Nice snack with a book",Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras id consectetur quam. Nam rutrum non dui et feugiat" +
                ". Morbi a mattis leo. Phasellus efficitur nulla dignissim ipsum commodo, in maximus leo dignissim. Donec venenatis posuere justo quis pulvinar. Etiam eu neque nibh. Vivamus egestas sollicitudin dictum. Nunc tempus orci" +
                " vel enim facilisis, sit amet rhoncus mi bibendum. Donec vel venenatis orci. Fusce ultricies libero id nulla dignissim, non molestie nunc placerat. Vestibulum hendrerit mi aliquet ante feugiat, a semper augue volutpat." +
                " Aenean leo est, sagittis non enim quis, aliquam vestibulum odio. Sed et suscipit orci.",Image=new Uri("../Assets/Posts/post1.jpg",UriKind.Relative),Date=new DateTime(2021,11,20,7,00,00),Visibility=VisibilityPost.Public,ReactionsAuPost=new Reactions()}},
            {2,new Post(){OwnerEmail="elliot@mail.com",Title="Relaxing night at the beach",Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras id consectetur quam. Nam rutrum non dui et feugiat" +
                ". Morbi a mattis leo. Phasellus efficitur nulla dignissim ipsum commodo, in maximus leo dignissim. Donec venenatis posuere justo quis pulvinar. Etiam eu neque nibh. Vivamus egestas sollicitudin dictum. Nunc tempus orci" +
                " vel enim facilisis, sit amet rhoncus mi bibendum. Donec vel venenatis orci. Fusce ultricies libero id nulla dignissim, non molestie nunc placerat. Vestibulum hendrerit mi aliquet ante feugiat, a semper augue volutpat." +
                " Aenean leo est, sagittis non enim quis, aliquam vestibulum odio. Sed et suscipit orci.",Image=new Uri("../Assets/Posts/post2.jpg",UriKind.Relative),Date=new DateTime(2021,11,21,10,30,00),Visibility=VisibilityPost.Public,ReactionsAuPost=new Reactions(){AmountOfLikes=1 }}},
            {3,new Post(){OwnerEmail="rachel@mail.com",Title="Trekking in the woods",Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras id consectetur quam. Nam rutrum non dui et feugiat" +
                ". Morbi a mattis leo. Phasellus efficitur nulla dignissim ipsum commodo, in maximus leo dignissim. Donec venenatis posuere justo quis pulvinar. Etiam eu neque nibh. Vivamus egestas sollicitudin dictum. Nunc tempus orci" +
                " vel enim facilisis, sit amet rhoncus mi bibendum. Donec vel venenatis orci. Fusce ultricies libero id nulla dignissim, non molestie nunc placerat. Vestibulum hendrerit mi aliquet ante feugiat, a semper augue volutpat." +
                " Aenean leo est, sagittis non enim quis, aliquam vestibulum odio. Sed et suscipit orci.",Image=new Uri("../Assets/Posts/post3.jpg",UriKind.Relative),Date=new DateTime(2021,11,22,16,30,00),Visibility=VisibilityPost.Public,ReactionsAuPost=new Reactions(){AmountOfLove=1 }}},
            {4,new Post(){OwnerEmail="myriam@mail.com",Title="King of the world!",Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras id consectetur quam. Nam rutrum non dui et feugiat" +
                ". Morbi a mattis leo. Phasellus efficitur nulla dignissim ipsum commodo, in maximus leo dignissim. Donec venenatis posuere justo quis pulvinar. Etiam eu neque nibh. Vivamus egestas sollicitudin dictum. Nunc tempus orci" +
                " vel enim facilisis, sit amet rhoncus mi bibendum. Donec vel venenatis orci. Fusce ultricies libero id nulla dignissim, non molestie nunc placerat. Vestibulum hendrerit mi aliquet ante feugiat, a semper augue volutpat." +
                " Aenean leo est, sagittis non enim quis, aliquam vestibulum odio. Sed et suscipit orci.",Image=new Uri("../Assets/Posts/post4.jpg",UriKind.Relative),Date=new DateTime(2021,11,23,21,00,00),Visibility=VisibilityPost.Public,ReactionsAuPost=new Reactions(){AmountOfSad=1,AmountOfAngry=1 }}},
            {5,new Post(){OwnerEmail="paul@mail.com",Title="After work",Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras id consectetur quam. Nam rutrum non dui et feugiat" +
                ". Morbi a mattis leo. Phasellus efficitur nulla dignissim ipsum commodo, in maximus leo dignissim. Donec venenatis posuere justo quis pulvinar. Etiam eu neque nibh. Vivamus egestas sollicitudin dictum. Nunc tempus orci" +
                " vel enim facilisis, sit amet rhoncus mi bibendum. Donec vel venenatis orci. Fusce ultricies libero id nulla dignissim, non molestie nunc placerat. Vestibulum hendrerit mi aliquet ante feugiat, a semper augue volutpat." +
                " Aenean leo est, sagittis non enim quis, aliquam vestibulum odio. Sed et suscipit orci.",Image=new Uri("../Assets/Posts/post5.jpg",UriKind.Relative),Date=new DateTime(2021,11,24,12,00,00),Visibility=VisibilityPost.Public,ReactionsAuPost=new Reactions()}},
            {6,new Post(){OwnerEmail="tom@mail.com",Title="New Zealand 2017",Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras id consectetur quam. Nam rutrum non dui et feugiat" +
                ". Morbi a mattis leo. Phasellus efficitur nulla dignissim ipsum commodo, in maximus leo dignissim. Donec venenatis posuere justo quis pulvinar. Etiam eu neque nibh. Vivamus egestas sollicitudin dictum. Nunc tempus orci" +
                " vel enim facilisis, sit amet rhoncus mi bibendum. Donec vel venenatis orci. Fusce ultricies libero id nulla dignissim, non molestie nunc placerat. Vestibulum hendrerit mi aliquet ante feugiat, a semper augue volutpat." +
                " Aenean leo est, sagittis non enim quis, aliquam vestibulum odio. Sed et suscipit orci.",Image=new Uri("../Assets/Posts/post6.jpg",UriKind.Relative),Date=new DateTime(2021,11,25,01,00,00),Visibility=VisibilityPost.FriendsOnly,ReactionsAuPost=new Reactions(){AmountOfLove=1}} },
            {7,new Post(){OwnerEmail="tom@mail.com",Title="Sweden 2018",Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras id consectetur quam. Nam rutrum non dui et feugiat" +
                ". Morbi a mattis leo. Phasellus efficitur nulla dignissim ipsum commodo, in maximus leo dignissim. Donec venenatis posuere justo quis pulvinar. Etiam eu neque nibh. Vivamus egestas sollicitudin dictum. Nunc tempus orci" +
                " vel enim facilisis, sit amet rhoncus mi bibendum. Donec vel venenatis orci. Fusce ultricies libero id nulla dignissim, non molestie nunc placerat. Vestibulum hendrerit mi aliquet ante feugiat, a semper augue volutpat." +
                " Aenean leo est, sagittis non enim quis, aliquam vestibulum odio. Sed et suscipit orci.",Image=new Uri("../Assets/Posts/post7.jpg",UriKind.Relative),Date=new DateTime(2021,11,26,09,00,00),Visibility=VisibilityPost.FriendsExcept,TargetEmail=new List<string>{"rachel@mail.com" },ReactionsAuPost=new Reactions(){AmountOfSad=0}} },
            {8,new Post(){OwnerEmail="tom@mail.com",Title="Internet cafe Sundays",Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras id consectetur quam. Nam rutrum non dui et feugiat" +
                ". Morbi a mattis leo. Phasellus efficitur nulla dignissim ipsum commodo, in maximus leo dignissim. Donec venenatis posuere justo quis pulvinar. Etiam eu neque nibh. Vivamus egestas sollicitudin dictum. Nunc tempus orci" +
                " vel enim facilisis, sit amet rhoncus mi bibendum. Donec vel venenatis orci. Fusce ultricies libero id nulla dignissim, non molestie nunc placerat. Vestibulum hendrerit mi aliquet ante feugiat, a semper augue volutpat." +
                " Aenean leo est, sagittis non enim quis, aliquam vestibulum odio. Sed et suscipit orci.",Image=new Uri("../Assets/Posts/post8.jpg",UriKind.Relative),Date=new DateTime(2021,11,27,11,30,00),Visibility=VisibilityPost.SpecificFriends,TargetEmail=new List<string>{"rachel@mail.com" },ReactionsAuPost=new Reactions()} },
            {9,new Post(){OwnerEmail="elliot@mail.com",Title="Surprise!",Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras id consectetur quam. Nam rutrum non dui et feugiat" +
                ". Morbi a mattis leo. Phasellus efficitur nulla dignissim ipsum commodo, in maximus leo dignissim. Donec venenatis posuere justo quis pulvinar. Etiam eu neque nibh. Vivamus egestas sollicitudin dictum. Nunc tempus orci" +
                " vel enim facilisis, sit amet rhoncus mi bibendum. Donec vel venenatis orci. Fusce ultricies libero id nulla dignissim, non molestie nunc placerat. Vestibulum hendrerit mi aliquet ante feugiat, a semper augue volutpat." +
                " Aenean leo est, sagittis non enim quis, aliquam vestibulum odio. Sed et suscipit orci.",Image=new Uri("../Assets/Posts/post9.jpg",UriKind.Relative),Date=new DateTime(2021,11,28,14,30,00),Visibility=VisibilityPost.FriendsOnly,ReactionsAuPost=new Reactions(){AmountOfLikes=2} } },
            {10,new Post(){OwnerEmail="elliot@mail.com",Title="Secret painting",Description="Lorem ipsum dolor sit amet, consectetur adipiscing elit. Cras id consectetur quam. Nam rutrum non dui et feugiat" +
                ". Morbi a mattis leo. Phasellus efficitur nulla dignissim ipsum commodo, in maximus leo dignissim. Donec venenatis posuere justo quis pulvinar. Etiam eu neque nibh. Vivamus egestas sollicitudin dictum. Nunc tempus orci" +
                " vel enim facilisis, sit amet rhoncus mi bibendum. Donec vel venenatis orci. Fusce ultricies libero id nulla dignissim, non molestie nunc placerat. Vestibulum hendrerit mi aliquet ante feugiat, a semper augue volutpat." +
                " Aenean leo est, sagittis non enim quis, aliquam vestibulum odio. Sed et suscipit orci.",Image=new Uri("../Assets/Posts/post10.jpg",UriKind.Relative),Date=new DateTime(2021,11,29,17,30,00),Visibility=VisibilityPost.OnlyMe,ReactionsAuPost=new Reactions(){AmountOfSad=1 } } }
        };
    }
}
