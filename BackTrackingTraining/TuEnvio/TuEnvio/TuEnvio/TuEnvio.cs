namespace Weboo.Examen
{
    public class TuEnvio
    {
        public static int CombustibleDiario(int[] pesos, int[,] combustible)
        {
            int result = int.MaxValue;
            bool[] mask = new bool[pesos.Length];
            CombustibleDiario(pesos, mask, combustible, 0, 0, 0, 0, ref result);

            if (result == int.MaxValue)
                return -1;
            return result;

        }
        static void CombustibleDiario(int[] pesos, bool[] mask, int[,] combustible, int combustibleGastado, int actualCoordinates, int pesoActual, int visitadas, ref int result)
        {
            if (combustibleGastado > result || pesoActual > pesos[0])
                return;

            if (visitadas == mask.Length - 1)
            {
                if (combustibleGastado + combustible[actualCoordinates, 0] < result)
                    result = combustibleGastado + combustible[actualCoordinates, 0];
                return;
            }
            for (int i = 1; i < combustible.GetLength(0); i++)
            {
                if (!mask[i])
                {
                    mask[i] = true;
                    CombustibleDiario(pesos, mask, combustible, combustibleGastado + combustible[actualCoordinates, i], i, pesoActual + pesos[i], visitadas + 1, ref result);
                    mask[i] = false;
                }
            }
            if (actualCoordinates != 0)
                CombustibleDiario(pesos, mask, combustible, combustibleGastado + combustible[actualCoordinates, 0], 0, 0, visitadas, ref result);
        }
    }
}
