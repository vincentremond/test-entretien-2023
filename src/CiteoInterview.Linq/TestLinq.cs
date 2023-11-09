namespace CiteoInterview.Linq;

public class TestLinq
{
    public char Test1(IEnumerable<string> input)
    {
        return input.SelectMany(x => x).GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key;
    }

    public (string CustomerId, int Amount) Test2(IEnumerable<Order> input)
    {
        return input.Select(
            order =>
            {
                var totalAmount = order.Items.Select(item => item.Quantity * item.Product.Amount).Sum();
                var customerId = order.CustomerId;

                return (CustomerId: customerId, Amount: totalAmount);
            }
        ).MaxBy(o => o.Amount);
    }
}

public record Product(string ProductId, int Amount);

public record OrderItem(Product Product, int Quantity);

public record Order(string CustomerId, IEnumerable<OrderItem> Items);
