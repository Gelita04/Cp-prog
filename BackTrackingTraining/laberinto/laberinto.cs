namespace Laberinto;
public static class Laberinto
{
    static int Lab(bool[,] map, int columnactual, int filactual)
    {
        int result = int.MaxValue;
        Auxiliar(map, columnactual, filactual, 0, ref result);
        return result;
    }
    static void Auxiliar(bool[,] map, int columnactual, int filactual, int count, ref int result)
    {

        if (filactual == map.GetLength(0) - 1 && columnactual == map.GetLength(1) - 1)
        {
            if (result > count)
            {
                result = count;
            }
            return;
        }
        if (filactual + 1 >= 0 && filactual + 1 < map.GetLength(0) && !map[filactual + 1, columnactual])
        {
            map[filactual + 1, columnactual] = true;
            Auxiliar(map, filactual + 1, columnactual, count + 1, ref result);
            map[filactual + 1, columnactual] = false;
        }
        if (filactual - 1 >= 0 && filactual - 1 < map.GetLength(0) && !map[filactual - 1, columnactual])
        {
            map[filactual - 1, columnactual] = true;
            Auxiliar(map, filactual - 1, columnactual, count + 1, ref result);
            map[filactual - 1, columnactual] = false;
        }
        if (columnactual + 1 >= 0 && columnactual + 1 < map.GetLength(1) && !map[filactual, columnactual + 1])
        {
            map[filactual, columnactual + 1] = true;
            Auxiliar(map, filactual, columnactual + 1, count + 1, ref result);
            map[filactual, columnactual + 1] = false;
        }
        if (columnactual - 1 >= 0 && columnactual - 1 < map.GetLength(1) && !map[filactual, columnactual - 1])
        {
            map[filactual, columnactual - 1] = true;
            Auxiliar(map, filactual, columnactual - 1, count + 1, ref result);
            map[filactual, columnactual - 1] = false;
        }

    }
}
