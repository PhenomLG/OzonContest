using OzonLib;

namespace OzonLibTests;

public class RhymesTest
{
    private string[] _dict = { "task", "decide", "id" };
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
    public void Test3()
    {
        var result = Rhymes.FindLongestSuffix("void", _dict);
        Assert.Equal("id", result);
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
        Assert.Equal("task", result);
    }

    [Fact]
    public void Test6()
    {
        var result = Rhymes.FindLongestSuffix("ask", _dict);
        Assert.Equal("task", result);
    }

    [Fact]
    public void Test7()
    {
        string[] dict = new[]
        {
            "sss",
            "ddvlwswlsd",
            "swvw",
            "dl",
            "llwllvw",
            "swdsdwsvd",
            "vwvsv",
            "wslswds",
            "vwswll",
            "wwvdsslwd",
            "wsvvlsw",
            "lvvlvsdss",
            "ldwlvsd",
            "v",
            "wvldwd",
            "ldlddvddvv",
            "vsswwll",
            "svwl",
            "sldwdsvsv",
            "svdw",
        };

        string[] requests =
        {
            "vwlldlswl",
            "slvlvdldw",
            "vwls",
            "dl",
            "lvs",
            "ldvsl",
            "ddlsw",
            "d",
            "svsvvwsdwl",
            "vlssldswlw",
            "lvlsdl",
            "s",
            "vlwlssld",
            "ldvl",
            "dvvvwsssww",
            "vdlvldw",
            "wwv",
            "dlwlwwsvdl",
            "swsw",
            "dwldddwwl",
        };

        var answers = GetStringArrayFromTestFile(Path.Combine(Directory.GetCurrentDirectory(), @"tests\09.a")).ToList();

        
        for (int i = 0; i < requests.Length; i++)
        {
            var result = Rhymes.FindLongestSuffix(requests[i], dict);
            Assert.Equal(answers[i], result);
        }
    }

    [Fact]
    public void Test8()
    {
        var dict = GetStringArrayFromTestFile(Path.Combine(Directory.GetCurrentDirectory(), @"tests\16.dict")).ToList();
        var requests = GetStringArrayFromTestFile(Path.Combine(Directory.GetCurrentDirectory(), @"tests\16.requests")).ToList();
        var answers = GetStringArrayFromTestFile(Path.Combine(Directory.GetCurrentDirectory(), @"tests\16.a")).ToList();

        for (int i = 0; i < requests.Count; i++)
        {
            var result = Rhymes.FindLongestSuffix(requests[i], dict);
            Assert.Equal(answers[i], result);
        }
    }



    private IEnumerable<string> GetStringArrayFromTestFile(string path)
    {
        var reader = File.OpenText(path);
        List<string> results = new List<string>();
        string? input;
        while ((input = reader.ReadLine()) != null)
            results.Add(input);

        return results;
    }

    [Fact]
    public void Test9()
    {
        var result = Rhymes.FindLongestSuffix("e", _dict);
        Assert.Equal("decide", result);
    }

    [Fact]
    public void Test10()
    {
        string[] dict = new[]
        {
            "xbbybxbyyx",
            "yyb",
            "y",
            "ybxbyxx",
            "ybbx"
        };

        string[] requests =
        {
            "xby",
            "xbyyy",
            "bxyybxbyy",
            "xyx",
            "xbxybyby",
            "y",
            "yyyxb",
            "bybyxyby"
        };

        string[] answers =
        {
            "y",
            "y",
            "y",
            "xbbybxbyyx",
            "y",
            "xbbybxbyyx",
            "yyb",
            "y",
        };
        for (int i = 0; i < requests.Length; i++)
        {
            var result = Rhymes.FindLongestSuffix(requests[i], dict);
            Assert.Equal(answers[i], result);
        }
    }

    [Fact]
    public void Test11()
    {
        var dict = GetStringArrayFromTestFile(Path.Combine(Directory.GetCurrentDirectory(), @"tests\07.dict")).ToList();
        var requests = GetStringArrayFromTestFile(Path.Combine(Directory.GetCurrentDirectory(), @"tests\07.requests")).ToList();
        var answers = GetStringArrayFromTestFile(Path.Combine(Directory.GetCurrentDirectory(), @"tests\07.a")).ToList();

        string path = "backlog.txt";
        using (StreamWriter writer = new StreamWriter(path))
        {
            for (int i = 0; i < requests.Count; i++)
            {
                var result = Rhymes.FindLongestSuffix(requests[i], dict);
                writer.WriteLineAsync($"Запрос: {requests[i]} | Результат: {result} | Ожидаемый ответ: {answers[i]}");
                Assert.Equal(answers[i], result);
            }
        }
    }
}