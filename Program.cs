using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace servis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> ogrenciliste = new List<string>();
            int ogrencisayi = 0;
            Console.WriteLine("Öğrenci eklemel istiyorsanız 1 istemiyorsanız 2ye basın.");
            while (true)
            {
                int karar = 0;
                karar= Convert.ToInt32(Console.ReadLine());
                if (karar == 1 )
                {
                    Console.WriteLine("Geziye katılacak öğrenci isimlerini giriniz.");
                    ogrenciliste.Add(Console.ReadLine());
                    ogrencisayi++;
                    Console.WriteLine("Devam etmek istiyor musunuz? Evet 1 Hayır 2 ");
                }
                else if (karar == 2 )
                {
                    Console.WriteLine("Ekleme işlemi bitti. Toplam eklenen kişi sayısı" + ogrencisayi);
                    break;
                }
                else 
                {
                    Console.WriteLine("Geçersiz değer. Tekrar deneyiniz.");
                }
            }
        }
    }
}
