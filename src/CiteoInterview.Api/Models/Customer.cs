namespace CiteoInterview.Api.Models;

public class Customer
{
    public int Id { get; set; }
    public required string Email { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? UpdateDate { get; set; }

    public virtual ICollection<Order> Order { get; set; } = new HashSet<Order>();
}
