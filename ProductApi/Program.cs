using ProductApi;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();


app.MapGet("/products", () =>
    {
        var products = Enumerable.Range(1, 5).Select(index =>
                new Product
                {
                    Name = $"Product{index}",
                    Sku = $"SKU{index}"
                })
            .ToArray();
        return products;
    })
    .WithName("GetProducts")
    .Produces(200, typeof(Product));

app.Run();
