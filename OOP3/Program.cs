using OOP3;
using System.Collections.Generic;

//IhtiyacKrediManager ıhtiyacKrediManager = new IhtiyacKrediManager();
//ıhtiyacKrediManager.Hesapla();

//TasitKrediManager tasitKrediManager = new TasitKrediManager();
//tasitKrediManager.Hesapla();

//KonutKrediManager konutKrediManager = new KonutKrediManager();
//konutKrediManager.Hesapla();


// onların yerine IKrediManager deseydik de olur du
//interfaceler de interfaceyi implement eden clasın referans numarasını tutabiliyor
IKrediManager ihtiyacKrediManager = new IhtiyacKrediManager();
IKrediManager tasitKrediManager = new TasitKrediManager();
IKrediManager konutKrediManager = new KonutKrediManager();

ILoglamaManager veriTabanıLoglama = new VeriTabanıLoglama();
ILoglamaManager emailLoglama = new EmailLoglama();


BasvuruManager basvuruManager = new BasvuruManager();
//basvuruManager.BasvuruYap(konutKrediManager);
//basvuruManager.BasvuruYap(tasitKrediManager, veriTabanıLoglama); //--> tek log mesajı
basvuruManager.BasvuruYap(konutKrediManager , new List<ILoglamaManager> {emailLoglama,veriTabanıLoglama });//->çoklu log mesajı

List<IKrediManager> krediler = new List<IKrediManager>() {ihtiyacKrediManager,tasitKrediManager};

//basvuruManager.KrediOnBilgilendirmesiYap(krediler);