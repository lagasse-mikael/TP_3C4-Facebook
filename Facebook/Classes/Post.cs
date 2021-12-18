using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook
{
    public enum VisibilityPost
    {
        Public,
        FriendsOnly,
        FriendsExcept,
        SpecificFriends,
        OnlyMe
    }
    public class Post
    {
        public string OwnerEmail
        {
            get;
            init;
        }

        public User OwnerUser
        {
            get
            {
                User userAssociated;
                App.Current.Users.TryGetValue(this.OwnerEmail, out userAssociated);

                if (userAssociated != null)
                    return userAssociated;
                else
                    throw new Exception("Cette email ne correspond pas a aucun utilisateur");
            }
            private set { this.OwnerUser = value; }
        }

        public string Title { get; init; }
        public string Description { get; init; }
        public Uri Image { get; init; }
        public DateTime Date { get; init; }
        public VisibilityPost Visibility { get; init; }

        // Si il a choisie FriendsExcept ou SpecificFriends , on les ajoutes dans _excludes (Except) ou dans _onlyshowto (Specific)
        public List<string> TargetEmail
        {
            get => TargetEmail;
            init
            {
                if (Visibility == VisibilityPost.FriendsExcept)
                {
                    foreach (string email in value)
                    {
                        _excludes.Add(email);
                    }
                }
                else if (Visibility == VisibilityPost.SpecificFriends)
                {
                    foreach (string email in value)
                    {
                        _onlyshowto.Add(email);
                    }
                }
            }
        }

        private List<string> _excludes = new List<string>();
        private List<string> _onlyshowto = new List<string>();

        public Reactions ReactionsAuPost { get; init; }
        public int Popularity
        {
            get
            {
                return (ReactionsAuPost.AmountOfAngry) + (ReactionsAuPost.AmountOfSad) + (ReactionsAuPost.AmountOfLikes * 3) + (ReactionsAuPost.AmountOfLove * 5);
            }
        }

        public Wall parentWall { get; init; }

        // https://stackoverflow.com/questions/55651059/how-to-determine-if-user-control-is-shown-or-not-on-winforms
        public List<string> asBeenSeenBy { get; private set; }


    }
}
