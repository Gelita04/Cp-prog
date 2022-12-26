using System.Diagnostics;
//Cambia aca abajo el nombre por el del cs para cambiar los metodos.....o descomenta y comenta
using MetodosFranco;
//using MetodosMauri;

//implementa la solucion en MetodosFranco.cs - Todos los metodos
//deben ser estaticos(hice la clase estatica, notese q no se instancia nunca)

System.Console.WriteLine("started");
var start = DateTime.Now.Ticks;

//DESCOMENTA ESTO CUANDO SIENTAS Q TODO TA LINDO
//int resultado1 = Charco.ComiendoChocolates(new bool[,] {
//{ false, false, false, false, false, false, false, false },
//{ false, false, true, false, false, true, false, false },
//{ false, true, false, false, true, false, true, false },
//{ false, false, true, false, false, false, false, true },
//{ false, false, false, false, false, false, false, false }
//}, new int[] { 1, 3, 6 });

 int resultado2 = Charco.ComiendoChocolates(new bool[,] {
 { false, false, false, false, false, false, false, false },
 { false, false, true, false, false, true, false, false },
 { false, true, false, false, true, false, true, false },
 { true, false, true, false, false, false, false, true }
 }, new int[] { 1, 3, 6 });

 int resultado3 = Charco.ComiendoChocolates(new bool[,] {
 { false, false, false, false, false, false, false, false },
 { false, false, false, false, false, true, false, true },
 { false, false, false, false, false, false, true, false },
 { false, false, false, false, false, false, false, true }
 }, new int[] { 1, 3 });

double time = (double)(DateTime.Now.Ticks - start) / 1000000;
System.Console.WriteLine($"ended in {time} secs");

//Para cuando descomentes el 1 arriba
//Debug.Assert(resultado1 == 7);
Debug.Assert(resultado2 == 7);
Debug.Assert(resultado3 == 0);

System.Console.WriteLine($"OK");


