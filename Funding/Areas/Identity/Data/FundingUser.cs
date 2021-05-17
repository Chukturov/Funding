using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Funding.Data.Model;
using Microsoft.AspNetCore.Identity;

namespace Funding.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the FundingUser class
    public class FundingUser : IdentityUser
    {
        public virtual IEnumerable<Campaign> Campaigns { get; set; }
        public virtual IEnumerable<Post> Posts { get; set; }
        public virtual IEnumerable<Like> Likes { get; set; }
        public virtual IEnumerable<CampaignImgs> CampaignImgs { get; set; }
    }
}
