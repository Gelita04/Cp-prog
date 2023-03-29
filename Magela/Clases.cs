namespace Clases;
public class Polinomio
{
    public string Name { get; set; }
    public int[] _polinomio { get; set; }
    public int Grado { get; set; }

    public Polinomio(string name, int[] polinomio, int grado)
    {
        Name = name;
        _polinomio = polinomio;
        Grado = grado;
    }







    public static Polinomio Suma(Polinomio a, Polinomio b)
    {

        Polinomio result = new Polinomio("result", new int[Math.Max(a.Grado, b.Grado) + 1], Math.Max(a.Grado, b.Grado));

        for (int i = 0; i < result._polinomio.Length; i++)
        {
            if (i == a._polinomio.Length)
            {
                for (int j = i; j < b._polinomio.Length; j++)
                {
                    result._polinomio[j] = b._polinomio[j];

                }
                break;
            }
            if (i == b._polinomio.Length)
            {
                for (int j = i; j < a._polinomio.Length; j++)
                {
                    result._polinomio[j] = a._polinomio[j];
                }
                break;
            }

            result._polinomio[i] = a._polinomio[i] + b._polinomio[i];

        }

        return result;
    }
    public static Polinomio Resta(Polinomio a, Polinomio b)
    {

        Polinomio result = new Polinomio("result", new int[Math.Max(a.Grado, b.Grado) + 1], Math.Max(a.Grado, b.Grado));

        for (int i = 0; i < result._polinomio.Length; i++)
        {
            if (i == a._polinomio.Length)
            {
                for (int j = i; j < b._polinomio.Length; j++)
                {
                    result._polinomio[j] = b._polinomio[j];

                }
                break;
            }
            if (i == b._polinomio.Length)
            {
                for (int j = i; j < a._polinomio.Length; j++)
                {
                    result._polinomio[j] = a._polinomio[j];
                }
                break;
            }

            result._polinomio[i] = a._polinomio[i] - b._polinomio[i];

        }

        return result;


    }
}