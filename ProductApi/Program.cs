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


// Minimal API endpoint with comments
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
    .Produces(200, typeof(Product[]))
    .WithSummary("Retrieves a list of sample products.")
    .WithDescription("Generates and returns five sample products with SKU and name for demo purposes.");

app.Run();
