using System.Collections.ObjectModel;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using FanficSite.Models.ModelUtils;
using System.Linq;
using System.Net;

namespace FanficSite.Models
{
    public class Fanfic
    {
        public Fanfic()
            => Tags = new JoinCollectionFacade<Tag, FanficTag>(
                FanficTags,
                ft => ft.Tag,
                t => new FanficTag(){ Fanfic = this, Tag = t }
            );
        
        public int FanficId { get; set; }
        public string Title { get; set; }
        public ApplicationUser Author { get; set; }
        public ICollection<Chapter> Chapters { get; set; }
        
        private ICollection<FanficTag> FanficTags { get; } = new List<FanficTag>();
        [NotMapped]
        public ICollection<Tag> Tags { get; }
        
        public ICollection<Comment> Comments { get; set; }
    }
}