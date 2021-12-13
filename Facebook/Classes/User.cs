using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Facebook
{
    class User
    {
        public string LastName { get; init; }
        public string FirstName { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }

        public Uri ProfileSrc { get; init; }
        public Uri BannerSrc { get; init; }

        public List<User> Friends = new List<User>();

        // Amis en commun.
        // Pas mal sur que ca marche , mais j'l'aie pas tester
        public IEnumerable<User> Mutuals(User otherFriend)
        {
            return Friends.Where(friend => otherFriend.Friends.Contains(friend));
        }

        // Liste des Friend Requests qui ont ete envoyer / pas encore repondu.
        public List<FriendRequest> SentFriendRequests = new List<FriendRequest>();

        // Liste des Friend Requests recues , qui n'ont pas encore ete repondues.
        public List<FriendRequest> PendingFriendRequests = new List<FriendRequest>();

        public override string ToString()
        {
            return $"{FirstName} {LastName}\n{Email} & {Password}";
        }
    }
}
