namespace MatCom.Exam
{
    public class Inventory : IInventory
    {
        // Categoría raíz
        public ICategory Root { get; }

        public Inventory(ICategory root)
        {
            Root = root;
        }

        // Navegar por las categorías y productos
        public ICategory GetCategory(params string[] categories)
        {
            return GetCategory(categories, Root);
        }
        private ICategory GetCategory(string[] categories, ICategory actualCategory, int count = 0)
        {
            foreach (ICategory category in actualCategory.Subcategories)
            {
                if (category.Name == categories[count])
                {
                    if (category.Name == categories.Last())
                    { return category; }
                    return GetCategory(categories, category, count + 1);
                }
            }
            throw new ArgumentException();
        }

        public IProduct GetProduct(string name, params string[] categories)
        {
            foreach (IProduct product in GetCategory(categories).Products)
            {
                if (product.Name == name)
                    return product;
            }
            throw new ArgumentException();
        }

        // Buscar los productos que cumplen con una condición
        public IEnumerable<IProduct> FindAll(Filter<IProduct> filter)
        {
            return FindAll(filter, new List<IProduct>(), Root);
        }
        private IEnumerable<IProduct> FindAll(Filter<IProduct> filter, List<IProduct> result, ICategory category)
        {
            foreach (var subcategory in category.Subcategories)
            {
                GetProductsOfCategoryIntoList(filter, result, subcategory);
                result = (List<IProduct>)FindAll(filter, result, subcategory);
            }
            return (IEnumerable<IProduct>)result;
        }

        private void GetProductsOfCategoryIntoList(Filter<IProduct> filter, List<IProduct> result, ICategory category)
        {
            foreach (var product in category.Products)
            { if (filter.Invoke(product)) result.Add(product); }
        }

    }

    public class Category : ICategory
    {
        public string Name { get; }

        // Enumerar todas las subcategorías (en este nivel)
        public IEnumerable<ICategory> Subcategories { get; }

        // Enumerar todos los productos (en este nivel)
        public IEnumerable<IProduct> Products { get; }

        // Categoría padre
        public ICategory Parent { get; }

        public Category(string name, ICategory? parent)
        {
            Subcategories = new List<ICategory>();
            Products = new List<IProduct>();
            Parent = parent == null ? this : parent;
            Name = name;
        }

        // Crear subcategorías
        public ICategory CreateSubcategory(string name)
        {
            Category newCategory = new Category(name, this);
            ((List<ICategory>)Subcategories).Add(newCategory);
            return newCategory;
        }

        // Crear o actualizar productos
        public void UpdateProduct(string product, int count)
        {
            if (Products.Count() == 0)
            {
                ((List<IProduct>)Products).Add(new Product(product, count, this));
                return;
            }
            bool founded = false;
            foreach (var item in Products)
            {
                if (item.Name == product)
                {
                    founded = true;
                    ((Product)item).Count += count;
                    if (((Product)item).Count < 0)
                        throw new ArgumentException();
                }
            }
            if (!founded) ((List<IProduct>)Products).Add(new Product(product, count, this));
        }
    }
    // List<IProduct> productsCasted = (List<IProduct>)Products;
    // for (int i = 0; i.CompareTo(Products.Count()) < 0; i++)
    // {
    //     if (productsCasted[i].Name != product)
    //     {
    //         ((List<IProduct>)Products).Add(new Product(product, count, this));
    //     }
    //     else
    //     {
    //         ((Product)productsCasted[i]).Count += count;
    //         if (((Product)productsCasted[i]).Count < 0)
    //             throw new ArgumentException();
    //     }
    // }
    public class Product : IProduct
    {
        public string Name { get; set; }
        public int Count { get; set; }
        public ICategory Parent { get; set; }

        public Product(string name, int count, ICategory parent)
        {
            Name = name;
            Count = count;
            Parent = parent;
        }
    }

}