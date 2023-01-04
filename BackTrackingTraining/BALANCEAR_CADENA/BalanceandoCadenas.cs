namespace Balancear_Cadena;

public static class Balancear_Cadena
{

    public static int MinOperacionesBC(string cadena)
    {
        int result = int.MaxValue;
        MinOperacionesBC(cadena.ToCharArray(), 0, 0, ref result);
        if (result == int.MaxValue)
            return -1;
        return result;
    }

    public static void MinOperacionesBC(char[] cadena, int viajes, int position, ref int result)
    {
        char[] keyChars = { '(', ')', '[', ']', '{', '}' };

        // if (cadena[0] == '[' && cadena[1] == '{' && cadena[2] == '}' && cadena[3] == ']' && cadena[4] == '{' && cadena[5] == '{' && cadena[6] == '}' && cadena[7] == '}')
        //     Console.WriteLine("IsValid");
        if (IsBalanced(cadena))
        {
            Console.WriteLine("caso balanceado");
            if (viajes < result)
                result = viajes;
            return;
        }
        if (position >= cadena.Length)
            return;

        for (int i = 0; i < 6; i++)
        {
            if (viajes > result)
            {
                continue;
            }
            MinOperacionesBC(ModifiedCadena(cadena, i, position, keyChars), keyChars[i] == cadena[position] ? viajes : viajes + 1, position + 1, ref result);
        }
    }

    static char[] ModifiedCadena(char[] cadena, int keyCharsCoord, int position, char[] keyChars)
    {
        char[] result = (char[])cadena.Clone();
        result[position] = keyChars[keyCharsCoord];
        return result;
    }

    // public static int MinLeoMode(string cadena)
    // {
    //     return MinLeoMode(cadena.ToCharArray(), 0, 0);
    // }
    // static void Print(char[] cadena)
    // {
    //     foreach (var item in cadena)
    //     {
    //         Console.Write(item);
    //     }
    // }

    // public static int MinLeoMode(char[] cadena, int viajes, int position)
    // {
    //     if (cadena[0] == '{' && cadena[1] == '}' && cadena[2] == '[' && cadena[3] == ']')
    //     {
    //         Console.WriteLine("xd");
    //     }
    //     if (IsBalanced(cadena))
    //     {
    //         Print(cadena);
    //         Console.WriteLine(viajes);
    //         Console.WriteLine();
    //         Console.WriteLine("------------------");
    //         Console.WriteLine();
    //         return viajes;
    //     }
    //     if (position >= cadena.Length)
    //         return -1;


    //     char[][] PossibleWays = GetPossibleWays(cadena, position);
    //     int[] results = new int[PossibleWays.Length];

    //     for (int i = 0; i < PossibleWays.Length; i++)
    //     {
    //         results[i] = MinLeoMode(PossibleWays[i], viajes + 1, position + 1);
    //     }

    //     if (results.All(x => x == -1))
    //         return -1;
    //     else
    //         return results.Min();
    // }


    // static char[][] GetPossibleWays(char[] cadena, int position)
    // {
    //     char[] keyChars = { '(', ')', '[', ']', '{', '}' };
    //     List<char[]> results = new List<char[]>();
    //     for (int i = 0; i < keyChars.Length; i++)
    //     {
    //         char[] temp = (char[])cadena.Clone();

    //         if (temp[position] == keyChars[i])
    //             continue;

    //         temp[position] = keyChars[i];
    //         results.Add(temp);
    //     }
    //     return results.ToArray();
    // }

    static bool IsBalanced(char[] cadena)
    {
        if (cadena.First() == ')' || cadena.First() == '}' || cadena.First() == ']')
            return false;

        Stack<char> stack = new Stack<char>();
        for (int i = 0; i < cadena.Count(); i++)
        {
            if (stack.Count != 0)
            {
                if (stack.Peek() == '(' && cadena[i] == ')')
                    stack.Pop();
                else if (stack.Peek() == '{' && cadena[i] == '}')
                    stack.Pop();
                else if (stack.Peek() == '[' && cadena[i] == ']')
                    stack.Pop();
                else
                {
                    stack.Push(cadena[i]);
                    continue;
                }

            }
            else
                stack.Push(cadena[i]);

        }

        return (stack.Count() == 0);
    }

}