using System;

class Program
{
    static void Main()
    {
        Console.Write("Bir sayı giriniz: ");
        int sayi = Convert.ToInt32(Console.ReadLine());
        int toplam = 0;

        for (int i = 0; i < sayi; i++)
        {
            toplam += i;
        }

        Console.WriteLine($"{sayi} sayısına kadar olan sayıların toplamı: {toplam}");
        Console.ReadLine();
    }
}
