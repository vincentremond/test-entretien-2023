namespace CiteoInterview.Linq;

public class TestLinq
{
    public char Test1(IEnumerable<string> input)
    {
        throw new NotImplementedException();
    }

    public (string CustomerId, int Amount) Test2(IEnumerable<Order> input)
    {
        throw new NotImplementedException();
    }
}

public record Product(string ProductId, int Amount);
public record OrderItem(Product Product, int Quantity);
public record Order(string CustomerId, IEnumerable<OrderItem> Items);

