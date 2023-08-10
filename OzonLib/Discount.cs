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
    string HandleSets(int sets)
    {
        int[] result = new int[sets];
        for (int i = 0; i < sets; i++)
        {
            var (goodsQnt, prices) = GetPricesInput();
            result[i] = CalcDiscount(goodsQnt, prices);
        }

        return string.Join("\n", result);
    }

    private static int CalcDiscount(int goodsQnt, int[] prices)
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


    (int, int[]) GetPricesInput()
    {
        int[] InputPrices()
        {
            return Console.ReadLine()
                .Split(' ')
                .Select(int.Parse)
                .ToArray();
        }

        int.TryParse(Console.ReadLine(), out var goodsQnt);
        int[] prices;
        do
        {
            prices = InputPrices();
            if (prices.Length != goodsQnt)
                Console.WriteLine("Введено неправильное количество цен. Попробуйте еще раз.");
        } while
            (prices.Length != goodsQnt);
        return (goodsQnt, prices);
    }
}