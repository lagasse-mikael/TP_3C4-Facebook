using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Facebook
{
    public enum Interests
    {
        Interested,
        Going
    }
    public class User
    {
        public string LastName { get; init; }
        public string FirstName { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }

        public Uri ProfileSrc { get; init; }
        public Uri BannerSrc { get; init; }

        public List<string> FriendsEmails { get; init; }

        // Liste des Friend Requests recues , qui n'ont pas encore ete repondues.
        private List<FriendRequest> _pendingFriendRequests = new List<FriendRequest>();
        public List<FriendRequest> PendingFriendRequests
        {
            get { return _pendingFriendRequests; }
        }

        // Liste des Friend Requests qui ont ete envoyer / pas encore repondu.
        public List<FriendRequest> _sentfriendrequests = new List<FriendRequest>();
        public List<FriendRequest> SentFriendRequests
        {
            get { return _sentfriendrequests; }
        }

        // Events auxquels ont demontre un certain interet
        private Dictionary<Event, Interests> _interetsEvents = new Dictionary<Event, Interests>();
        public Dictionary<Event, Interests> InteretsEvents { get { return _interetsEvents; } }

        private List<Group> _groups = new List<Group>();
        public List<Group> Groups
        {
            get
            {
                return _groups;
            }
        }

        public List<GroupInvite> _sentGroupInvites = new List<GroupInvite>();
        public List<GroupInvite> SentGroupInvites
        {
            get { return _sentGroupInvites; }
        }

        public void CreateGroup(Group createdGroup)
        {
            this._groups.Prepend(createdGroup);
            createdGroup.AddAdmin(this);
        }

        public void SendInviteToGroup(Group groupToSendInviteTo)
        {
            GroupInvite generatedGroupInvite = new GroupInvite() { UserWaiting = this, GroupToJoin = groupToSendInviteTo };
            groupToSendInviteTo.UsersInvites.Prepend(generatedGroupInvite);
            _sentGroupInvites.Prepend(generatedGroupInvite);
        }

        public IEnumerable<Group> GroupsIAdministrate()
        {
            // C'est claire qu'il y a une maniere plus simple de faire ca..
            return this.Groups.Where(group => group.Admins.Count(admin => admin.UserAssociated == this) > 0);
        }

        public Wall UserWall { get; init; }

        public IEnumerable<Post> PostsFromCertainUser(string userEmail)
        {
            return App.Current.Users.Values.First(user => user.Email == userEmail).UserWall.PostsByDate();
        }

        public IEnumerable<Post> PostsFromCertainUserByPopularity(string userEmail)
        {
            return App.Current.Users.Values.First(user => user.Email == userEmail).UserWall.PostsByPopularity();
        }

        public IEnumerable<Post> PostsFromFriendsAndGroupsThisWeek()
        {
            IEnumerable<Post> postsFetched = new List<Post>();

            foreach (var email in FriendsEmails)
            {
                User friend;
                App.Current.Users.TryGetValue(email, out friend);

                if (friend != null)
                {
                    foreach (var post in friend.UserWall.Posts)
                    {
                        postsFetched.Prepend(post);
                    }
                }
            }

            foreach (var group in this.Groups)
            {
                foreach (var post in group.GroupWall.Posts)
                {
                    postsFetched.Prepend(post);
                }
            }

            return postsFetched.Where(post =>
            {
                double dateDiff = (post.Date - new DateTime()).TotalDays;
                return dateDiff <= 7 && dateDiff >= -7;
            });
        }
        public IEnumerable<Post> PostsFromFriendsAndGroupsThisWeekByDate()
        {
            return this.PostsFromFriendsAndGroupsThisWeek().OrderBy(post => post.Date);
        }
        public IEnumerable<Post> PostsFromFriendsAndGroupsThisWeekByPopularity()
        {
            return this.PostsFromFriendsAndGroupsThisWeek().OrderBy(post => post.Popularity);
        }


        #region FriendsStuffRegion
        public void sendFriendRequestTo(string userEmailToSendTo)
        {
            User userAssociated;
            App.Current.Users.TryGetValue(userEmailToSendTo, out userAssociated);

            if (userAssociated != null)
                new FriendRequest(this, userAssociated);        //  S'occupe de l'ajouter a nos sent friend requests.
        }

        public IEnumerable<User> FriendsByAlphabeticalOrder()
        {
            List<User> friends = new List<User>();

            foreach (string email in this.FriendsEmails)
            {
                User associatedUser;
                App.Current.Users.TryGetValue(email, out associatedUser);

                if (associatedUser != null)
                    friends.Add(associatedUser);
            }

            return friends.OrderBy(friend => friend.FirstName);
        }

        // Quand on ajoute quelqu'un en ami , il est automatiquement placer au debut de la liste.
        // C'est donc en ordre du plus recent au plus vieux automatiquement.
        public List<User> FriendsByDateOfBeingFriends()
        {
            List<User> friends = new List<User>();

            foreach (string email in this.FriendsEmails)
            {
                User associatedUser;
                App.Current.Users.TryGetValue(email, out associatedUser);

                if (associatedUser != null)
                    friends.Add(associatedUser);
            }

            return friends;
        }

        // Amis en commun.
        // Pas mal sur que ca marche , mais j'l'aie pas tester
        public IEnumerable<User> Mutuals(User otherFriend)
        {
            List<User> friends = new List<User>();
            var mutualEmails = otherFriend.FriendsEmails.Where(friendEmail => this.FriendsEmails.Contains(friendEmail));

            foreach (string email in mutualEmails)
            {
                User associatedUser;
                App.Current.Users.TryGetValue(email, out associatedUser);

                if (associatedUser != null)
                    friends.Add(associatedUser);
            }

            return friends;
        }
        #endregion

        #region EventStuffRegion
        public void markInterestTowardsEvent(Event eventToMarkInterest, Interests interest)
        {
            _interetsEvents.Add(eventToMarkInterest, interest);
            // Reste a faire.
        }
        #endregion
        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}