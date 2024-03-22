using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP3;

internal class BasvuruManager
{
    //dependency injection 
    public void BasvuruYap(IKrediManager krediManager, List<ILoglamaManager> loglamaManager )//Ikradimanager bütün kredileri tuttuğu için istediğimiz birini seçebiliriz
    {
        //başvuran bilgilerini değerlendirme

        // KonutKrediManager krediManager = new KonutKrediManager();
        //krediManager.Hesapla();

        //üsteki konut kredisi yazarsak sadece konut kredisini hesaplarız yani tüm başvuruları konuta bağımlı yaptık 

        krediManager.Hesapla();
       // loglamaManager.log(); --> tek bir tane gönderme 
        foreach (var log in loglamaManager)//--> çoklu gönderme
        {
            log.Log();
        }

    }

    //birden fazla kredinin hesabını yapmak istiyorum deyince bir list göderiyoruz
    public void KrediOnBilgilendirmesiYap(List<IKrediManager> krediler)
    {
        foreach (var kredi in krediler)
        {
            kredi.Hesapla();
        }

    }

}
