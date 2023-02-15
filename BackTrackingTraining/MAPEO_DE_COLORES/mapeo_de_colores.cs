namespace Mapeando;
public static class Mapeando_cosas
{
    public static int Cant_Min_Colores(bool[,] Conections)
    {
        int result = int.MaxValue;
        bool[] mask = new bool[Conections.GetLength(0)];
        int[] colores = new int[mask.Length];

        Cant_Min_Colores(Conections, colores, mask, 0, 0, ref result);
        return result;
    }
    private static void Cant_Min_Colores(bool[,] conections, int[] colores, bool[] mask, int visitadas, int posicion_actual, ref int result)
    {
        if (colores.Max() > result)
            return;

        if (visitadas == conections.GetLength(0))
        {
            if (colores.Max() < result)
                result = colores.Max();

            return;
        }

        for (int i = 0; i < mask.Length; i++)
        {
            if (!mask[i])
            {
                mask[i] = true;

                colores[i] = ColorearCiudad(colores, conections, posicion_actual, i);

                Cant_Min_Colores(conections, colores, mask, visitadas + 1, i, ref result);

                colores[i] = 0;

                mask[i] = false;
            }
        }
    }
    private static int ColorearCiudad(int[] colores, bool[,] conections, int posicion_actual, int posicion_destino)
    {
        int color_a_poner = 1;
        for (int i = 0; i < conections.GetLength(0); i++)
        {
            if (conections[posicion_destino, i] && colores[i] == color_a_poner && posicion_destino != i)
                color_a_poner++;
        }
        return color_a_poner;
    }

}