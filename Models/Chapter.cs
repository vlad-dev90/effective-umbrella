using System.Collections;
using System.Collections.Generic;

namespace FanficSite.Models
{
    public class Chapter
    {
        public int ChapterId { get; set; }
        public Fanfic Fanfic { get; set; }
        public byte Number { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public ICollection<Vote> Votes { get; set; }
        public float Rating { get; set; }
    }
}