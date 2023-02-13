namespace No_Simetrica;

public static class ViajanteMod
{
    public static int MenorComb(int[,] combustible)
    {
        int result = int.MaxValue;
        bool[,] mask = GetCiudadesEnlazadas(combustible);
        for (int i = 0; i < combustible.GetLength(0); i++)
        {
            MenorCombb(combustible, mask, ref result, 0, 0, i);
        }

        return result;
    }
    private static void MenorCombb(int[,] combustible, bool[,] ciudades_enlazadas, ref int result, int visitadas, int combustible_gastado, int coordenada_actual)
    {
        if (combustible_gastado > result)
            return;
        if (visitadas == combustible.GetLength(0))
        {
            if (combustible_gastado < result)
                result = combustible_gastado;
            return;
        }

        for (int i = 0; i < ciudades_enlazadas.GetLength(0); i++)
        {
            if (ciudades_enlazadas[coordenada_actual, i])
            {
                ciudades_enlazadas[coordenada_actual, i] = false;
                ciudades_enlazadas[i, coordenada_actual] = false;

                MenorCombb(combustible, ciudades_enlazadas, ref result, visitadas + 1, combustible_gastado + combustible[coordenada_actual, i], i);

                ciudades_enlazadas[coordenada_actual, i] = true;
                ciudades_enlazadas[i, coordenada_actual] = true;
            }
        }
        return;
    }
    private static bool[,] GetCiudadesEnlazadas(int[,] combustible)
    {
        bool[,] result = new bool[combustible.GetLength(0), combustible.GetLength(1)];

        for (int i = 0; i < combustible.GetLength(0); i++)
        {
            for (int j = 0; j < combustible.GetLength(1); j++)
            {
                if (combustible[i, j] != -1 || combustible[i, j] != 0)
                    result[i, j] = true;
            }
        }
        return result;
    }
}