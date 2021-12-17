using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook
{
    public class Group
    {
        private List<GroupAdmin> _admins = new List<GroupAdmin>();
        public List<GroupAdmin> Admins
        {
            get { return _admins; }
        }
        public List<User> Users { get; init; }
        public string Name { get; init; }
        public string Description { get; init; }
        public Uri Image { get; init; }
        public Wall GroupWall { get; init; }

        public List<Event> Events { get; private set; }

        public void AddAdmin(User user)
        {
            this.Admins.Add(new GroupAdmin(user,this));
        }

        public IEnumerable<Post> PostsByDate()
        {
            return this.GroupWall.Posts.OrderBy(post => post.Date);
        }
    }
}
