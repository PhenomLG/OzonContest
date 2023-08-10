namespace OzonLib;

public class Discount
{
    public static void  Run()
    {
        int setsQnt = int.Parse(Console.ReadLine());
        List<(int, int[])> sets = new List<(int, int[])>();

        for (int i = 0; i < setsQnt; i++)
        {
            int goodsQnt = int.Parse(Console.ReadLine());
            int[] prices = Console.ReadLine()
                            .Split(' ')
                            .Select(price => int.Parse(price))
                            .ToArray();
            sets.Add((goodsQnt, prices));
        }

        for (int i = 0; i < setsQnt; i++)
        {
            Console.WriteLine(CalcDiscount(sets[i].Item1, sets[i].Item2));
        }
    }

    public static int CalcDiscount(int goodsQnt, int[] prices)
    {
        Dictionary<int, int> pricesKeeper = new();
        foreach (var price in prices)
        {
            if (!pricesKeeper.ContainsKey(price))
                pricesKeeper.Add(price, 1);
            else
                pricesKeeper[price]++;
        }

        int cost = 0;
        foreach (var (price, qnt) in pricesKeeper)
            cost += (qnt - qnt / 3) * price;

        return cost;
    }
}