namespace WIFI;

public static class WIFIUH
{

    public static int CubrirArea(bool[,] area, int[] alcances)
    {
        int result = 0;
        bool[] marked = new bool[alcances.Length];
        int[,] places = GetPlaces(area);
        CubrirArea(area, places, alcances, marked, ref result, 0, (int[])alcances.Clone());
        return result;
    }
    static void CubrirArea(bool[,] area, int[,] coordToPlant, int[] alcances, bool[] marked, ref int result, int APsPlanted, int[] actualWifiUbicationOrder)
    {
        if (APsPlanted == coordToPlant.GetLength(1))
        {
            int possibleResult = GetArea(area, coordToPlant, actualWifiUbicationOrder);

            if (possibleResult > result)
                result = possibleResult;
            return;
        }

        for (int i = 0; i < marked.Length; i++)
        {
            if (!marked[i])
            {
                marked[i] = true;
                actualWifiUbicationOrder[APsPlanted] = alcances[i];
                CubrirArea(area, coordToPlant, alcances, marked, ref result, APsPlanted + 1, actualWifiUbicationOrder);
                marked[i] = false;
            }
        }
    }
    static int[,] GetPlaces(bool[,] area)
    {
        List<int> result = new List<int>();

        for (int i = 0; i < area.GetLength(0); i++)
        {
            for (int j = 0; j < area.GetLength(1); j++)
            {
                if (area[i, j])
                {
                    result.Add(i);
                    result.Add(j);
                }
            }
        }
        int[,] realResult = new int[2, result.Count() / 2];

        for (int j = 0, i = 0; j < realResult.GetLength(1); j++, i += 2)
        {
            realResult[0, j] = result[i];
            realResult[1, j] = result[i + 1];
        }
        return realResult;
    }

    static int GetArea(bool[,] area, int[,] coordToPlant, int[] actualWifiUbicationOrder)
    {
        int result = 0;
        for (int i = 0; i < area.GetLength(0); i++)
        {
            for (int j = 0; j < area.GetLength(1); j++)
            {
                for (int k = 0; k < coordToPlant.GetLength(1); k++)
                {
                    if (Math.Abs(i - coordToPlant[0, k]) <= actualWifiUbicationOrder[k] && Math.Abs(j - coordToPlant[1, k]) <= actualWifiUbicationOrder[k])
                    {
                        result += 1;
                        break;
                    }
                }
            }
        }
        return result;
    }

    // public static int NewMethod(bool[,] area, int[] alcances)
    // {
    //     int result = 0;
    //     int[,] places = GetPlaces(area);
    //     bool[] mask = new bool[places.GetLength(0)];
    //     NewMethod(area, mask, 0, alcances, places, ref result, 0, 0);
    //     return result;
    // }
    // private static void NewMethod(bool[,] area, bool[] mask, int id_ap_actual, int[] alcances, int[,] places, ref int result, int puestos, int alcance_total)
    // {
    //     if (puestos == places.GetLength(0))
    //     {
    //         if (alcance_total > result)
    //         {
    //             result = alcance_total;
    //         }
    //     }

    //     for (int i = 0; i < places.GetLength(0); i++)
    //     {
    //         if (!mask[i])
    //         {
    //             mask[i] = true;
    //             NewMethod(area, mask, id_ap_actual + 1, alcances, places, ref result, puestos + 1, alcance_total + GetAlcance(i, places, id_ap_actual));
    //             mask[i] = false;
    //         }
    //     }

    //     if (id_ap_actual < alcances.Length - 1)
    //     {

    //     }
    // }
}








