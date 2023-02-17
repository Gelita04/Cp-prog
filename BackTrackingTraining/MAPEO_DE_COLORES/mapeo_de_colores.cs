namespace Mapeando;
public static class Mapeando_cosas
{
    public static int Cant_Min_Colores(bool[,] Conections, int cant_colores_adyacentes_permitidos)
    {
        int result = int.MaxValue;
        bool[] mask = new bool[Conections.GetLength(0)];
        int[] colores = new int[mask.Length];

        Cant_Min_Colores(Conections, colores, mask, 0, 0, ref result, cant_colores_adyacentes_permitidos);
        return result;
    }
    private static void Cant_Min_Colores(bool[,] conections, int[] colores, bool[] mask, int visitadas, int posicion_actual, ref int result, int cant_colores_adyacentes_permitidos)
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

                colores[i] = ColorearCiudad(colores, conections, posicion_actual, i, cant_colores_adyacentes_permitidos, 1);

                Cant_Min_Colores(conections, colores, mask, visitadas + 1, i, ref result, cant_colores_adyacentes_permitidos);

                colores[i] = 0;

                mask[i] = false;
            }
        }
    }
    private static int ColorearCiudad(int[] colores, bool[,] conections, int posicion_actual, int posicion_destino, int cant_colores_adyacentes_permitidos, int color_a_poner)
    {
        int ciudades_ady_mismo_color = 0;
        for (int i = 0; i < conections.GetLength(0); i++)
        {
            if (conections[posicion_destino, i] && colores[i] == color_a_poner && posicion_destino != i)
            { ciudades_ady_mismo_color++; }
            if (ciudades_ady_mismo_color > cant_colores_adyacentes_permitidos)
            { return ColorearCiudad(colores, conections, posicion_actual, posicion_destino, cant_colores_adyacentes_permitidos, color_a_poner + 1); }
        }
        return color_a_poner;
    }

}