namespace viajante;
public static class Viajante
{
    public static void ElVijante(int[,] Gasolina)
    {

    }
    public static void Auxiliar(int[,] Gasolina, bool[] Mask_Citys, int ciudad_actual, int count)
    {
        for (int i = 1 ; i < Mask_Citys.Length; i++)
        {
            if (!Mask_Citys[i])
            {

                Mask_Citys[i] = true;
                Auxiliar(Gasolina,Mask_Citys,, count);
                Mask_Citys[i]= false;
                
            }
        }
    }
}