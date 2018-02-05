namespace FanficSite.Models
{
    public class FanficTag
    {
        public Fanfic Fanfic { get; set; }
        public int FanficId { get; set; }
        public Tag Tag { get; set; }
        public int TagId { get; set; }
    }
}