using Facebook.UserControls;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Facebook
{
    /// <summary>
    /// Logique d'interaction pour Wall.xaml
    /// </summary>
    public partial class MainWall : Window
    {
        private Dictionary<string, User> userDictionnary = App.Current.Users;
        private Dictionary<int, Post> postDictionnary = App.Current.Posts;
        private List<UserControlPost> postsUserControls = new List<UserControlPost>();
        public MainWall()
        {
            InitializeComponent();
            foreach (var user in userDictionnary.Values)
            {
                ComboBoxLogged.Items.Add(user);
            }
            ComboBoxLogged.SelectedIndex = 0;

            loadUser((User)ComboBoxLogged.SelectedItem);

            loadPosts();
        }

        public void loadUser(User currentUser)
        {
            loggedUserImage.Source = new BitmapImage(currentUser.ProfileSrc);
            loggedUserName.Content = $"{currentUser.FirstName} {currentUser.LastName}";
            debugTitle.Text = loggedUserImage.Source.ToString();

            userFriends.Items.Clear();
            ComboBoxPostOf.Items.Clear();

            if (currentUser.FriendsEmails != null)
            {
                foreach (string friendEmail in currentUser.FriendsEmails)
                {
                    User friend;
                    userDictionnary.TryGetValue(friendEmail, out friend);

                    if (friend != null)
                        userFriends.Items.Add(friend.ToString());
                }
            }

            ComboBoxPostOf.Items.Add("All users");
            ComboBoxPostOf.Items.Add("Friends");

            foreach (User user in userDictionnary.Values)
                ComboBoxPostOf.Items.Add(user.ToString());

            ComboBoxPostOf.SelectedIndex = 0;
        }

        public void loadPosts()
        {
            List<Post> postsToShow = new List<Post>();
            postsUserControls.Clear();
            WrapPanelPosts.Children.Clear();

            if (RadioButtonDate.IsChecked == true)
                postsToShow = postDictionnary.Values.OrderBy(post => post.Date).ToList();
            else
                postsToShow = postDictionnary.Values.OrderBy(post => post.Popularity).ToList();

            foreach (var post in postDictionnary.Values)
            {
                var userControlPost = new UserControlPost(post, this);

                userControlPost.Width = WrapPanelPosts.Width;
                userControlPost.Margin = new Thickness(3);

                // User infos
                userControlPost.userName.Content = $"{post.OwnerUser.FirstName} {post.OwnerUser.LastName}";
                userControlPost.userImage.Source = new BitmapImage(post.OwnerUser.ProfileSrc);

                // Days
                userControlPost.daysSincePost.Content = (int)(DateTime.Today - post.Date).TotalDays + " days ago";

                // Reactions
                userControlPost.postLikes.Content = post.ReactionsAuPost.AmountOfLikes;
                userControlPost.postLove.Content = post.ReactionsAuPost.AmountOfLove;
                userControlPost.postAngry.Content = post.ReactionsAuPost.AmountOfAngry;
                userControlPost.postSad.Content = post.ReactionsAuPost.AmountOfSad;

                // Post infos
                userControlPost.postPicture.Source = new BitmapImage(post.Image);
                userControlPost.postTitle.Content = post.Title;
                userControlPost.postDateTime.Content = post.Date.ToString("f", CultureInfo.GetCultureInfo("fr-FR"));
                userControlPost.postDescription.Text = post.Description;

                WrapPanelPosts.Children.Add(userControlPost);
                postsUserControls.Add(userControlPost);
            }
        }


        // Ca marche pas encore ? 
        private void ComboBoxLogged_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            loadUser((User)((ComboBox)sender).SelectedItem);
        }

        private void changeOrder(object sender, RoutedEventArgs e)
        {
            loadPosts();
        }
    }
}