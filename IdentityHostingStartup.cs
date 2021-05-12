using System;
using Funding.Areas.Identity.Data;
using Funding.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Funding.Areas.Identity.IdentityHostingStartup))]
namespace Funding.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<FundingContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("FundingContextConnection")));

                services.AddDefaultIdentity<FundingUser>(options => 
                {
                    options.SignIn.RequireConfirmedAccount = true;
                    options.Password.RequiredLength = 1;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                })
                    .AddEntityFrameworkStores<FundingContext>();
            });
        }
    }
}