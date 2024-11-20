using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ucgenCevre
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("birinci kenarı giriniz");
            int kenar1 =Convert.ToInt32( Console.ReadLine());
            Console.WriteLine("ikinci kenarı giriniz");
            int kenar2=Convert.ToInt32( Console.ReadLine());
            Console.WriteLine("üçüncü kenarı giriniz");
            int kenar3=Convert.ToInt32( Console.ReadLine());
            int cevre=(kenar1+kenar2+kenar3);
            Console.WriteLine("Üçgen çevresi: "+cevre);
            Console.WriteLine("karenin bir kenar uzunluğunu giriniz");
            int kenar4=Convert.ToInt32( Console.ReadLine());
            int kareAlan = (kenar4 * kenar4);
            Console.WriteLine("karenin alanı: "+kareAlan);

        }
    }
}
