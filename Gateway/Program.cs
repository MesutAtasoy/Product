using ApiClient;
using Azure;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddSingleton<ProductApiV1Client>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.MapGet("/products",  async (ProductApiV1Client client)  =>
    {
        var context = new RequestContext(); // If you need a context for the request

        var response = await client.GetProductsAsync(context);
        
        return Results.Ok(await new StreamReader(response.ContentStream).ReadToEndAsync());
    })
    .WithName("Products ");

app.Run();
