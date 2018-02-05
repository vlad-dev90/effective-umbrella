using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using FanficSite.Models.ModelUtils;
using System.Linq;

namespace FanficSite.Models
{
    public class Tag
    {
        public Tag()
            => Fanfics = new JoinCollectionFacade<Fanfic, FanficTag>(
                FanficTags,
                ft => ft.Fanfic,
                f => new FanficTag { Fanfic = f, Tag = this });
        
        public int TagId { get; set; }
        public string Title { get; set; }
        
        private ICollection<FanficTag> FanficTags { get; } = new List<FanficTag>();
        [NotMapped]
        
        public ICollection<Fanfic> Fanfics { get; }

    }
}