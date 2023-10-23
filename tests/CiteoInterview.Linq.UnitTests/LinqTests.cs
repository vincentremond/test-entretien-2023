namespace CiteoInterview.Linq.UnitTests;

public class LinqTests
{
    [Fact]
    public void Test1()
    {
        var test = new TestLinq();
        var input = new List<string>()
        {
            "aabccccc",
            "ddflfccccc",
            "zzzzzzzzzzzzzzzzzzzzzzzzzz"
        };
        Assert.Equal('z', test.Test1(input));
    }
    
    [Fact]
    public void Test2()
    {
        var test = new TestLinq();
        var orders = new List<Order>()
        {
            new("1", new List<OrderItem>()
            {
                new(new Product("p1", 100), 1),
                new(new Product("p2", 150), 2),
            }),
            new("2", new List<OrderItem>()
            {
                new(new Product("p1", 100), 1),
                new(new Product("p2", 150), 2),
            }),
            new("3", new List<OrderItem>()
            {
                new(new Product("p3", 1000), 1),
                new(new Product("p4", 1200), 2),
            }),
        };
        Assert.Equal(("3", 3400), test.Test2(orders));
    }
}