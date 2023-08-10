using OzonLib;

namespace OzonLibTests;

public class RhymesTest
{
    private List<string> _dict = new List<string>{ "task", "decide", "id" };
    [Fact]
    public void Test1()
    {
        var result = Rhymes.FindLongestSuffix("flask", _dict);
        Assert.Equal("task", result);
    }

    [Fact]
    public void Test2()
    {
        var result = Rhymes.FindLongestSuffix("code", _dict);
        Assert.Equal("decide", result);
    }

    [Fact]
    public void Test4()
    {
        var result = Rhymes.FindLongestSuffix("forces", _dict);
        Assert.Equal("task", result);
    }

    [Fact]
    public void Test5()
    {
        var result = Rhymes.FindLongestSuffix("id", _dict);
        Assert.Equal("decide", result);
    }

    [Fact]
    public void Test6()
    {
        var result = Rhymes.FindLongestSuffix("ask", _dict);
        Assert.Equal("task", result);
    }


}