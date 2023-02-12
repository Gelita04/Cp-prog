namespace EjerciciosDEInternet;

public static class EjerciciosDEInternet
{
    public static bool Cantidad_particiones_en(int[] set, int k)
    {
        bool result = false;
        if (set.Sum() % k != 0)
            return false;
        bool[] mask = new bool[set.Length];
        Cantidad_particiones_en(set, mask, k, ref result, 0, 0, set.Sum() / k, 0);
        return result;

    }
    private static void Cantidad_particiones_en(int[] set, bool[] mask, int k, ref bool result, int puestos, int sumaAcumulada, int sumaMax, int test)
    {
        if (result)
            return;

        if (sumaAcumulada == sumaMax)
        {
            Cantidad_particiones_en(set, mask, k, ref result, puestos, 0, sumaMax, test + 1);
            return;
        }
        if (puestos == set.Length)
        {
            Console.WriteLine(test);
            result = true;
            return;
        }

        for (int i = 0; i < mask.Length; i++)
        {
            if (!mask[i])
            {
                if (sumaAcumulada + set[i] <= sumaMax)
                {
                    mask[i] = true;
                    Cantidad_particiones_en(set, mask, k, ref result, puestos + 1, sumaAcumulada + set[i], sumaMax, test);
                    mask[i] = false;
                }
            }
        }
    }

    // 1 
    public static int Cantidad_Combinaciones(int n)
    {
        int result = 0;
        bool[] mask = new bool[2 * n];
        Cantidad_Combinaciones(n, mask, ref result, 1);
        return result;
    }
    private static void Cantidad_Combinaciones(int n, bool[] mask, ref int result, int key)
    {
        if (key == n + 1)
        {
            result++;
            return;
        }

        for (int i = 0; i < 2 * n; i++)
        {
            if (!mask[i] && i + key + 1 < mask.Length && !mask[i + key + 1])
            {
                mask[i] = true;
                mask[i + key + 1] = true;
                Cantidad_Combinaciones(n, mask, ref result, key + 1);
                mask[i] = false;
                mask[i + key + 1] = false;
            }
        }
        return;
    }
    //11
    public static string[,] MagnetPuzzle(int[] top, int[] left, int[] bottom, int[] right, string[,] rules)
    {
        string[,] result = new string[rules.GetLength(0), rules.GetLength(1)];
        bool solved = false;
        string[,] realResult = new string[rules.GetLength(0), rules.GetLength(1)];
        MagnetPuzzle(top, left, bottom, right, rules, result, GetTotalEspacios(rules), ref solved, realResult, 0, 0, 0);
        return realResult;
    }
    private static void MagnetPuzzle(int[] top, int[] left, int[] bottom, int[] right, string[,] rules, string[,] result, int totalEspacios, ref bool solved, string[,] realResult, int ocupados, int row, int col)
    {
        if (solved)
            return;
        if (totalEspacios == ocupados)
        {
            if (!IsValid(result, top, left, bottom, right))
            { return; }
            solved = true; IsValid(result, top, left, bottom, right); realResult = (string[,])result.Clone(); return;
        }

        if (rules[row, col] == "L")
        {
            result[row, col] = "+";
            result[row, col + 1] = "-";
            MagnetPuzzle(top, left, bottom, right, rules, result, totalEspacios, ref solved, realResult, ocupados + 1, col + 2 < rules.GetLength(1) ? row : row + 1, col + 2 < rules.GetLength(1) ? col + 2 : 0);
            result[row, col] = "-";
            result[row, col + 1] = "+";
            MagnetPuzzle(top, left, bottom, right, rules, result, totalEspacios, ref solved, realResult, ocupados + 1, col + 2 < rules.GetLength(1) ? row : row + 1, col + 2 < rules.GetLength(1) ? col + 2 : 0);
            result[row, col] = "X";
            result[row, col + 1] = "X";
            MagnetPuzzle(top, left, bottom, right, rules, result, totalEspacios, ref solved, realResult, ocupados + 1, col + 2 < rules.GetLength(1) ? row : row + 1, col + 2 < rules.GetLength(1) ? col + 2 : 0);
            return;
        }
        if (rules[row, col] == "T")
        {

            result[row, col] = "+";
            result[row + 1, col] = "-";
            MagnetPuzzle(top, left, bottom, right, rules, result, totalEspacios, ref solved, realResult, ocupados + 1, col + 1 < rules.GetLength(1) ? row : row + 1, col + 1 < rules.GetLength(1) ? col + 1 : 0);
            result[row, col] = "-";
            result[row + 1, col] = "+";
            MagnetPuzzle(top, left, bottom, right, rules, result, totalEspacios, ref solved, realResult, ocupados + 1, col + 1 < rules.GetLength(1) ? row : row + 1, col + 1 < rules.GetLength(1) ? col + 1 : 0);
            result[row, col] = "X";
            result[row + 1, col] = "X";
            MagnetPuzzle(top, left, bottom, right, rules, result, totalEspacios, ref solved, realResult, ocupados + 1, col + 1 < rules.GetLength(1) ? row : row + 1, col + 1 < rules.GetLength(1) ? col + 1 : 0);
            return;


        }
        if (col + 1 < rules.GetLength(1))
            MagnetPuzzle(top, left, bottom, right, rules, result, totalEspacios, ref solved, realResult, ocupados, row, col + 1);
        if (col == rules.GetLength(1) - 1)
            MagnetPuzzle(top, left, bottom, right, rules, result, totalEspacios, ref solved, realResult, ocupados, row + 1, 0);

    }
    private static bool IsValid(string[,] result, int[] top, int[] left, int[] bottom, int[] right)
    {
        int plus = 0;
        int minus = 0;

        for (int i = 0; i < result.GetLength(0); i++)
        {
            plus = 0;
            minus = 0;
            for (int j = 0; j < result.GetLength(1); j++)
            {
                if (result[i, j] == "+")
                    plus++;
                else if (result[i, j] == "-")
                    minus++;
            }
            if ((left[i] != -1 && plus != left[i]) || (right[i] != -1 && minus != right[i]))//significa q la fila esta correcta
                return false;
        }


        for (int j = 0; j < result.GetLength(1); j++)
        {
            plus = 0;
            minus = 0;
            for (int i = 0; i < result.GetLength(0); i++)
            {
                if (result[i, j] == "+")
                    plus++;
                else if (result[i, j] == "-")
                    minus++;
            }
            if ((top[j] != -1 && plus != top[j]) || (bottom[j] != -1 && minus != bottom[j]))//significa q la columna esta correcta
                return false;
        }
        return true;
    }
    private static int GetTotalEspacios(string[,] rules)
    {
        int result = 0;
        for (int i = 0; i < rules.GetLength(0); i++)
        {
            for (int j = 0; j < rules.GetLength(1); j++)
            {
                if (rules[i, j] == "L" || rules[i, j] == "T")
                { result++; }
            }
        }
        return result;
    }
}