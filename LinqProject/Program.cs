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
    new Product {ProductId = 2, CategoryId = 1, ProductName = "Hp Laptop", QuantityPerUnit = "16 GB Ram",
        UnitPrice = 8000, UnitsInStock = 4},
    new Product {ProductId = 3, CategoryId = 1, ProductName = "Asus Laptop", QuantityPerUnit = "8 GB Ram",
        UnitPrice = 8000, UnitsInStock = 3},
    new Product {ProductId = 4, CategoryId = 2, ProductName = "Samsung Telefon", QuantityPerUnit = "4 GB Ram",
        UnitPrice = 5000, UnitsInStock = 2},
    new Product {ProductId = 5, CategoryId = 2, ProductName = "Xiaomi Telefon", QuantityPerUnit = "4 GB Ram",
        UnitPrice = 8000, UnitsInStock = 1}
};

//Link(products);


//linq Olmasaydı ve bunu fonk haline getirseydik
//GetProduct(products); 

//any Listenin içinde bir eleman var mı yok mu onu söyler
//AnyTest(products);

//aradığımız kritere uygun nesnenin  kendisini verir
//mesal bir bankacılık uygulamsında 3 tane krediniz var o kredilerden birinin detay bilgisine 
//gitmek istiyorsunux ona tıklıyoruz yao arka planda tıkladığımız ürünün id sini allıyor ve o id ye
//uygun bilgileri getiriyor
//TestFind(products);//Cevap = HP Laptop

//şarta uyan tüm elemanları getirir
//TestFindAll(products);


//FindAll ile aynı şeyi döner forla dödürdüğünde tüm ürünleri listedeki sırayla döner
//OrderBy(p=>p.UnitPrice) diyerek fiyata göre sıraladık Artan 
//OrderByDescending(p=>p.UnitPrice) Düşen fiyata göre sıralamaktır
//iki ürünün fiyatı ayni ise alfaberik sıraya göre sıralama = ThenByDescending(p=>p.ProductName)
//AscDescTest(products);

//üsteki fonksiyonların başka bir alternatifi
//ClasıcLinqTest(products);



static List<Product> GetProduct(List<Product> products)
{
    List<Product> filtreleProducts = new List<Product>();
    foreach (Product product in products)
    {
        if (product.UnitPrice > 5000 && product.UnitsInStock > 3)
        {
            filtreleProducts.Add(product);
        }
    }
    return filtreleProducts;
}

//linqi Fonk haline getirmek
static List<Product> GetProductLinq(List<Product> products)
{
    return products.Where(p => p.UnitPrice > 5000 && p.UnitsInStock > 3).ToList();
}

static void Link(List<Product> products)
{
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
}

static void AnyTest(List<Product> products)
{
    var result = products.Any(p => p.ProductName == "Acer Laptop");
    Console.WriteLine(result);//varsa true yoksa false döner
}

static void TestFind(List<Product> products)
{
    var result = products.Find(p => p.ProductId == 3);
    Console.WriteLine(result.ProductName);
}

static void TestFindAll(List<Product> products)
{
    var result = products.FindAll(p => p.ProductName.Contains("top"));
    Console.WriteLine(result);
}

static void AscDescTest(List<Product> products)
{
    var result = products.Where(p => p.ProductName.Contains("top")).OrderByDescending(p => p.UnitPrice).ThenByDescending(p => p.ProductName);
    foreach (var product in result)
    {
        Console.WriteLine(product.ProductName);
    }
}

static void ClasıcLinqTest(List<Product> products)
{
    var result = from p in products
                 where p.UnitPrice > 6000 && p.UnitPrice < 9000
                 orderby p.UnitPrice/*defaultu ascending ama descengin yazarsak düşen seklinde sıralanır*/ , p.ProductName descending
                 select new ProductDto { ProductId = p.ProductId, ProductName = p.ProductName, UnitPrice = p.UnitPrice };

    foreach (var product in result)
    {
        Console.WriteLine(product.ProductName);
    }
}

//mesela ben feilds ların hepsini kllanmak istemiyorum  dediğimizde fazladan categoryNameyi eklesek
//ama üste categoryName gelmeyecek onun için join kullanıcaz
class ProductDto
{
    public int ProductId { get; set; }
    public string CategoryName { get; set; }
    public string ProductName { get; set; }
    public decimal UnitPrice { get; set; }
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