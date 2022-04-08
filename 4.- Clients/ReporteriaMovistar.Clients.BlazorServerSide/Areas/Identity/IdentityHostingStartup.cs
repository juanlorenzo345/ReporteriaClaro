using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReporteriaMovistar.Clients.BlazorServerSide.Data;

[assembly: HostingStartup(typeof(ReporteriaMovistar.Clients.BlazorServerSide.Areas.Identity.IdentityHostingStartup))]
namespace ReporteriaMovistar.Clients.BlazorServerSide.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}