namespace FanficSite.Models
{
    public class Vote
    {
        public int VoteId { get; set; }
        public byte Value { get; set; }
        public ApplicationUser Author { get; set; }
        public Chapter Chapter { get; set; }
    }
}