namespace FanficSite.Models
{
    public class CommentLike
    {
        public int CommentLikeId { get; set; }
        
        public ApplicationUser Author { get; set; }
        public Comment Comment { get; set; }
    }
}