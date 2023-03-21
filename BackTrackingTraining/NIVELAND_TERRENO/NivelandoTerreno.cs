namespace NivelandoTerreno;

public static class NivelarTerreno
{
    // public static int NT(int[] parcelas)
    // {
    //     return NT(parcelas, 0, Top(parcelas));
    // }
    // public static int NT(int[] parcelas, int top)
    // {
    //     if (IsValid(parcelas))
    //     {
    //         return 0;
    //     }
    //     int[][] maneras = FindSubArrays(parcelas, top);
    //     int[] result = new int[maneras.Length];
    //     for (int i = 0; i < maneras.Length; i++)
    //     {
    //         result[i] = NT(maneras[i], top) + 1;
    //     }
    //     return result.Min();
    // }
    // public static int[][] FindSubArrays(int[] main, int ignore)
    // {
    //     List<int[]> equisde = new List<int[]>();

    //     for (int i = 0; i < main.Length; i++)
    //     {

    //         int[] arrToAdd = (int[])main.Clone();

    //         for (int j = i; main[j] != ignore && j < main.Length; j++)
    //         {
    //             arrToAdd[j] = main[j] + 1;
    //         }
    //         equisde.Add(arrToAdd);
    //     }
    //     return equisde.ToArray();
    // }
    public static int NT(int[] parcelas)
    {
        int top = parcelas.Max();
        int result = 0;
        bool IsFinal = false;
        for (int i = 0; i < parcelas.Length; i++)
        {
            if (IsFinal)
                break;
            for (int j = i; j < parcelas.Length; j++)
            {
                if (parcelas[j] == top)
                {
                    result += RealNT(parcelas[i..j], top);
                    i = j;
                    break;
                }

                if (j + 1 == parcelas.Length)
                {
                    result += RealNT(parcelas[i..(j + 1)], top);
                    IsFinal = true;
                    break;
                }
            }
        }
        return result;
    }


    public static int RealNT(int[] subparcela, int top)
    {
        int result = int.MaxValue;
        RealNT(subparcela, 0, ref result, top);
        return result;
    }
    public static void RealNT(int[] subparcela, int viajes, ref int result, int top)
    {
        if (subparcela.All(x => x == top))
        {
            if (viajes < result)
                result = viajes;
            return;
        }

        for (int i = 0; i < subparcela.Length; i++)
        {
            for (int j = i; j < subparcela.Length; j++)
            {
                if (!IsFutureArrValid(subparcela, i, j, top))
                    break;

                RealNT(ArrPlusOne(subparcela, i, j), viajes + 1, ref result, top);
            }
        }
    }
    static int[] ArrPlusOne(int[] subparcela, int start, int end)
    {
        int[] result = (int[])subparcela.Clone();
        for (int i = start; i <= end; i++)
        {
            result[i] += 1;
        }
        return result;
    }
    static bool IsFutureArrValid(int[] subparcela, int start, int end, int top)
    {
        int[] result = (int[])subparcela.Clone();
        for (int i = start; i <= end; i++)
        {
            int temp = result[i];
            if (temp + 1 > top)
                return false;
            result[i] = temp + 1;
        }
        return true;
    }

    public static int NewMethod(int[] parcerlas)
    {
        int result = int.MaxValue;
        NewMethod(parcerlas, ref result);
        return result;
    }
    private static void NewMethod(int[] parcelas, ref int result)
    {

    }
}