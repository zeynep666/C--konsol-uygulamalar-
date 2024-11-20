using System;

namespace siniflar
{
    class Ogrenci
    {
        public string[] Dersler { get; set; }
        public int DersSayisi { get; set; }
    }

    class Ogretmen
    {
        public string[] VerdigiDersler { get; set; }
        public int DersSayisi { get; set; }
    }

    class Program
    {
        static void Ogrenciprogrami(Ogrenci ogr)
        {
            Console.WriteLine($"\nÖğrencinin ders programı ({ogr.DersSayisi} ders):");
            foreach (var ders in ogr.Dersler)
            {
                Console.WriteLine($"- {ders}");
            }
        }

        static void Ogretmenprogrami(Ogretmen ogrt)
        {
            Console.WriteLine($"\nÖğretmenin dersleri ({ogrt.DersSayisi} ders):");
            foreach (var ders in ogrt.VerdigiDersler)
            {
                Console.WriteLine($"- {ders}");
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hoş geldiniz! Lütfen bir seçim yapınız:");
            Console.WriteLine("1. Öğretmen");
            Console.WriteLine("2. Öğrenci");
            Console.Write("Seçiminiz: ");
            int secim = Convert.ToInt32(Console.ReadLine());
            Ogrenci ogrenci = new Ogrenci { Dersler = new string[] { "Algoritma", "Yazılım" }, DersSayisi = 2 };
            Ogretmen ogretmen = new Ogretmen { VerdigiDersler = new string[] { "Algoritma", "Yazılım" }, DersSayisi = 2 };
            if (secim == 1)
            {
                Ogretmenprogrami(ogretmen);
            }
            else if (secim == 2)
            {
                Ogrenciprogrami(ogrenci);
            }
            else
            {
                Console.WriteLine("Geçersiz seçim!");
            }
            Console.ReadKey();
        }
    }
}
