using System.Collections.Generic;

List<string> sehirler = new List<string>();
sehirler.Add("Ankara"); 
sehirler.Add("Ankara");
sehirler.Add("Ankara");
sehirler.Add("Ankara");
Console.WriteLine(sehirler.Count);

//sehirler.Count = 0; denilmez çünkü sadece get(ReadOnly) i yazılmıştır 


MyList<string> sehirler2 = new MyList<string>();
sehirler2.Add("Ankara");
sehirler2.Add("Ankara");
sehirler2.Add("Ankara");
sehirler2.Add("Ankara");
sehirler2.Add("Ankara");
sehirler2.Add("Ankara");
Console.WriteLine(sehirler2.Count);

class MyList<T>//generic Class
{
    T[] _array;
    T[] _tempArray; 
    
    public MyList()//constructor oluşturduk : peki neden : çünkü cunstructor newlwndiğinde ilk çalışan metottur ve bu metodun eleman sayısını  0 dan başlattık
    {
        _array = new T[0];
    }
    public void Add(T item)//ekleme işlemi
    {
        _tempArray= _array; //_tempArray önceki değerler kaybolmasın diye arrayın referanslarnı tutar
        _array = new T[_array.Length + 1];

        for (int i = 0; i < _tempArray.Length; i++)//ve  _tempArray tuttuğu değerleri _arraya aktarıcaz
        {
            _array[i] = _tempArray[i];
        }
    }

    public int Count//eleman sayınısı hesapladık
    {
        get { return _array.Length; }
    }

}