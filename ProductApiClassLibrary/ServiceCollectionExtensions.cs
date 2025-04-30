using System;
using ApiClient;
using Azure.Core.Pipeline;
using Microsoft.Extensions.DependencyInjection;

namespace ProductApiClassLibrary;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddProductApiClient(this IServiceCollection services)
    {
        services.AddSingleton(x => new ProductClient(
            new ClientDiagnostics(new ProductClientOptions()
            {
                Retry =
                {
                    MaxRetries = 3,
                    Delay = new TimeSpan(0, 2,0)
                }
            }),
            new HttpPipeline(HttpClientTransport.Shared),
            new Uri("http://localhost:5289")));

        return services;
    }
}