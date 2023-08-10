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

        var results = requests.Select((request)
            => FindLongestSuffix(request, dict)).ToList();
        foreach (var res in results)
            Console.WriteLine(res);
    }

    public static string FindLongestSuffix(string request, IEnumerable<string> dict)
    {
        string wordWithMaxSuffix = null;
        int maxSuffixLength = 0;

        foreach (string str in dict)
        {
            int minLength = Math.Min(str.Length, request.Length);
            int suffixLength = 0;

            for (int j = 0; j < minLength; j++)
            {
                if (str[str.Length - j - 1] == request[request.Length - j - 1])
                    suffixLength++;
                else
                    break;
                
            }

            if (suffixLength > maxSuffixLength && str != request)
            {
                wordWithMaxSuffix = str;
                maxSuffixLength = suffixLength;
            }
        }

        return wordWithMaxSuffix ?? dict.ToList()[0];
    }
}