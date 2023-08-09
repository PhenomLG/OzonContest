namespace OzonLib
{
    public class Summator
    {
        // Метод запуска для codeforces
        public static void Run()
        {
            var count = int.Parse(Console.ReadLine());
            List<int[]> inputs = new();
            for (int i = 0; i < count; i++)
            {
                var input = Console.ReadLine()?
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();
                inputs.Add(input);
            }

            var results = inputs.Select(nums => nums[0] + nums[1]).ToArray();
            foreach (var result in results)
                Console.WriteLine(result);
            
        }
    }
}