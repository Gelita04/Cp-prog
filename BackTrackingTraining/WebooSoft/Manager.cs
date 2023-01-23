namespace Manager;
public static class Manager
{
    public static double DuracionProyecto(int[] tareas, double[,] desarrolladores)
    {
        double result = int.MaxValue;
        int[] devAssignment = new int[tareas.Length];
        DuracionProyecto(tareas, desarrolladores, devAssignment, 0, ref result);
        return result;
    }
    private static void DuracionProyecto(int[] tareas, double[,] desarrolladores, int[] devAssignment, int devOcupad, ref double result)
    {
        if (devOcupad == tareas.Length)
        {
            double temp = GetDuration(devAssignment, tareas, desarrolladores, devOcupad);
            if (temp < result)
                result = temp;
            return;
        }

        for (int i = 0; i < desarrolladores.GetLength(0); i++)
        {

            devAssignment[devOcupad] = i;
            if (GetDuration(devAssignment, tareas, desarrolladores, devOcupad) > result)
                continue;
            DuracionProyecto(tareas, desarrolladores, devAssignment, devOcupad + 1, ref result);
        }
    }

    private static double GetDuration(int[] devAssignment, int[] tareas, double[,] desarrolladores, int sizeOfDevAssignment)
    {
        double result = 0;
        for (int dev = 0; dev < sizeOfDevAssignment; dev++)
        {
            double devDuration = 0;

            for (int task = 0; task < sizeOfDevAssignment; task++)
            {
                if (devAssignment[task] == dev)
                { devDuration += tareas[task] * desarrolladores[dev, task]; }
            }

            if (devDuration > result)
                result = devDuration;
        }
        return result;
    }
}