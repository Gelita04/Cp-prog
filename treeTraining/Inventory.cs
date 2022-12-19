namespace treeTraining;

public interface IProduct
{
    string Name { get; set; }
    ICategory category { get; }
    int Count { get; }
}

public interface ICategory
{
    string Name { get; }
    ICategory Parent { get; }
    ICollection<ICategory> SubCategories { get; }
    ICollection<ICategory> Products { get; }

    ICategory CreateCategory(string Name);
    void UpdateProduct(string ProductName, int n);
}

public interface Inventory
{
    ICategory GetCategory(params string[] categories);
    IProduct GetProduct(string ProductName, params string[] categories);
    IEnumerable<IProduct> FindAll(Filter<IProduct> filter);
}

public delegate bool Filter<T>(T item);
