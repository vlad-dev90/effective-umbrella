using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace FanficSite.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        public ICollection<Fanfic> Fanfics { get; }
        public ICollection<Vote> Votes { get; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<CommentLike> CommentLikes { get; set; }
    }
}
