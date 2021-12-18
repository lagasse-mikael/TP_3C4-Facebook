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

namespace Facebook.UserControls
{
    /// <summary>
    /// Interaction logic for UserControlPost.xaml
    /// </summary>
    public partial class UserControlPost : UserControl
    {
        public Post currentPost;
        public MainWall currentWall;
        public UserControlPost(Post postToShow, MainWall mainWall)
        {
            InitializeComponent();

            currentPost = postToShow;
            currentWall = mainWall;
        }
    }
}
