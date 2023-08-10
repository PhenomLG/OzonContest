namespace OzonLib;

public class Rhymes
{

    public static void Run()
    {
        int dictQnt = int.Parse(Console.ReadLine());
        string[] dict = new string[dictQnt];
        for (int i = 0; i < dictQnt; i++)
            dict[i] = Console.ReadLine();
        
        int requestsQnt = int.Parse(Console.ReadLine());
        string[] requests = new string[requestsQnt];
        for (int i = 0; i < requestsQnt; i++)
            requests[i] = Console.ReadLine();

        foreach (var request in requests)
        {
            Console.WriteLine(FindLongestSuffix(request, dict));
        }
    }

    public static string FindLongestSuffix(string request, IEnumerable<string> dict)
    {
        string wordWithMaxSuffix = string.Empty;
        int maxSuffixLength = 0;

        foreach (string str in dict)
        {
            for (int j = 1; j <= str.Length; j++)
            {
                string substring = str.Substring(str.Length - j, j);
                if (substring.Length > request.Length)
                    break;

                if (request.Substring(request.Length - j, j) == substring && substring.Length > maxSuffixLength)
                {
                    maxSuffixLength = substring.Length;
                    if (str != request)
                        wordWithMaxSuffix = str;
                }
            }
        }

        if (wordWithMaxSuffix == "")
            return dict.ElementAt(new Random().Next(0, dict.Count() - 1));

        return wordWithMaxSuffix;
    }
}