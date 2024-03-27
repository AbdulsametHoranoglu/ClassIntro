
using System.Transactions;

MainClass mainClass = new MainClass();

mainClass.MainStart();

Baslat baslat = new Baslat();
baslat.Oku();

public class MainClass
{
    Dictionary<int, string> DicList = new Dictionary<int, string>();   //key yi integer , içeriğide string olacak şekilde tanımlıyorum

    public void MainStart()//dictionry listeme eleman ekleme
    {
        //NOT: key numaraları aynı olamaz burdayken hata vermez ama derlenirken hata verir
        DicList.Add(1, "Samet");//içerisinde arama yaprken 1 diye bir key numarası veriyorum ve sameti bana getiriyor
        DicList.Add(2, "Nisa");
        DicList.Add(3, "Hilal");
        DicList.Add(4, "Erdem");


        //listede bu key numarasınsa sahip bir eleman var mı ona bakarız
        if (DicList.ContainsKey(66))
        {
            Console.WriteLine("Eleman var " + DicList[1]);
        }
        else
        {
            Console.WriteLine("Eleman yok");
        }


        //Console.WriteLine(DicList[2]);//key numarası 2 olanı consoloda yazdır 
        Console.WriteLine(ListedeAra(3));
        Console.WriteLine(ListedeAra(5));


    }



    //varsa çıktısını al ve yaz diye bir işlem yaptıracaz
    public string ListedeAra(int aranacak)
    {
        string donenDeger;
        if (DicList.TryGetValue(aranacak, out donenDeger))//TryGetValue komutu = bulursan bulduğunu geri at komutu(Bulduğu anda çıkar)
        {
            return donenDeger;
        }
        else
        {
            return "Listede bu Key Numarası yok";
        }

    }

}
    //key numarası ve değer yeri class falan da olabilir

    class Insans
    {
        public string Isim;
    }

     class Baslat
     {
        Dictionary<int, Insans> Dic = new Dictionary<int, Insans>();
        public void Oku()
        {
            Dic.Add(1, new Insans() { Isim = "Samet" });
            Dic.Add(2, new Insans() { Isim = "Nilay" });
            Dic.Add(3, new Insans() { Isim = "Ahmet" });
            Dic.Add(4, new Insans() { Isim = "Muham" });

            Console.WriteLine(Dic[2]);
        }
     }




