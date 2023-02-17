namespace n_mochilas;
public static class N_Mochilas
{
    public static int Peso_Max_A_Llevar(int[] peso_de_objetos, int[] peso_max_mochilas)
    {
        int result = 0;
        bool[] mask = new bool[peso_de_objetos.Length];
        Peso_Max_A_Llevar(peso_de_objetos, peso_max_mochilas.Length, peso_max_mochilas, mask, 0, 0, 0, ref result);

        return result;
    }
    private static void Peso_Max_A_Llevar(int[] peso_de_objetos, int cant_mochilas, int[] peso_max_mochilas, bool[] mask, int id_mochila_actual, int peso_llevado_mochila_actual, int peso_total_llevado, ref int result)
    {
        for (int i = 0; i < peso_de_objetos.Length; i++)
        {
            if (!mask[i])
            {
                if (peso_llevado_mochila_actual + peso_de_objetos[i] <= peso_max_mochilas[id_mochila_actual])
                {
                    mask[i] = true;
                    Peso_Max_A_Llevar(peso_de_objetos, cant_mochilas, peso_max_mochilas, mask, id_mochila_actual, peso_llevado_mochila_actual + peso_de_objetos[i], peso_total_llevado + peso_de_objetos[i], ref result);
                    mask[i] = false;
                }
            }
        }
        if (id_mochila_actual < cant_mochilas - 1)
        {
            Peso_Max_A_Llevar(peso_de_objetos, cant_mochilas, peso_max_mochilas, mask, id_mochila_actual + 1, 0, peso_total_llevado, ref result);
        }
        if (peso_total_llevado > result)
            result = peso_total_llevado;
    }
}
