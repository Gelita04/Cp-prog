// MDVRP
// Este tipo de problema es similar al VRP (ruteo de N vehículos con un depósito único y clientes con demanda preestablecida
// y sin ventanas de tiempo) con la diferencia de que se tiene un conjunto de depósitos y no un depósito único como ocurría en
// el caso anterior. De esta forma tenemos una flota de M vehículos que salen de D depósitos y deben satisfacer la demanda de
// N nodos. Los vehículos deben salir de un depósito y volver al mismo.
// Los ejemplos prácticos de aplicación son similares a los del VRP pero para empresas más grandes que tengan varios
// depósitos. Un ejemplo sería un supermercado que en una ciudad tenga varias sucursales y recepcione (por internet por ej.)
// pedidos de sus clientes. Dada la demanda y ubicación geográfica de cada cliente se formarán las rutas a recorrer por cada
// vehículo de reparto de mercadería que saldrán de las diferentes sucursales del supermercado.

namespace N_Depositos_M_Carritos;
public static class N_Depositos
{
    static int NDeposits(int[] posiciones_depositos, int total_trabajadores, int[,] combustible)
    {
        int result = int.MaxValue;
        bool[] mask = new bool[combustible.GetLength(0)];
        N_Deposits(mask, posiciones_depositos, 0, total_trabajadores, 0, combustible, ref result, posiciones_depositos[0], 0, 0);
        return result;
    }
    static void N_Deposits(bool[] mask, int[] posiciones_depositos, int id_deposito_actual, int total_trabajadores, int id_trabajador_actual, int[,] combustible, ref int result, int posicion_actual, int visitadas, int combustible_total)
    {
        //OOOOOOOOOOOOOOOJJJJJJJJJJOOOOOOOOOOOOOOOOOO PROBAR HACER EL PROBLEMA DE ALIMENTANDO LEONES PUDIENDO IR AL DEPOSITO N VECES EN VEZ DE UNA SOLA VEZ SOLAMENTE
        if (visitadas == combustible.GetLength(0) - posiciones_depositos.Length)
        {
            int temp = combustible_total + combustible[posicion_actual, posiciones_depositos[id_deposito_actual]];

            if (temp < result) result = temp;
            return;
        }

        for (int posicion_a_viajar = 0; posicion_a_viajar < combustible.GetLength(0); posicion_a_viajar++)
        {
            if (posicion_a_viajar == posiciones_depositos[id_deposito_actual])
                continue;
            if (!mask[posicion_a_viajar])
            {
                mask[posicion_a_viajar] = true;
                N_Deposits(mask, posiciones_depositos, id_deposito_actual, total_trabajadores, id_trabajador_actual, combustible, ref result, posicion_a_viajar, visitadas + 1, combustible_total + combustible[posicion_actual, posicion_a_viajar]);
                mask[posicion_a_viajar] = false;
            }
        }
        //no toy seguro este bien(en realidad no toy seguro de nada xd)
        if (id_trabajador_actual < total_trabajadores - 1)
        {
            N_Deposits(mask, posiciones_depositos, id_deposito_actual, total_trabajadores, id_trabajador_actual + 1, combustible, ref result, posiciones_depositos[id_deposito_actual], visitadas, combustible_total + combustible[posicion_actual, posiciones_depositos[id_deposito_actual]]);
        }
        if (id_deposito_actual < posiciones_depositos.Length - 1)
        {
            N_Deposits(mask, posiciones_depositos, id_deposito_actual + 1, total_trabajadores, id_trabajador_actual + 1, combustible, ref result, posiciones_depositos[id_deposito_actual + 1], visitadas, combustible_total + combustible[posicion_actual, posiciones_depositos[id_deposito_actual + 1]]);
        }
    }
}
