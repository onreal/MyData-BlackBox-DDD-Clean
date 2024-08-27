using Microsoft.Extensions.DependencyInjection;
using Upio.MyData.BlackBox.Application.Adapters;
using Upio.MyData.BlackBox.Service.Client.Contract;

namespace Upio.MyData.BlackBox.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddCore(this IServiceCollection services)
        {
            services.AddScoped<IHttpClient, Upio.MyData.BlackBox.Service.Client.Implementation.HttpClient>();
            services.AddScoped<InvoiceAdapter>();
        }
    }
}