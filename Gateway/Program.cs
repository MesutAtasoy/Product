using ApiClient;
using Azure;
using Azure.Core.Pipeline;
using ProductApiClassLibrary;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddProductApiClient();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/products",  async (ProductClient client)  =>
    {
        var response = await client.GetProductsAsync();
        
        return Results.Ok(response.Value);
    })
    .WithName("Products");

app.Run();
