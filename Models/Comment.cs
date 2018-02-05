using System.Collections;
using System.Collections.Generic;

namespace FanficSite.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Content { get; set; }
        public ApplicationUser Author { get; set; }
        public Fanfic Fanfic { get; set; }
        public ICollection<CommentLike> CommentLikes { get; set; }
    }
}