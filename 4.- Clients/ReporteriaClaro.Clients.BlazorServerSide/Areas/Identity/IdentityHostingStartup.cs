using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReporteriaClaro.Clients.BlazorServerSide.Data;

[assembly: HostingStartup(typeof(ReporteriaClaro.Clients.BlazorServerSide.Areas.Identity.IdentityHostingStartup))]
namespace ReporteriaClaro.Clients.BlazorServerSide.Areas.Identity
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