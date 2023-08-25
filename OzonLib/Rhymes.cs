using System.Collections;

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

        Dictionary<string, string> handledRequests = new Dictionary<string, string>();

        foreach (var request in requests)
        {
            if (!handledRequests.ContainsKey(request))
                handledRequests.Add(request, FindLongestSuffix(request, dict));
            Console.WriteLine(handledRequests[request]);
        }
    }

    //public static string FindLongestSuffix(string request, IEnumerable<string> dict)
    //{

    //    string wordWithMaxSuffix = null;
    //    int maxSuffixLength = 0;

    //    foreach (string str in dict)
    //    {
    //        int minLength = Math.Min(str.Length, request.Length);
    //        int suffixLength = 0;

    //        for (int j = 0; j < minLength; j++)
    //        {
    //            if (str[str.Length - j - 1] == request[request.Length - j - 1])
    //                suffixLength++;
    //            else
    //                break;
    //        }

    //        if (suffixLength > maxSuffixLength && str != request)
    //        {
    //            wordWithMaxSuffix = str;
    //            maxSuffixLength = suffixLength;
    //        }
    //    }
    //    return wordWithMaxSuffix ?? dict.First();
    //}

    public static string FindLongestSuffix(string request, IEnumerable<string> dict)
    {
        int maxLength = 0;
        string resultWord = string.Empty;
        foreach (var word in dict)
        {
            int i = word.Length - 1;
            int maxLengthLoop = 0;
            string resultLoop = string.Empty;
            while (i > 0)
            {
                var res = FindWord(word.Substring(i, word.Length - i), request);
                i--;
                if (maxLengthLoop < res.Length)
                {
                    maxLengthLoop = res.Length;
                    resultLoop = word;
                }

                if (string.IsNullOrEmpty(res))
                    break;
                    
            }

            if (maxLengthLoop > maxLength && word != request)
                resultWord = resultLoop;

        }

        if (string.IsNullOrEmpty(resultWord))
            return dict.ToArray()[0];
        return resultWord;
    }

    public static string FindWord(string word, string request)
    {
        string t = word;
        string a = request;
        int m = 0;
        int n = 0;

        int j = t.Length - 1;
        int i = a.Length - 1;

        while (i > n)
        {
            if (a[i] != t[j])
                return "";

            i--;
            j--;
            if (j == m || j == -1)
                return word;
        }

        return "";
    }

}