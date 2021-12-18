using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook
{
    public class GroupInvite
    {
        public User UserWaiting { get; init; }
        public Group GroupToJoin { get; init; }
    }
}
