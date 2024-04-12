//kısaca event = mesela elinde 100 telefon var ve 20 telefon kaldığında beni uyar bana mail at deki telefonların
//azaldı extra sipariş ver bu bir event yan, b,r uygulamada bir hareket olduğunda o harekete ek olarak yapmak
//istediğiniz bir işlem varsa  bunu event ile yapıyoruz
using Events;

Product hardDisk = new Product(50);
hardDisk.ProductName = "Hard Disk";

Product gsm = new Product(50);
gsm.ProductName = "GSM";
gsm.StockControlEvent += Gsm_StockControlEvent;

void Gsm_StockControlEvent()
{
    Console.WriteLine("Gsm About to Finish!");
}

for (int i = 0; i < 10; i++)
{
    hardDisk.sell(10);
    gsm.sell(10);
    Console.ReadLine();
}
Console.ReadLine();