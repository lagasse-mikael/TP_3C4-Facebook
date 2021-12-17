using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook
{
    public class Wall
    {
        public User Owner { get; init; }

        public List<Post> Posts = new List<Post>();

        public IEnumerable<Post> PostsByDate()
        {
            return Posts.OrderBy(post => post.Date);
        }

        public IEnumerable<Post> PostsByPopularity()
        {
            return Posts.OrderBy(post => post.Popularity);
        }
    }
}
