namespace CiteoInterview.Api.Models;

public class Order
{
    public DateTime CreationDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public int Id { get; set; }
    public int CustomerId { get; set; }

    public virtual Customer Customer { get; set; } = null!;
    public virtual ICollection<OrderItem> OrderItem { get; set; } = new HashSet<OrderItem>();
}
