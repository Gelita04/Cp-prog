using Equisde;
using System.Diagnostics;
using RANA;
using Variacion;
using MURALLA;
using NivelandoTerreno;
using Balancear_Cadena;
using Weboo.Examen;
using WIFI;
using Manager;
using filesystem;
using QueensN;
using System;

static void Test(int[] datos_trabajadores, int[] posicion_depositos, int[,] combustible, int esperado)
{
    try
    {
        var resultado = N_Depositos_M_Carritos.N_Depositos.N_Deposits(posicion_depositos, datos_trabajadores.Length, combustible);

        if (resultado != esperado)
        {
            throw new Exception($"Se esperaba {esperado} pero se obtuvo {resultado}");
        }

        Console.WriteLine($"🟢 Resultado correcto: {resultado}");
    }
    catch (Exception e)
    {
        Console.WriteLine($"🔴 {e}");
    }
}

int[,] matrix = new int[,]{{0 , 1,-1,-1,-1,-1,-1},
                           {2 ,0 ,-1 ,2 ,-1,-1,-1},
                           {-1,-1 ,0 ,3 ,2 , 4, 2},
                           {-1,3 ,3 ,0 ,-1,-1,-1},
                           {-1,-1,1 ,-1,0 ,6 ,-1},
                           {-1,-1,3 ,-1,3 ,0 ,-1},
                           {-1,-1,4 ,-1,-1,-1,0 }
                           };
//Console.WriteLine(No_Simetrica.ViajanteMod.MenorComb(matrix));
bool[,] matriz = new bool[,] { {false,true,false,false,false},
                               {true,false,true,true,false},
                               {false,true,false,false,false},
                               {false,true,false,false,true},
                               {false,false,false,true,false}};


Console.WriteLine(Mapeando.Mapeando_cosas.Cant_Min_Colores(matriz, 0));

static void Print(string[,] a)
{
    for (int i = 0; i < a.GetLength(0); i++)
    {
        for (int j = 0; j < a.GetLength(1); j++)
        {
            Console.Write(a[i, j]);
        }
        Console.WriteLine();
    }
}
// Print(EjerciciosDEInternet.EjerciciosDEInternet.MagnetPuzzle(new int[] { 2, -1, -1 }, new int[] { -1, -1, 2, -1 }, new int[] { -1, -1, 2 }, new int[] { 0, -1, -1, -1 },
// new string[,] {
//     {"T","T","T"},
//     {"B","B","B"},
//     {"T","L","R"},
//     {"B","L","R"}
// }));
//Test(new int[] { 0, 0 }, new int[] { 0,2 }, matrix, 9);



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


// // DESCOMENTA ESTO CUANDO SIENTAS Q TODO TA LINDO
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

// System.Console.WriteLine("started");
// var start = DateTime.Now.Ticks;

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
// double time = (double)(DateTime.Now.Ticks - start) / 1000000;
// System.Console.WriteLine($"ended in {time} secs");

// System.Console.WriteLine("started");
// start = DateTime.Now.Ticks;

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
// time = (double)(DateTime.Now.Ticks - start) / 1000000;
// System.Console.WriteLine($"ended in {time} secs");




// ////////////////////////////////////////


// WIFI_UH



// bool[,] area = new bool[7, 11];
// area[2, 2] = true;
// area[4, 2] = true;
// area[3, 7] = true;

// int[] alcances = { 2, 1, 1 };

// Console.WriteLine(WIFIUH.CubrirArea(area, alcances));

// // Test(
// //          tareas: new[] { 5, 8, 16 },
// //          desarrolladores: new double[,]
// //          {
// //                 { 1.0, 0.5, 2.0 },
// //                 { 2.0, 1.0, 0.5 },
// //             },
// //          esperado: 9
// //      );


// // static void Test(int[] tareas, double[,] desarrolladores, double esperado)
// // {
// //     try
// //     {

// //         double resultado = Manager.Manager.DuracionProyecto(tareas, desarrolladores);
// //         if (resultado != esperado)
// //         {
// //             throw new Exception($"Se esperaba {esperado} pero se obtuvo {resultado}");
// //         }

// //         Console.WriteLine($"🟢 Resultado correcto: {resultado}");
// //     }
// //     catch (Exception e)
// //     {
// //         Console.WriteLine($"🔴 {e}");
// //     }
// // }





// // Creando un sistema de ficheros vacío
// var fs = Exam.CreateFileSystem();

// // Creando un par de carpetas en la raíz
// var root = fs.GetFolder("/");
// var home = root.CreateFolder("home");
// var tmp = root.CreateFolder("tmp");

// // Creando 10 archivos dentro de la carpeta `tmp`
// for (int i = 0; i < 10; i++)
//     tmp.CreateFile($"file{i}.tmp", 10);

// // Verificando el tamaño de `tmp`
// Debug.Assert(tmp.TotalSize() == 100);

// // Creando archivos en `home`
// home.CreateFile("picture.png", 20);
// home.CreateFile("document.docx", 150);
// home.CreateFile("virus.exe", 300);

// // Buscando un archivo concreto
// var virusFile = fs.GetFile("/home/virus.exe");
// Debug.Assert(virusFile.Name == "virus.exe");

// // Verificando el método `Find` con archivos grandes
// foreach (var file in fs.Find(file => file.Size > 50))
//     Debug.Assert(file.Size > 50);

// // Verificando el método `Find` con nombres
// foreach (var file in fs.Find(file => file.Name.EndsWith(".png")))
//     Debug.Assert(file.Name == "picture.png");

// // Ahora vamos a copiar `/tmp` para `/home` y verificar los tamaños
// fs.Copy("/tmp", "/home");
// Debug.Assert(home.TotalSize() == 570);
// Debug.Assert(fs.GetFolder("/tmp").TotalSize() ==
//              fs.GetFolder("/home/tmp").TotalSize());

// // Añade tus pruebas aquí
// // ...

// System.Console.WriteLine("started");

// bool T = true;
// bool F = false;

// // 0  1  2  3  4  5
// bool[,] dungeons1 = {{F, F, T, F, F, F },    //0
//                 /*  0  1  */     {F, F, F, T, F, F },    //1
//                 /*  |  |  */     {T, F, F, T, T, F },    //2
//                 /*  2--3  */     {F, T, T, F, F, T },    //3
//                 /*  |  |  */     {F, F, T, F, F, F },    //4
//                 /*  4  5  */     {F, F, F, T, F, F }};   //5

// //                   // 0  1  2  3  4
// bool[,] dungeons2 = {{F, F, T, F, F},    //0
//               /*     0     */    {F, F, T, F, F},    //1
//               /*     |     */    {T, T, F, T, T},    //2 
//               /*  1--2--3  */    {F, F, T, F, F},    //3
//               /*     |     */    {F, F, T, F, F}};   //4
// /*     4     */

// Console.WriteLine(string.Join(" ", ProblemaAntorchas.AsignaAntorchas(dungeons1)));
// // [2, 3]

// Console.WriteLine(string.Join(" ", ProblemaAntorchas.AsignaAntorchas(dungeons2)));
// // [2]


// Test(
//             // Tareas
//             new int[] { 5, 8, 16 },
//             // Combustible
//             new double[2, 3]
//             {
//                 { 1.0, 0.5 , 2.0 },
//                 { 2.0, 1.0, 0.5},

//             },
//             // Resultado esperado
//             9
//         );




