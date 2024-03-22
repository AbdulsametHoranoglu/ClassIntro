using Oop2;

GercekMusteri musteri1 = new GercekMusteri();
musteri1.Id = 1;
musteri1.MusteriNo = "12345";
musteri1.Adi = "Samet";
musteri1.Soyadi = "Horan";
musteri1.TcNo = "2345678697654";


TuzelMusteri tuzel =  new TuzelMusteri();
tuzel.Id = 2;
tuzel.MusteriNo = "3242";
tuzel.SirketAdi = "Kodlama.io";
tuzel.VergiNo = "12345678";

//base sınıfımız (Musteri) hem gerçek hemde tüzel muşterinin referansını tutabiliyor
Musteri musteri3 = new GercekMusteri();
Musteri musteri4 = new TuzelMusteri();

MusteriManager musteriManager = new MusteriManager();
musteriManager.Ekle(musteri1);
musteriManager.Ekle(tuzel);
musteriManager.Ekle(musteri4);
musteriManager.Ekle(musteri3);

