using System;

class Program
{
    static void Main(string[] args)
    {
        
        string adSoyad = OgrenciBilgi();
        int ortalama = Hesapla();

       
        Console.WriteLine(adSoyad+" adlı öğrencinin not ortalaması: "+ ortalama);
    }

    static string OgrenciBilgi()
    {
        Console.Write("Öğrenci adı ve soyadı: ");
        return Console.ReadLine(); 
    }

    static int Hesapla()
    {
        Console.Write("1. Sınav notunu girin (tam sayı): ");
        int not1 = Convert.ToInt32(Console.ReadLine());

        Console.Write("2. Sınav notunu girin (tam sayı): ");
        int not2 = Convert.ToInt32(Console.ReadLine());
        int ortalama = (not1 + not2) / 2; 
        return ortalama; 
    }
        Console.WriteLine();
}