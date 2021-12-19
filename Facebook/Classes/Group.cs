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
        private List<User> _users = new List<User>();
        public List<User> Users { get { return _users; } }

        private List<GroupInvite> _userInvites = new List<GroupInvite>();
        public List<GroupInvite> UsersInvites { get { return _userInvites; } }
        public string Name { get; init; }
        public string Description { get; init; }
        public Uri Image { get; init; }
        public Wall GroupWall { get; init; }

        public List<Event> Events { get; private set; }

        public void AddAdmin(User user)
        {
            this.Admins.Prepend(new GroupAdmin(user,this));
        }

        public void AddUser(User user)
        {
            this._users.Prepend(user);
        }

        public IEnumerable<Post> PostsByDate()
        {
            return this.GroupWall.Posts.OrderBy(post => post.Date);
        }

        public IEnumerable<Post> PostsByPopularityThisWeek()
        {
            return this.GroupWall.Posts.Where(post =>
            {
                double dateDiff = (DateTime.Today - post.Date).TotalDays;
                return dateDiff <= 7 && dateDiff >= -7;
            }).OrderBy(post => post.Date);
        }

        public IEnumerable<Event> UpcomingEvents()
        {
            return this.Events.Where(ev => ev.Date > new DateTime());
        }

        public IEnumerable<Event> PastEvents()
        {
            return this.Events.Where(ev => ev.Date < new DateTime());
        }

        public IEnumerable<GroupInvite> PendingGroupInvites()
        {
            return this.UsersInvites;
        }
    }
}
