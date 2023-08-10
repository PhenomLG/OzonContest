namespace OzonLib;

public class PairProgramming
{
    public static void Run()
    {
        var setsQnt = int.Parse(Console.ReadLine());

        List<(int, int[])> sets = new List<(int, int[])>();

        for (int i = 0; i < setsQnt; i++)
        {
            int devQnt = int.Parse(Console.ReadLine());
            int[] devLevels = Console.ReadLine()
                .Split(' ')
                .Select(price => int.Parse(price))
                .ToArray();
            sets.Add((devQnt, devLevels));
        }

        for (int i = 0; i < setsQnt; i++)
        {
            Console.WriteLine(FormTeam(sets[i].Item1, sets[i].Item2));
        }
    }

    public static List<int[]> FormTeam(int devQnt, int[] devLevels)
    {
        List<int[]> pairs = new List<int[]>();

            for (int j = 0; j < devLevels.Length; j++)
            {
                if (devLevels[j] == -1)
                    continue;

                var(firstDevIndex, firstDevLevel) = (j, devLevels[j]);
                int minDif = int.MaxValue;
                int secondDevIndex = -1;

                for (int k = firstDevIndex + 1; k < devLevels.Length; k++)
                {
                    if (devLevels[k] == -1)
                        continue;

                    var dif = Math.Abs(firstDevLevel - devLevels[k]);
                    if (minDif > dif)
                    {
                        minDif = dif;
                        secondDevIndex = k;
                    }
                }

                pairs.Add(new int[] {firstDevIndex + 1, secondDevIndex + 1});
                devLevels[firstDevIndex] = -1;
                devLevels[secondDevIndex] = -1;
            }
        return pairs;
    }
}