using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Funding.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Funding.Data.Model;

namespace Funding.Data
{
    public class FundingContext : IdentityDbContext<FundingUser>
    {
        public FundingContext(DbContextOptions<FundingContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Funding.Data.Model.Campaign> Campaign { get; set; }

        public DbSet<Funding.Data.Model.Post> Post { get; set; }

        public DbSet<Funding.Data.Model.Like> Like { get; set; }

        public DbSet<Funding.Data.Model.CampaignImgs> CampaignImgs { get; set; }
    }
}
