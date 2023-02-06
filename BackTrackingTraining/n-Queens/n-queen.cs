namespace QueensN;

public static class Nqueen
{
    public static int MaxNumberOfQueenIn(int dimensionDeTablero)
    {
        int result = 0;
        bool[,] tablero = new bool[dimensionDeTablero, dimensionDeTablero];
        MaxNumberOfQueenIn(dimensionDeTablero, tablero, ref result, 0, 0);
        return result;
    }
    private static void MaxNumberOfQueenIn(int dimensionDeTablero, bool[,] tablero, ref int result, int puestas, int filaActual)
    {
        if (filaActual == dimensionDeTablero)
        {
            if (puestas > result) result = puestas;
            return;
        }

        for (int colActual = 0; colActual < dimensionDeTablero; colActual++)
        {
            if (PositionIsValid(filaActual, colActual, tablero))
            {
                tablero[filaActual, colActual] = true;
                MaxNumberOfQueenIn(dimensionDeTablero, tablero, ref result, puestas + 1, filaActual + 1);
                tablero[filaActual, colActual] = false;
            }
        }
        // if (filaActual + 1 <= dimensionDeTablero)
        //     MaxNumberOfQueenIn(dimensionDeTablero, tablero, ref result, puestas, filaActual + 1);
    }
    private static bool PositionIsValid(int filaActual, int colActual, bool[,] tablero)
    {
        for (int fila = 0; fila < tablero.GetLength(0); fila++)
        {
            for (int col = 0; col < tablero.GetLength(0); col++)
            {
                if (tablero[fila, col])
                {
                    if (HayInterferencia(filaActual, colActual, fila, col, tablero))
                    { return false; }
                }
            }
        }
        return true;
    }
    private static bool HayInterferencia(int filaDondePoner, int colDondePoner, int filaDeReinaPuesta, int colDeReinaPuesta, bool[,] tablero)
    {
        int[] arrDirCol = { -1, 0, 1 };
        for (int i = 0; i < arrDirCol.Length; i++)
        {
            for (int fila = filaDeReinaPuesta, col = colDeReinaPuesta; fila < tablero.GetLength(0) && col >= 0 && col < tablero.GetLength(0); fila++, col += arrDirCol[i])
            {
                if (fila == filaDondePoner && col == colDondePoner)
                {
                    return true;
                }
            }
        }
        return false;
    }
}