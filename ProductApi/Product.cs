namespace ProductApi;

/// <summary>
/// Represents a product with a SKU and a name.
/// </summary>
public class Product
{
    /// <summary>
    /// Gets or sets the Stock Keeping Unit (SKU) of the product.
    /// </summary>
    public string Sku { get; set; }

    /// <summary>
    /// Gets or sets the display name of the product.
    /// </summary>
    public string Name { get; set; }
}