using System.Linq;
List<Category> categories = new List<Category>
{
    new Category {CategoryId = 1, CategoryName = "Bilgisayar"}, 
    new Category {CategoryId = 2, CategoryName ="Telefon"}
};

List<Product> products = new List<Product>
{
    new Product {ProductId = 1, CategoryId = 1, ProductName = "Acer Laptop", QuantityPerUnit = "32 GB Ram", 
        UnitPrice = 10000, UnitsInStock = 5},
    new Product {ProductId = 2, CategoryId = 1, ProductName = "Asus Laptop", QuantityPerUnit = "16 GB Ram",
        UnitPrice = 8000, UnitsInStock = 4},
    new Product {ProductId = 3, CategoryId = 1, ProductName = "Hp Laptop", QuantityPerUnit = "8 GB Ram",
        UnitPrice = 6000, UnitsInStock = 3},
    new Product {ProductId = 4, CategoryId = 2, ProductName = "Samsung Telefon", QuantityPerUnit = "4 GB Ram",
        UnitPrice = 5000, UnitsInStock = 2},
    new Product {ProductId = 5, CategoryId = 2, ProductName = "Xiaomi Telefon", QuantityPerUnit = "4 GB Ram",
        UnitPrice = 8000, UnitsInStock = 1}
};

Console.WriteLine("----------Algoritmik----------");
foreach (Product product in products)
{
    if (product.UnitPrice > 5000 && product.UnitsInStock > 3)
    {
        Console.WriteLine(product.ProductName);
    }
}

Console.WriteLine("----------LİNQ----------");

var result = products.Where(p => p.UnitPrice > 5000 && p.UnitsInStock > 3);

foreach (Product product in result)
{
    Console.WriteLine(product.ProductName);
}


//linq Olmasaydı ve bunu fonk haline getirseydik
GetProduct(products);
static List<Product> GetProduct(List<Product> products)
{
    List<Product> filtreleProducts = new List<Product>();
    foreach (Product product in products)
    {
        if (product.UnitPrice > 5000 && product.UnitsInStock > 3)
        {
            filtreleProducts .Add(product);
        }
    }
    return filtreleProducts;
}

//linqi Fonk haline getirmek
static List<Product> GetProductLinq(List<Product> products)
{
    return products.Where(p => p.UnitPrice > 5000 && p.UnitsInStock > 3).ToList();
}





class Product
{
    public int ProductId { get; set; }
    public int CategoryId { get; set; }
    public string ProductName { get; set; }
    public string QuantityPerUnit { get; set; }
    public decimal UnitPrice { get; set; }
    public int UnitsInStock { get; set; }

}

class Category
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
}