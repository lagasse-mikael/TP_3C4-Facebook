using Facebook.UserControls;
using System;
using System.Collections.Generic;
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
        public MainWall()
        {
            InitializeComponent();
            ComboBoxPostOf.Items.Add("All users");
            ComboBoxPostOf.Items.Add("Friends");

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

            ComboBoxPostOf.Items.Add("All users");
            if (currentUser.FriendsEmails != null)
            {
                ComboBoxPostOf.Items.Add("Friends");

                foreach (string friendEmail in currentUser.FriendsEmails)
                {
                    User friend;
                    userDictionnary.TryGetValue(friendEmail, out friend);

                    if (friend != null)
                        userFriends.Items.Add(friend.ToString());
                }
            }

            foreach (User user in userDictionnary.Values)
                ComboBoxPostOf.Items.Add(user.ToString());
        }

        public void loadPosts()
        {
            WrapPanelPosts.Children.Clear();
            

            foreach (var post in postDictionnary.Values)
            {
                var userControlPost = new UserControlPost(post, this);

                userControlPost.Width = WrapPanelPosts.Width;
                userControlPost.Margin = new Thickness(3);

                userControlPost.postDescription.Text = post.Description;
                //TODO : Reste des elements par rapport a un post et a l'user qui lui est attribuer.

                WrapPanelPosts.Children.Add(userControlPost);
            }
        }

        private void ComboBoxLogged_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            loadUser((User)((ComboBox)sender).SelectedItem);
        }
    }
}