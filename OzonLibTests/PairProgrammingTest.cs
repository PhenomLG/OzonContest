using OzonLib;

namespace OzonLibTests;

public class PairProgrammingTest
{
    [Fact]
    public void Test1()
    {
        var result = PairProgramming.FormTeam(6, new[] { 2, 1, 3, 1, 1, 4 });
        Assert.Equal(result[0], new []{1, 2});
        Assert.Equal(result[1], new []{3, 6});
        Assert.Equal(result[2], new []{4, 5});
    }

    [Fact]
    public void Test2()
    {
        var result = PairProgramming.FormTeam(2, new[] { 5, 5 });
        Assert.Equal(result[0], new[] { 1, 2 });
    }

    [Fact]
    public void Test3()
    {
        var result = PairProgramming.FormTeam(8, new[] { 1, 4, 2, 5, 4, 2, 6, 3 });
        Assert.Equal(result[0], new[] { 1, 3 });
        Assert.Equal(result[1], new[] { 2, 5 });
        Assert.Equal(result[2], new[] { 4, 7 });
        Assert.Equal(result[3], new[] { 6, 8 });
    }
}