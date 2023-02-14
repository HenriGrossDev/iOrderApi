namespace iOrderApp.Domain.Products;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public Category Category { get; set; }

    public string Description { get; set; }

    public bool HasStock { get; set; }

}
