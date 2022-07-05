using Bill_api.Database.Contexts;
using Bill_api.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Bill_api
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBillApi(this IServiceCollection services)
        {
            services.AddScoped<BillService>();
            services.AddDbContext<BillContext>();
        }
    }
}