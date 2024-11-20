using System;

class Program
{
    static void Main()
    {
        Console.Write("Bir sayı giriniz: ");
        int sayi = Convert.ToInt32(Console.ReadLine());

        int toplam = 0;
        //sayının mükemmel sayı olup olmadığını bulmak için sayının tam bölenlerini buluyoruz.
        for (int i = 1; i < sayi; i++)
        {
            if (sayi % i == 0)
            {
                toplam += i;
            }
        }

        // mükemmel sayı olup olmadığını kontrol ediyoruz.
        if (toplam == sayi)
        {
            Console.WriteLine($"{sayi} bir mükemmel sayıdır.");
        }
        else
        {
            Console.WriteLine($"{sayi} bir mükemmel sayı değildir.");
        }

        Console.ReadLine();
    }
}
