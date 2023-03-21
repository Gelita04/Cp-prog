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

    public static int TheWall(int[] secciones, int trabajadores)
    {
        int result = int.MaxValue;
        int[] track = new int[secciones.Length + trabajadores - 1];
        TheWall(track, secciones, trabajadores, 0, ref result, 0, -1, 0, 0);
        return result;
    }
    private static void TheWall(int[] track, int[] secciones, int trabajadores, int id_trabajador_actual, ref int result, int checkpoints, int a_viajar, int tiempo_actual, int tiempo_total)
    {

        if (checkpoints == secciones.Length)//analizar 
        {
            if (tiempo_total < result)
            { result = tiempo_total; }
            if (result == 12)
            { }
            return;
        }

        if (tiempo_total > result)
            return;

        
        TheWall(track, secciones, trabajadores, id_trabajador_actual, ref result, checkpoints + 1, a_viajar + 1, tiempo_actual + secciones[a_viajar + 1], Math.Max(tiempo_actual + secciones[a_viajar + 1], tiempo_total));
        track[checkpoints] = 0;
        if (id_trabajador_actual < trabajadores - 1 && checkpoints > id_trabajador_actual)
        {
            track[checkpoints] = -1;
            TheWall(track, secciones, trabajadores, id_trabajador_actual + 1, ref result, checkpoints, a_viajar, 0, tiempo_total);
            track[checkpoints] = 0;
        }
    }
    private static void TheWallGod(int[] track, int[] secciones, int trabajadores, int id_trabajador_actual, ref int result, int checkpoints, int a_viajar, int tiempo_actual, int tiempo_total)
    {

        if (checkpoints == secciones.Length)//analizar 
        {
            if (tiempo_total < result)
                result = tiempo_total;
            return;
        }

        if (tiempo_total > result) return;

        TheWall(track, secciones, trabajadores, id_trabajador_actual, ref result, checkpoints + 1, a_viajar + 1, tiempo_actual + secciones[a_viajar], Math.Max(tiempo_actual + secciones[a_viajar], tiempo_total));

        if (id_trabajador_actual < trabajadores - 1 && checkpoints > id_trabajador_actual)
            TheWall(track, secciones, trabajadores, id_trabajador_actual + 1, ref result, checkpoints, a_viajar, 0, tiempo_total);

    }
}