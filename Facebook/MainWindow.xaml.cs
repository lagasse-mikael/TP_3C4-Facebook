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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Facebook
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private User user = new User
        {
            FirstName = "Mikael",
            LastName = "Lagasse",
            Email = "2068410@cstj.qc.ca",
            Password = "123123",
            ProfileSrc = new Uri("./Images/profile.png",UriKind.Relative),
            BannerSrc = new Uri("./Images/banner.png", UriKind.Relative)
        };
        public MainWindow()
        {
            InitializeComponent();

            profile.Source = new BitmapImage(user.ProfileSrc);
            banner.Source = new BitmapImage(user.BannerSrc);
            currentUser.Text = user.ToString();

            windowText.Text = "Hello World!";
        }
    }
}
