namespace MURALLA;

public static class MURALLA
{
    public static void MinTimeBuild(int[] murallas, int trabajadores, int position, int minToPut, int[] combinations, ref int actualMinTime)
    {
        if (position >= trabajadores)
        {
            int actualResult = TimeToBuild(murallas, combinations);
            if (actualResult < actualMinTime)
                actualMinTime = actualResult;
            return;
        }

        for (int i = minToPut; i < murallas.Length; i++)
        {
            if (position == 0 && i != 0)
            { return; }
            combinations[position] = i;
            MinTimeBuild(murallas, trabajadores, position + 1, i + 1, combinations, ref actualMinTime);
        }
    }
    static int TimeToBuild(int[] murallas, int[] combinations)
    {
        int result = int.MinValue;
        for (int trabajador = 0; trabajador < combinations.Length; trabajador++)
        {
            int actualResult = 0;

            int actualTrabajador = combinations[trabajador];
            int limiteDelTrabajador = trabajador + 1 == combinations.Length ? murallas.Length : combinations[trabajador + 1];

            for (int murallaActual = actualTrabajador; murallaActual < limiteDelTrabajador; murallaActual++)
            {
                actualResult += murallas[murallaActual];
            }

            if (actualResult > result)
                result = actualResult;
        }
        return result;
    }


}