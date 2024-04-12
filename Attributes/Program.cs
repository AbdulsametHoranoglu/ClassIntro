using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Attributes;

 class Program
{
    Customer customer = new Customer {Id = 1, LastName = "Horan", Age = 24 };
    CustomerDal customerDal = new CustomerDal();
    //customerDal.Add(customer);
}

[ToTable("TblCustomers")]
[ToTable("Customers")]//burda da bir classa attribute ekledik kısacası attributelarla çalışma anında nesnelerinize ve bu nesnelerin 
//özelliklerini veya metotlarına anlam katmakiçin bunlardan yararlanılır
class Customer
{
    public int Id { get; set; }
    [RequiredProperty]//bu nesneneleri kullanılan ortamda FirstNameyi KUllanmak zorunlu olsun
    public string FirstName { get; set; }
    [RequiredProperty]//Soy isim girilmesi sorunlu
    public string LastName { get; set; }
    [RequiredProperty]// yaş girilmesi zorunlu
    public int Age { get; set; }
}

class CustomerDal 
{
    [Obsolete("Don't use Add, İnstead use AddNew Method")] //hazır bir attribute = attribute yi kullanan kişi ye diyorsununz ki bak arkadaş ben yanisini yazdım bunu kullanma
    public void Add(Customer customer)
    {
        Console.WriteLine("{0},{1},{2},{3} added!",customer.Id,customer.FirstName,customer.LastName,customer.LastName);
    }
    public void AddNew(Customer customer)
    {
        Console.WriteLine("{0},{1},{2},{3} added!", customer.Id, customer.FirstName, customer.LastName, customer.LastName);
    }

}

[AttributeUsage(AttributeTargets.Property)]//dieyek bu attributeyi sadece Propertyler kullansın kullanabilirsin 
//Property yerine Class deseydim Artık sadece classların üstüne konulurdu
//Property yerine All deseydim Herkez kullanabilirdi
// | AttributeTargets.Field diyerek başka kısıtlamalar  getirebiliriz
// 
class RequiredPropertyAttribute : Attribute
{

}

[AttributeUsage(AttributeTargets.Class, AllowMultiple = true)] //mantıken bunları sadece class içinde kullanabiliriz
// AllowMultiple = true dersek iki tane üst üste kullanabilirmiyim demek oluyor evet dedik

class ToTableAttribute : Attribute
{
    private string _tableName;

    public ToTableAttribute(string tableName)
    {
        this._tableName = tableName;
    }
} 



