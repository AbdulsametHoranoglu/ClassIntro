using GenericsIntro;

MyList<string> İsimler = new MyList<string>();
İsimler.Add("samet");
Console.WriteLine(İsimler.Length);

İsimler.Add("Kerem");
Console.WriteLine(İsimler.Length);

foreach (var isim in İsimler.Items)
{
    Console.WriteLine(isim);
}