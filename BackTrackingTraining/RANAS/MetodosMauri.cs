

namespace MetodosMauri
{
    public static class Charco
    {
        public static int ComiendoChocolates(bool[,] chocos, int[] ranas)
        {
            int lastwithchocolat = chocos.GetLength(0);
            int chocolatscant = 0;
            for (int i = 0; i < chocos.GetLength(0); i++)
                for (int j = 0; j < chocos.GetLength(1); j++)
                {
                    if (chocos[i, j])
                    {
                        chocolatscant++;
                        lastwithchocolat = i + 1;
                    }
                }

            return ComiendoChocolates(chocos, ranas, 0, 0, lastwithchocolat, chocolatscant);
            //return ComiendoChocolates(chocos, ranas, 0, 0, chocos.GetLength(0), int.MaxValue);
        }
        static int ComiendoChocolates(bool[,] chocos, int[] ranas, int level, int eated, int end, int totalchocs)
        {
            if (level == end)
            {
                return eated;
            }
            eated += GetChoco(chocos, (int[])ranas.Clone(), level);
            // PrintScurim(chocos, ranas, level, eated);
            if (eated == totalchocs)
                return eated;

            int count = eated;
            int a;
            var b = GetValidWays((int[])ranas.Clone(), chocos.GetLength(1), 0, new List<int[]>());
            foreach (var item in b)
            {
                a = ComiendoChocolates((bool[,])chocos.Clone(), (int[])item.Clone(), level + 1, eated, end, totalchocs);
                if (a > count)
                    count = a;
            }
            return count;
        }

        // static void PrintScurim(bool[,] chocola, int[] ranas, int level, int count)
        // {

        //     var a = new Grid();
        //     for (int i = 0; i < chocola.GetLength(1); i++)
        //     {
        //         a.AddColumn();
        //     }
        //     for (int i = 0; i < chocola.GetLength(0); i++)
        //     {
        //         List<Markup> row = new List<Markup>();
        //         for (int j = 0; j < chocola.GetLength(1); j++)
        //         {
        //             if (chocola[i, j])
        //             {
        //                 row.Add(new Markup("[red]CHOC[/]"));
        //             }
        //             else
        //             {
        //                 row.Add(new Markup("NONE"));
        //             }
        //         }
        //         if (i == level)
        //         {
        //             foreach (var item in ranas)
        //             {
        //                 row[item] = new Markup("[green]FROG[/]");
        //             }
        //         }
        //         a.AddRow(row.ToArray());
        //     }
        //     Console.Clear();
        //     System.Console.WriteLine($"Comidos {count}");
        //     AnsiConsole.Write(a);
        //     // Console.ReadKey(true);
        // }
        static int GetChoco(bool[,] choco, int[] values, int level)
        {
            int count = 0;
            foreach (var item in values)
                if (choco[level, item])
                {
                    count++;
                    choco[level, item] = false;
                }
            return count;
        }
        static IEnumerable<int[]> GetValidWays(int[] values, int max, int ind, List<int[]> list)
        {
            if (ind == values.Length)
            {
                if (checkOK((int[])values.Clone(), max))
                    list.Add((int[])values.Clone());
                return list;
            }

            for (int i = -1; i <= 1; i++)
            {
                values[ind] += i;
                GetValidWays((int[])values.Clone(), max, ind + 1, list);
                values[ind] -= i;
            }
            return list;
        }

        static bool checkOK(int[] values, int max)
        {
            var obtained = values.ToList().Distinct().ToList();
            return (obtained.Max() < max && obtained.Min() >= 0 && obtained.Count == values.Length);
        }
    }
}