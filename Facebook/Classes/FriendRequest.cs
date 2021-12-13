using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook
{
    class FriendRequest
    {
        public FriendRequest(User from,User to)
        {
            from.SentFriendRequests.Prepend(this);
            to.PendingFriendRequests.Prepend(this);
        }
    }
}
