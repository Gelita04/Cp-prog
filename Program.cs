using Equisde;

BinaryTree<int> arbol =
new BinaryTree<int>(1,
    new BinaryTree<int>(2,
        new BinaryTree<int>(5),
        new BinaryTree<int>(4)),
    new BinaryTree<int>(8,
        new BinaryTree<int>(7),
        new BinaryTree<int>(10, null
            ,
            new BinaryTree<int>(11))));

//System.Console.WriteLine(arbol.Inversions());
