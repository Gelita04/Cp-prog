using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weboo.Examen
{
    public static class ProblemaAntorchas
    {
        public static IEnumerable<int> AsignaAntorchas(bool[,] mapa)
        {
            var start = DateTime.Now.Ticks;

            List<int> result = new List<int>();

            for (int i = 1; i <= mapa.GetLength(0); i++)
            {
                if (AsignaAntorchas(mapa, result, new int[i], 0, 0, (double)start))
                {
                    return result;
                }
            }
            return result;
        }

        private static bool AsignaAntorchas(bool[,] mapa, List<int> result, int[] regions, int actualsize, int lastIndex, double start)
        {
            if (regions.Length == actualsize)
            {

                if (GetEffectivity(mapa, regions, start))
                {
                    FillResultListWithRegions(result, regions);
                    return true;
                }
                return false;
            }
            for (int i = lastIndex; i < mapa.GetLength(0); i++)
            {
                regions[actualsize] = i;
                if (AsignaAntorchas(mapa, result, regions, actualsize + 1, i + 1, start))
                    return true;
            }
            return false;
        }

        private static bool GetEffectivity(bool[,] mapa, int[] regions, double start)
        {
            bool[] regionsWithLigth = new bool[mapa.GetLength(0)];

            foreach (var region in regions)
            {
                regionsWithLigth[region] = true;
                for (int i = 0; i < mapa.GetLength(0); i++)
                {
                    if (mapa[region, i])
                        regionsWithLigth[i] = true;
                }
            }

            System.Console.WriteLine(((double)DateTime.Now.Ticks - (double)start) / (double)10000000);
            return regionsWithLigth.All(x => x);
        }
        private static void FillResultListWithRegions(List<int> result, int[] regions)
        {
            result.Clear();
            foreach (var region in regions)
            {
                result.Add(region);
            }
        }
    }
}
