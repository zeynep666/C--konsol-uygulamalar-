using System;

class Ortalama
{
    static void Main()
    {
        Console.WriteLine("1. ders notunuzu giriniz:");
        int not1 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("2. ders notunuzu giriniz:");
        int not2 = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("3. ders notunuzu giriniz:");
        int not3 = Convert.ToInt32(Console.ReadLine());

        double ortalama = (not1 + not2 + not3) / 3.0;
        Console.WriteLine();
        Console.WriteLine("Ortalamanız: "+ ortalama);
        if (ortalama > 50)
        {
            Console.WriteLine("Dersi geçtiniz.");

        }
        if (ortalama < 50)
        {
            Console.WriteLine("Dersi geçemediniz.");
        }
    }
}
    

