using System;

class Program
{
    static void Main()
    {
        Console.Write("Bir sayı giriniz: ");
        int sayi = Convert.ToInt32(Console.ReadLine());

        int Sayi = sayi;
        int basamakSayisi = sayi.ToString().Length; 
        int toplam = 0;

        while (sayi > 0)
        {
            int basamak = sayi % 10; 
            toplam += (int)Math.Pow(basamak, basamakSayisi); 
            sayi /= 10; 
        }

        if (toplam == Sayi)
        {
            Console.WriteLine($"{Sayi} sayısı bir armstrong sayıdır.");
        }
        else
        {
            Console.WriteLine($"{Sayi} sayısı bir armstrong sayı değildir.");
        }

        Console.ReadLine();
    }
}
