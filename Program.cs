using System;

class Program
{
    static void Main()
    {
        // Kullanıcıdan üç değer alıyoruz
        Console.Write("A değerini giriniz: ");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.Write("B değerini giriniz: ");
        int b = Convert.ToInt32(Console.ReadLine());

        Console.Write("C değerini giriniz: ");
        int c = Convert.ToInt32(Console.ReadLine());

        // Aldığımız değerleri topluyoruz
        int toplam = a + b + c;

        // Değerler toplamının 180 olup olmadığını kontrol ediyoruz
        //180e eşit ise üçgendir değil ise üçgen değildir yazdırıyoruz
        if (toplam < 180)
        {
            Console.WriteLine("Bu bir üçgen değildir");
        }
        else if (toplam > 180)
        {
            Console.WriteLine("Bu bir üçgen değildir");
        }
        else
        {
            Console.WriteLine("Bu bir üçgendir");
        }
        Console.ReadKey();
    }
}
