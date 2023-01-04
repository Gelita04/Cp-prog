namespace Weboo.Examen
{
    public class TuEnvio
    {
        public static int CombustibleDiario(int[] pesos, int[,] combustible)
        {
            int result = int.MaxValue;
            bool[] mask = new bool[pesos.Length];
            CombustibleDiario(pesos, mask, combustible, 0, 0, 0, ref result);
            //poner caso en q returne -1
            if (result == int.MaxValue)
                return -1;
            return result;

        }
        static void CombustibleDiario(int[] pesos, bool[] mask, int[,] combustible, int combustibleGastado, int actualCoordinates, int pesoActual, ref int result)
        {

            if (IsValid(mask))
            {
                if (combustibleGastado + combustible[actualCoordinates, 0] < result)
                    result = combustibleGastado + combustible[actualCoordinates, 0];
                return;
            }
            for (int i = 1; i < combustible.GetLength(0); i++)
            {
                if (!mask[i])
                {

                    int combustibleGastadoFUt = 0;
                    int pesoFUt = 0;
                    if (i == 0)
                    {
                        combustibleGastadoFUt = combustible[actualCoordinates, i] + combustibleGastado;
                        pesoFUt = 0;
                    }
                    else
                    {
                        if (pesoActual + pesos[i] > pesos[0])
                        {
                            combustibleGastadoFUt = combustible[actualCoordinates, 0] + combustible[0, i] + combustibleGastado;
                            pesoFUt = pesos[i];
                        }
                        else
                        {
                            combustibleGastadoFUt = combustible[actualCoordinates, i] + combustibleGastado;
                            pesoFUt = pesoActual + pesos[i];
                        }
                    }

                    if (combustibleGastadoFUt > result)
                        continue;

                    mask[i] = true;
                    CombustibleDiario(pesos, mask, combustible, combustible[actualCoordinates, 0] + combustible[0, i] + combustibleGastado, i, pesos[i], ref result);
                    mask[i] = false;

                    mask[i] = true;
                    CombustibleDiario(pesos, mask, combustible, combustibleGastadoFUt, i, pesoFUt, ref result);
                    mask[i] = false;
                }
            }
        }
        static bool IsValid(bool[] mask)
        {
            for (int i = 1; i < mask.Length; i++)
            {
                if (!mask[i])
                    return false;
            }
            return true;
        }
    }
}
