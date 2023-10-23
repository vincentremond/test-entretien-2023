namespace CiteoInterview.Algo.UniTests;

public class AlgoTests
{
    [Fact]
    public void Test1()
    {
        var testAlgo = new TestAlgo();
        var result = testAlgo.Test1(new[] { "reza", "azer", "hello", "nat", "tan", "ante" })
            .ToList();
        Assert.Multiple(() =>
        {
            Assert.True(result.Count == 4);
            Assert.Contains(new List<string> {"azer", "reza"}, result );
            Assert.Contains(new List<string> {"hello"}, result);
            Assert.Contains(new List<string> {"nat","tan"}, result);
            Assert.Contains(new List<string> {"ante"}, result);
        });
    }

    [Fact]
    public void Test2()
    {
        var input = new List<List<int>>()
        {
            new() { 1,2,3,4,5,6,7,8,9},
            new() { 6,10,11,8,13,14,15,23},
            new() { 6,23,7,8},
            new() { 2,50,100,88},
        };
        var testAlgo = new TestAlgo();
        var result = testAlgo.Test2(input);
        Assert.Collection(result, items =>
        {
            Assert.Equal(items, new List<int> { 1,3,4,5,9} );
        },items =>
        {
            Assert.Equal(items, new List<int> { 10,11,13,14,15} );
        },items =>
        {
            Assert.Equal(items, new List<int>() );
        },items =>
        {
            Assert.Equal(items, new List<int> { 50,100,88} );
        });
    }
    
    [Fact]
    public void Test3()
    {
        var input = new [] {1, 2, 7, 8, 11, 7};
        var testAlgo = new TestAlgo();
        var result = testAlgo.Test3(input, 20);
        Assert.Collection(result, items =>
        {
            Assert.Equal(items, new List<int> { 1,8,11} );
        },items =>
        {
            Assert.Equal(items, new List<int> { 2,7,11} );
        });
    }
}