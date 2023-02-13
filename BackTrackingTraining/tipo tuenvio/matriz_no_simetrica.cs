namespace No_Simetrica;

public static class ViajanteMod
{
    public static int MenorComb(int[,] combustible)
    {
        int result = int.MaxValue;
        bool[,] mask = GetCiudadesEnlazadas(combustible);
        Print(mask);
        for (int i = 0; i < combustible.GetLength(0); i++)
        {
            MenorCombb(combustible, mask, ref result, 0, i);
        }

        return result;
    }
    static void Print(bool[,] a)
    {
        for (int i = 0; i < a.GetLength(0); i++)
        {
            for (int j = 0; j < a.GetLength(1); j++)
            {
                if (a[i, j])
                    Console.Write("T");
                else
                    Console.Write("F");
                Console.Write(" ");
            }
            Console.WriteLine();
        }
    }
    private static void MenorCombb(int[,] combustible, bool[,] ciudades_enlazadas, ref int result, int combustible_gastado, int coordenada_actual)
    {
        if (combustible_gastado > result)
            return;
        if (AllPathVisited(ciudades_enlazadas))
        {
            if (combustible_gastado < result)
                result = combustible_gastado;
            return;
        }

        for (int i = 0; i < ciudades_enlazadas.GetLength(0); i++)
        {
           
            if (ciudades_enlazadas[coordenada_actual, i])
            {
                if (i == 2 && coordenada_actual == 3)
                { }
                ciudades_enlazadas[coordenada_actual, i] = false;
                ciudades_enlazadas[i, coordenada_actual] = false;

                MenorCombb(combustible, ciudades_enlazadas, ref result, combustible_gastado + combustible[coordenada_actual, i], i);

                ciudades_enlazadas[coordenada_actual, i] = true;
                ciudades_enlazadas[i, coordenada_actual] = true;
            }
        }
        return;
    }
    private static bool AllPathVisited(bool[,] mask)
    {
        for (int i = 0; i < mask.GetLength(0); i++)
        {
            for (int j = 0; j < mask.GetLength(1); j++)
            {
                if (mask[i, j])
                    return false;
            }
        }
        return true;
    }
    private static bool[,] GetCiudadesEnlazadas(int[,] combustible)
    {
        bool[,] result = new bool[combustible.GetLength(0), combustible.GetLength(1)];

        for (int i = 0; i < combustible.GetLength(0); i++)
        {
            for (int j = 0; j < combustible.GetLength(1); j++)
            {
                if (combustible[i, j] != -1 && combustible[i, j] != 0)
                    result[i, j] = true;
            }
        }
        return result;
    }
}