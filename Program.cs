using Equisde;
using System.Diagnostics;
using RANA;
using Variacion;
using MURALLA;
using NivelandoTerreno;
using Balancear_Cadena;
using Weboo.Examen;
using WIFI;

//Arbol de Prueba//////////////////////////////////////

// BinaryTree<int> arbol =
// new BinaryTree<int>(1,
//     new BinaryTree<int>(2,
//         new BinaryTree<int>(5),
//         new BinaryTree<int>(4)),
//     new BinaryTree<int>(8,
//         new BinaryTree<int>(7),
//         new BinaryTree<int>(10, null
//             ,
//             new BinaryTree<int>(11))));

//System.Console.WriteLine(arbol.Inversions());


//Rana//////////////////////////////////////////////////////////

//Cambia aca abajo el nombre por el del cs para cambiar los metodos.....o descomenta y comenta

//using MetodosMauri;

//implementa la solucion en MetodosFranco.cs - Todos los metodos
//deben ser estaticos(hice la clase estatica, notese q no se instancia nunca)

// System.Console.WriteLine("started");
// var start = DateTime.Now.Ticks;

// DESCOMENTA ESTO CUANDO SIENTAS Q TODO TA LINDO
// int resultado1 = Charco.ComiendoChocolates(new bool[,] {
// { false, false, false, false, false, false, false, false },
// { false, false, true, false, false, true, false, false },
// { false, true, false, false, true, false, true, false },
// { false, false, true, false, false, false, false, true },
// { false, false, false, false, false, false, false, false }
// }, new int[] { 1, 3, 6 });

// int resultado2 = Charco.ComiendoChocolates(new bool[,] {
//             //           //                   //
//  { false, false, false, false, false, false, false, false },
//  { false, false, true, false, false, true, false, false },
//  { false, true, false, false, true, false, true, false },
//  { true, false, true, false, false, false, false, true }
//  }, new int[] { 1, 3, 6 });

// int resultado3 = Charco.ComiendoChocolates(new bool[,] {
//  { false, false, false, false, false, false, false, false },
//  { false, false, false, false, false, true, false, true },
//  { false, false, false, false, false, false, true, false },
//  { false, false, false, false, false, false, false, true }
//  }, new int[] { 1, 3 });

// double time = (double)(DateTime.Now.Ticks - start) / 1000000;
// System.Console.WriteLine($"ended in {time} secs");

// //Para cuando descomentes el 1 arriba
// Console.WriteLine(resultado1);
// Debug.Assert(resultado1 == 7);
// System.Console.WriteLine($"OK");

// Console.WriteLine(resultado2);
// Debug.Assert(resultado2 == 7);
// System.Console.WriteLine($"OK");

// Console.WriteLine(resultado3);
// Debug.Assert(resultado3 == 0);
// System.Console.WriteLine($"OK");


////////////////////////////////////////////////


//Katrib
//Variacion.Katrib.Combinaciones(new int[2], new bool[4], 0, 0, new int[] { 1, 2, 3, 4 });
// Variacion.Katrib.Combinaciones(new int[2], 0, 0, new int[] { 1, 3, 5, 6 });
// Console.WriteLine();
// Variacion.Katrib.VariacionesSinRepeticiones(new int[2], new bool[4], 0, new int[] { 1, 3, 5, 6 });


/////////////////////////////////////////////////


//Muralla
// int[] secciones1 = { 8, 1, 4, 9, 3 };
// int constructores1 = 3;
// int result = int.MaxValue;
// MURALLA.MURALLA.MinTimeBuild(secciones1, constructores1, 0, 0, new int[constructores1], ref result);
// Console.WriteLine(result);
// Debug.Assert(result == 12);


//////////////////////////////////////////////////


//Nivelar Terreno Robot

// int[] parcelas = { 1, 1, 2, 3, 2, 2, 3, 2, 2 };
// int result = NivelarTerreno.NT(parcelas);
// Debug.Assert(result == 4);
// Console.WriteLine("Ok");

// string test = "])[]{(()(]{}[[{]}][)";
// int result = Balancear_Cadena.Balancear_Cadena.MinOperacionesBC(test);
// Console.WriteLine(result);
// Debug.Assert(result == 6);
// Console.WriteLine("Ok");



//////////////////////////////////////////////


//TUENVIO
// Test(
//             // Pesos
//             new[] { 10, 3, 3, 3, 3 },
//             // Combustible
//             new[,]
//             {
//                 { 0, 2, 2, 3, 3 },
//                 { 2, 0, 1, 4, 4 },
//                 { 2, 1, 0, 4, 4 },
//                 { 3, 4, 4, 0, 2 },
//                 { 3, 4, 4, 2, 0 },
//             },
//             // Resultado esperado
//             13
//         );

// // Ejemplo2
// Test(
//     // Pesos
//     new[] { 20, 15, 10, 13, 17 },
//     // Combustible
//     new[,]
//     {
//                 { 0, 4, 3, 1, 2 },
//                 { 4, 0, 3, 3, 4 },
//                 { 3, 3, 0, 2, 5 },
//                 { 1, 3, 2, 0, 3 },
//                 { 2, 4, 5, 3, 0 },
//     },
//     // Resultado esperado
//     20
// );

// static void Test(int[] pesos, int[,] combustible, int esperado)
// {
//     try
//     {
//         var resultado = TuEnvio.CombustibleDiario(pesos, combustible);

//         if (resultado != esperado)
//         {
//             throw new Exception($"Se esperaba {esperado} pero se obtuvo {resultado}");
//         }

//         Console.WriteLine($"🟢 Resultado correcto: {resultado}");
//     }
//     catch (Exception e)
//     {
//         Console.WriteLine($"🔴 {e}");
//     }
// }


//////////////////////////////////////////


//WIFI_UH

System.Console.WriteLine("started");
var start = DateTime.Now.Ticks;

bool[,] area = new bool[7, 11];
area[2, 2] = true;
area[4, 2] = true;
area[3, 7] = true;

int[] alcances = { 2, 1, 1 };

Console.WriteLine(WIFIUH.CubrirArea(area,alcances));



