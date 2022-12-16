using Equisde;

BinaryTree<int> arbol = new BinaryTree<int>(5, new List<BinaryTree<int>>
{
    new BinaryTree<int>(2,new List<BinaryTree<int>>
    {
        new BinaryTree<int>(1),
        new BinaryTree<int>(4)
    }),
    new BinaryTree<int>(8,new List<BinaryTree<int>>
    {
        new BinaryTree<int>(7),
        new BinaryTree<int>(10,new List<BinaryTree<int>>
        {
            new BinaryTree<int>(11),
            new BinaryTree<int>(12)
        })
    }),
}
);
System.Console.WriteLine(arbol.DistanceFromANodeToBNode(7, 14));
