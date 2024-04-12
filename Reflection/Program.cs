using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

//Reflection ile çalışma anındayani uygulama çalışırken ve çalıştığınız herhangi bir nesnenin hakkinda bilgi toplayabilir 
//ve hatta bu topladığınız bilgiye göre de bu nesneyi istediğimiz zamn örneğin bir metodunu çalıştırabiliriz çalışma anında


//bunları yaptık ama bunlar ıçalışmma anında yapmak istiyorum

//DortIslem dortIslem = new DortIslem(2, 3);
//Console.WriteLine(dortIslem.Topla2());
//Console.WriteLine(dortIslem.Topla(3, 4));
//

var type = typeof(DortIslem);//reflection ile benim çalışacağım bir tip var oda DortIslem

DortIslem dortIslem =  (DortIslem)Activator.CreateInstance(type,6,5); // bununla bu DortIslem dortIslem = new DortIslem(2, 3); aynı şey 

//Console.WriteLine(dortIslem.Topla(4, 5)); //parametresiz cunstroctur ile çalışır 20.satırdaki ise prmtrli olduğu içn içne yazdık
//Console.WriteLine(dortIslem.Topla2());

//metodunu kullanmak için de 
var instance = Activator.CreateInstance(type, 6, 7);
//instance.GetType().GetMethod("Topla2")/*diyerek metotda ulştm*/.Invoke(instance,null)/* invok dediğimde metdu çlşryrm*/;
//kısaca getmetot ile istenilen metoda ulaşıyoruz invoke ile ulaştığımız metodu çalıştırıyoruz
Console.WriteLine(instance.GetType().GetMethod("Topla2").Invoke(instance, null));
Console.WriteLine("-------------------------------------");
//liste olan metotlara ulaşabilriz
var metodlar = type.GetMethods();

foreach (var info in metodlar)
{
    Console.WriteLine("Metod Adı : {0}",info.Name );
    //Diyerek parametrelerine de ulaştık
    foreach (var parameterınfo in info.GetParameters())
    {
        Console.WriteLine("Parametre : {0}",parameterınfo.Name);
    }
    foreach (var atribute in info.GetCustomAttributes())
    {
        Console.WriteLine("Atribute  : {0}",atribute.GetType().Name);

    }
}
Console.ReadLine();

public class DortIslem
{
    private int _x; 
    private int _y;
    public DortIslem(int x, int y)
    {
        _x = x;
        _y = y;
    }
    public int Topla(int x, int y)
    {
        return x + y;
    }
    public DortIslem()
    {
        
    }
    public int Carp(int x, int y)
    {
        return x * y;
    }

    public int Topla2()
    {
        return _x + _y;
    }
    [MetodName("Carpma")]
    public int Carp2()
    {
        return _x * _y;
    }

}
public class MetodNameAttribute: Attribute
{
    public MetodNameAttribute(string name)
    {
        
    }
}
