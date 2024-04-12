using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exceptions;
//action ve funk normalde biz bir metoda int, string, bool, char vb. göndeririz. bunlar sayesinde bir metoda metot
//(yani kod bloğu gönderebiliriz) yani metoda metot gönderme kiçin

//action void türünde yani oze l bir tipi döndürmeyen kod blokları(metotlar) için kullanırız sadece çalıştırır
//funk ise parametreli metotlar ve kod blokları için kullanırız  bunda ise çalıştır ve değeri dön

class Program
{
    static void Main(string[] args)
    {
        //TryCatch();

        //ActionDemo();

        Func<int, int, int> add = Topla; //birinci int parametre ikinci  int parametre 3. int ise çıktı
        Console.WriteLine(add(3,5));

        Func<int> getRandomNumber = delegate ()//tek int e sadece dönüş tipini döndürür
        {
            Random random = new Random();
            return random.Next(1, 100);
        };
        
        Func<int> getRandomNumber2=()=>new Random().Next(1, 100);
        Console.WriteLine(getRandomNumber());
        Thread.Sleep(1000);
        Console.WriteLine(getRandomNumber2());

        //Console.WriteLine(Topla(2,3));


    }
    static int Topla(int x, int y)
    {
        return x + y;
    }

    private static void ActionDemo()
    {
        HandleException(() =>
        {
            Find();
        });// buraya normalde int string vb şeyler gönderebiliyoruz peki ya metot gönderebilirmiyiz
           // (yani metoda metot göndermek) ? evet delegelerle gönderebiliriz 
           //() = ben parametresi kod bloğu gönderecem ( bir metot) => (lambda)= o kod bloğunun karşılığı da{} içindeki şeyler
    }

    private static void TryCatch()
    {
        try
        {
            Find();
        }
        catch (RecordNotFoundException exception)
        {
            Console.WriteLine(exception.Message);
        }
    }

    private static void HandleException(Action action) // burdaki action üsteki handleExceptionun içi demek
    {
        try
        {
            action.Invoke();//invoke çalıştır demek
        }
        catch (Exception exception)
        {
            Console.WriteLine(exception.Message);
        }
    }

    private static void Find()
    {
        //ExceptionIntro();
        List<string> students = new List<string> { "Samet", "Nida", "Nisa" };

        if (!students.Contains("Ahmet"))
        {
            throw new RecordNotFoundException ("Record Not Found");
        }
        else
        {
            Console.WriteLine("Record Faund");
        }
        Console.ReadLine();
    }

    private static void ExceptionIntro()
    {
        try
        {
            string[] students = new string[3] { "engin", "derin", "salih" };
            students[3] = "ahmet";//hatalı kod
        }
        catch (IndexOutOfRangeException exception) //eğer aldığın hata IndexOutOfRangeException sa bunu yaz
        {
            Console.WriteLine(exception.Message);
        }
        catch (Exception exception)//hata bilgisi exceptiona aktarılır
        {
            Console.WriteLine(exception.Message);// Message yerine InnerException yazarsak daha detaylı bilgi verir
        }
    }
}
