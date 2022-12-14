using Equisde;

BinaryTree<int> arbol = new BinaryTree<int>(3, new List<BinaryTree<int>>
{
    new BinaryTree<int>(9,new List<BinaryTree<int>>
    {
        new BinaryTree<int>(4,new List<BinaryTree<int>>
        {
            new BinaryTree<int>(1),
            new BinaryTree<int>(0)
        }),
        new BinaryTree<int>(2,new List<BinaryTree<int>>
        {
            new BinaryTree<int>(7),
            new BinaryTree<int>(12)
        })
    }),
    new BinaryTree<int>(5,new List<BinaryTree<int>>
    {
        new BinaryTree<int>(6, new List<BinaryTree<int>>
        {
            new BinaryTree<int>(11),
            new BinaryTree<int>(10)
        }),
        new BinaryTree<int>(20,new List<BinaryTree<int>>
        {
            new BinaryTree<int>(15),
            new BinaryTree<int>(14)
        })
    }),
}
);
System.Console.WriteLine(arbol.DistanceFromANodeToBNode(7, 14));
