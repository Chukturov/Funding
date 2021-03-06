using Funding.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Funding.Data.Model
{
    public class Post
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Img { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string Text { get; set; }
        public string CreateDate { get; set; }
        //public int Likes { get; set; }
        public virtual FundingUser User { get; set; }
        public virtual Campaign Campaign { get; set; }
        public virtual IEnumerable<Like> Likes { get; set; }
        //public string Bonuses { get; set; }
        ////public IEnumerable<Post> Posts { get; set; }
        ////public virtual Topic Topic { get; set; }
        ////public virtual BestUser BestUser { get; set; }
        ////public virtual IEnumerable<CampaignImg> Carousel { get; set; }
        //[NotMapped]
        //public IFormFile ImgFile { get; set; }
        //[NotMapped]
        //public IEnumerable<IFormFile> ImgsFile { get; set; }
    }
}
