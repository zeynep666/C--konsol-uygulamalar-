namespace _hesapMakinesi
{
    class hesap
    {
        static void Main(string[] args)
        {
            while (true) // Sonsuz döngü
            {
                for (int i = 0; i < 1; i++)
                {
                    Console.Write("sayı 1 : ");
                    int sayi1 = Convert.ToInt32(Console.ReadLine());
                    Console.Write("sayı 2 : ");
                    int sayi2 = Convert.ToInt32(Console.ReadLine());
                    // \n işareti alt satıra geçmeyi sağlar o sebeple koydum
                    Console.WriteLine("1.toplama işlemi \n2.çıkarma işlemi \n3.çarpma işlemi \n4.bölme işlemi ");
                    Console.Write("Hangi işlemi yapmak istediğinizi seçiniz: ");
                    int islem = Convert.ToInt32(Console.ReadLine());

                    if (islem == 1)
                    {
                        Console.WriteLine("Cevap = " + (sayi1 + sayi2));
                    }
                    else if (islem == 2)
                    {
                        Console.WriteLine("Cevap = " + (sayi1 - sayi2));
                    }
                    else if (islem == 3)
                    {
                        Console.WriteLine("Cevap = " + (sayi1 * sayi2));
                    }
                    else if (islem == 4)
                    {
                        Console.WriteLine("Cevap = " + (sayi1 / sayi2));
                    }
                    else
                    {
                        Console.WriteLine("Hatalı seçim!");
                    }
                }

                Console.WriteLine("\nYeni işlem yapmak istiyor musunuz? (1: Evet, 2: Hayır): ");
                int devam = Convert.ToInt32(Console.ReadLine());

                if (devam != 1)
                {
                    break;
                }
            }
            Console.WriteLine("Programdan çıkılıyor...");
            Console.ReadLine();
        }
        
    }
}