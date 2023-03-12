using DDDTemplate.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace DDDTemplate.Tests
{
    public class IntegrationTestFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                //Replace the DbContext with a fake 
                var dbContextDescriptor = services.SingleOrDefault(x => x.ServiceType == typeof(DbContextOptions<DDDTemplateContext>));
                services.Remove(dbContextDescriptor);

                services.AddDbContext<DDDTemplateContext>(x => x.UseInMemoryDatabase("inmemory"));
            });

            base.ConfigureWebHost(builder);
        }
    }
}
