using Equisde;
using System.Diagnostics;
using RANA;
using Variacion;
using MURALLA;
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


System.Console.WriteLine("started");
var start = DateTime.Now.Ticks;

//Variacion.Katrib.Combinaciones(new int[2], new bool[4], 0, 0, new int[] { 1, 2, 3, 4 });
// Variacion.Katrib.Combinaciones(new int[2], 0, 0, new int[] { 1, 3, 5, 6 });
// Console.WriteLine();
// Variacion.Katrib.VariacionesSinRepeticiones(new int[2], new bool[4], 0, new int[] { 1, 3, 5, 6 });
int[] secciones1 = { 8, 1, 4, 9, 3 };
int constructores1 = 3;
int result = int.MaxValue;
MURALLA.MURALLA.MinTimeBuild(secciones1, constructores1, 0, 0, new int[constructores1], ref result);
Console.WriteLine(result);
Debug.Assert(result == 12);

Console.WriteLine("Ok");