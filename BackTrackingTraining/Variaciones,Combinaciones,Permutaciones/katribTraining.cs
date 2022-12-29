namespace Variacion

{
    public static class Katrib
    {
        public static void VariacionesSinRepeticiones(int[] variacion, bool[] visited, int position, params int[] arr)//permut si length de permut es == length arr
        {
            if (position >= variacion.Length)
            {
                Print(variacion);
                return;
            }
            for (int i = 0; i < arr.Length; i++)
            {
                if (!visited[i])
                {
                    visited[i] = true;
                    variacion[position] = arr[i];
                    VariacionesSinRepeticiones(variacion, visited, position + 1, arr);
                    visited[i] = false;
                }
            }
        }
        public static void Combinaciones(int[] combinacion, int position, int minToPut, params int[] arr)
        {
            if (position >= combinacion.Length)
            {
                Print(combinacion);
                return;
            }
            for (int i = minToPut; i < arr.Length; i++)
            {
                combinacion[position] = arr[i];
                Combinaciones(combinacion, position + 1, i + 1, arr);
            }
        }
        public static void ConjPotencia(params int[] arr)
        {
            for (int m = 0; m < arr.Length; m++)
            {
                Combinaciones(new int[m], 0, 0, arr);
            }
        }
        private static void Print(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write(item);
            }
            Console.WriteLine();
        }
    }
}