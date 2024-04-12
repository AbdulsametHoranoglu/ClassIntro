using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
//Action  bir metoda karşılık gelir ve void olanları çalıştırmak üzere tasarlanmış bir mimaridir 
//Action  bir metoda karşılık gelir ve Dönüş tipi olanlar için olanları çalıştırmak üzere tasarlanmış bir mimaridir
namespace Delegates
{
    public class FuncAndAction
    {
       static void Main(string[] args)
        {
            Console.WriteLine(Topla(2,3));
        }
        static int Topla(int x, int y)
        {
            return x + y;
        }
    }

}
