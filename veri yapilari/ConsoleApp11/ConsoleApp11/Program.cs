using System;

namespace ConsoleApp11
{
    class Program
    {
        static void Main(string[] args)
        {
            // Kullanıcıdan hash tablosunun boyutunu alıyoruz.

            int size;
            Console.WriteLine("Hash table boyu : ");
            size = int.Parse(Console.ReadLine());

            Tablo hTable = new Tablo(size); // Table yerine Tablo olarak güncellendi

            int numara;
            string isim;
            int secim = menu();

            while (secim != 0)
            {
                switch (secim)
                {
                    case 1:
                        Console.WriteLine("Numara : ");
                        numara = int.Parse(Console.ReadLine());
                        Console.WriteLine("İsim : ");
                        isim = Console.ReadLine();
                        hTable.ekle(numara, isim);
                        break;
                    case 2:
                        Console.WriteLine("Silinecek Kişi Numarası : ");
                        numara = int.Parse(Console.ReadLine());
                        hTable.sil(numara);
                        break;
                    case 3:
                        hTable.yazdir();
                        break;
                    case 0:
                        break;
                    case 4:
                        hTable.adetBul();
                        break;
                    case 5:
                        Console.WriteLine("Aranan kişinin numarası : ");
                        numara = int.Parse(Console.ReadLine());
                        hTable.kisiBul(numara);
                        break;
                    default:
                        Console.WriteLine("Hatalı seçim!");
                        break;
                }

                secim = menu();
            }

            Console.ReadKey();
        }

        private static int menu()
        {
            int secim;
            Console.WriteLine("1- Ekle");
            Console.WriteLine("2- Sil");
            Console.WriteLine("3- Yazdır");
            Console.WriteLine("4- Kişi sayısı");
            Console.WriteLine("5- Kişi bul");
            Console.WriteLine("0- Çıkış");
            Console.WriteLine("Seçiminiz : ");
            secim = int.Parse(Console.ReadLine());

            Console.Clear();
            return secim;
        }
    }
}
