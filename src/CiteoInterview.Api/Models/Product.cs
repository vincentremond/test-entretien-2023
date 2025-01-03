namespace CiteoInterview.Api.Models;

public partial class Product
{
    public required string Name { get; set; }
    public int Price { get; set; }
    public int Stock { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public int Id { get; set; }

    public virtual ICollection<OrderItem> OrderItem { get; set; } = new HashSet<OrderItem>();
}
