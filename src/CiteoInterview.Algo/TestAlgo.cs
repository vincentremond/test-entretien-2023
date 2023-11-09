using System.Security.AccessControl;

namespace CiteoInterview.Algo;

public class TestAlgo
{
    public IEnumerable<IEnumerable<string>> Test1(string[] input)
    {
        return SolverTest1.Solve(input);
    }

    public IEnumerable<IEnumerable<int>> Test2(List<List<int>> input)
    {
        var duplicates = input.SelectMany(x => x).GroupBy(x => x).Where(x => x.Count() > 1).Select(x => x.Key).ToHashSet();
        return input.Select(values => values.Where(value => !duplicates.Contains(value)));
    }

    public IEnumerable<IEnumerable<int>> Test3(int[] input, int sum)
    {
        var numbers = input.Distinct().OrderByDescending(x => x).ToArray();
        var stack = new Stack<int>();
        return InnerTest3(stack, numbers, 0, 0, sum).ToArray();
    }

    private IEnumerable<IEnumerable<int>> InnerTest3(Stack<int> stack, int[] values, int index, int currentSum, int targetSum)
    {
        for (var i = index; i < values.Length; i++)
        {
            var value = values[i];
            var projectedValue = value + currentSum;

            if (projectedValue > targetSum)
            {
                continue;
            }

            if (projectedValue == targetSum)
            {
                stack.Push(value);
                yield return stack.ToArray();
                stack.Pop();
            }
            
            if (projectedValue < targetSum)
            {
                stack.Push(value);
                
                var innerTest3 = InnerTest3(
                    stack,
                    values,
                    i + 1,
                    projectedValue,
                    targetSum
                ).ToList();
                stack.Pop();
                
                foreach (var x in innerTest3)
                {
                    yield return x;
                }
            }
        }
    }
}

public class SolverTest1
{
    public static IEnumerable<IEnumerable<string>> Solve(string[] input)
    {
        return input.Select(x => new { Str = x, Hash = Hash(x), }).GroupBy(x => x.Hash, new IntArrayComparer()).Select(x => x.Select(x => x.Str).Order().ToList());
    }

    private static int[] Hash(string str)
    {
        var result = new int[26];
        foreach (var c in str)
        {
            result[c - 'a']++;
        }

        return result;
    }
}

public class IntArrayComparer : IEqualityComparer<int[]>
{
    public bool Equals(int[]? x, int[]? y) => x.Zip(y).All(a => a.First == a.Second);

    public int GetHashCode(int[] values) => values.Aggregate(0, HashCode.Combine);
}
