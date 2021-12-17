using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook
{
    public class FriendRequest
    {
        public FriendRequest(User from, User to)
        {
            from.SentFriendRequests.Prepend(this);
            to.PendingFriendRequests.Prepend(this);
        }

        public void decideFriendRequest(bool wantsToBeFriend)
        {
            fromWho.SentFriendRequests.Remove(this);
            toWho.PendingFriendRequests.Remove(this);

            if (wantsToBeFriend) {
                fromWho.FriendsEmails.Prepend(toWho.Email);
                toWho.FriendsEmails.Prepend(fromWho.Email);
            }
        }

        private User fromWho;
        private User toWho;
    }
}
