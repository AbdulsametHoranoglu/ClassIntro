using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//delegate = elçi demek
namespace Delegates
{
    public delegate void MyDelegate();//bu elçinin görevi şu herhangi bir dönüş değeri olmayan (yani void metotlar) ve
    //parametre almayan operasyonlara delegelik(Elçilik) yapıyor
    public delegate void MyDelegate2(string text); //parametere alan delegeler 
    public delegate int MyDelegate3(int number1, int number2);
    public class Program
    {
        static void Main(string[] args)
        {
            CustomerManager customerManager = new CustomerManager();
            //customerManager.SendMessage();
            //customerManager.ShowAlert(); //fakat bunlar ıdelege ile kullanmak istersek
            
            //delege
            MyDelegate myDelegate = customerManager.SendMessage;//bu şu anlama geliyor bu elçi  myDelegate
                                                                //customerManager ın SendMessagena delege edilmiş durumda 
            myDelegate += customerManager.ShowAlert;
            myDelegate -= customerManager.SendMessage;//dersek bu işlemi geri al demek oluyor
            myDelegate();// dersek ekrana yazdırır
            MyDelegate2 myDelegate2 = customerManager.SendMessage2;
            myDelegate2 += customerManager.ShowAlert2;

            Matematik matematik = new Matematik();

            MyDelegate3 myDelegate3 = matematik.Topla;
            myDelegate3 += matematik.Carp;
            var sonuc= myDelegate3(3,4);
            Console.WriteLine(sonuc);
            myDelegate2("Merhaba");

            Console.ReadLine();


        }
    }
    public class CustomerManager
    {
        public void SendMessage()
        {
            Console.WriteLine("Holla!");

        }

        public void ShowAlert()
        {
            Console.WriteLine("Be Careful!");

        }

        public void SendMessage2(string message)
        {
            Console.WriteLine(message);

        }

        public void ShowAlert2(string alert)
        {
            Console.WriteLine(alert);

        }
    }

    public class Matematik
    {
        public int Topla(int sayi1,  int sayi2)
        {
            return sayi1 + sayi2;
        }

        public int Carp(int sayi1, int sayi2)
        {
            return sayi1 * sayi2;
        }
    }
}
//Action  bir metoda karşılık gelir ve void olanları çalıştırmak üzere tasarlanmış bir mimaridir 
//Action  bir metoda karşılık gelir ve Dönüş tipi olanlar için olanları çalıştırmak üzere tasarlanmış bir mimaridir 