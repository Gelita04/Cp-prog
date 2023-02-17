namespace grafos;
public static class Grafos
{
    public static int Mayor_Cant_Conectados(bool[,] conectadas)
    {
        int result = 0;

        bool[] mask = new bool[conectadas.GetLength(0)];
        int[] seleccionados = new int[conectadas.GetLength(0)];
        Mayor_Cant_Conectados(conectadas, mask, seleccionados, 0, 0, ref result);
        return result;
    }
    private static void Mayor_Cant_Conectados(bool[,] conectados, bool[] mask, int[] seleccionados, int posicion_actual, int grafos_recorridos, ref int result)
    {
        if (!Is_All_Connected(conectados, mask, seleccionados))
        {
            return;
        }

        for (int i = 0; i < mask.Length; i++)
        {
            if (!mask[i])
            {
                if (conectados[posicion_actual, i])
                {
                    mask[i] = true;
                    seleccionados[grafos_recorridos] = i;
                    Mayor_Cant_Conectados(conectados, mask, seleccionados, i, grafos_recorridos + 1, ref result);
                    mask[i] = false;
                }
            }
        }
        if (grafos_recorridos > result)
            result = grafos_recorridos;
    }
    private static bool Is_All_Connected(bool[,] conectados, bool[] mask, int[] seleccionados)
    {
        for (int i = 0; i < mask.Length; i++)
        {
            if (mask[i])
            {
                if (i != seleccionados.Last() && !conectados[i, seleccionados.Last()])
                {
                    return false;
                }
            }
        }
        return true;
    }
}