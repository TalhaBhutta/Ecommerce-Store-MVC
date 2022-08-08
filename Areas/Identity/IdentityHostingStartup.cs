using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NetCuisine.Areas.Identity.Data;
using NetCuisine.Data;

[assembly: HostingStartup(typeof(NetCuisine.Areas.Identity.IdentityHostingStartup))]
namespace NetCuisine.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<NetCuisineContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("NetCuisineContextConnection")));

                services.AddIdentity<NetCuisineUser, IdentityRole>(options => {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireNonAlphanumeric = false;
                }).AddDefaultUI()
                 .AddEntityFrameworkStores<NetCuisineContext>()
                 .AddDefaultTokenProviders();
            });
        }
    }
}