using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook
{
    public class GroupAdmin
    {
        public GroupAdmin(User userToGrantAdminRights,Group toWhatGroup)
        {
            this.UserAssociated = userToGrantAdminRights;
            this.GroupAssociated = toWhatGroup;
        }

        public int GrantAdminRightsTo(User userToPromote)
        {
            if (GroupAssociated.Users.Contains(userToPromote))
            {
                GroupAssociated.AddAdmin(userToPromote);
                return 0;
            }
            return 1;
        }

        public void CreateEventForGroup(Event eventToAdd)
        {
            this.GroupAssociated.Events.Add(eventToAdd);
        }

        public User UserAssociated { get; private set; }
        public Group GroupAssociated { get; private set; }
    }
}
