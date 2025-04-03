using System;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            Liste ogrenciler = new Liste();  // Öğrenci bilgilerini tutacak bağlı liste.
            int numara;
            String ad, soyad, dersAdi;
            float vize, final;

            int secim = menu(); // Kullanıcıdan seçim al.
            while (secim != 0)
            {
                switch (secim)
                {
                    case 1:
                        // Yeni öğrenci ekleme.
                        Console.Write("Numara   : "); numara = int.Parse(Console.ReadLine());
                        Console.Write("İsim     : "); ad = Console.ReadLine();
                        Console.Write("Soyisim  : "); soyad = Console.ReadLine();
                        Console.Write("Ders Adı : "); dersAdi = Console.ReadLine();
                        Console.Write("Vize     : "); vize = float.Parse(Console.ReadLine());
                        Console.Write("Final    : "); final = float.Parse(Console.ReadLine());
                        ogrenciler.ekle(numara, ad, soyad, dersAdi, vize, final);
                        break;

                    case 2:
                        // Öğrenci silme işlemi.
                        Console.Write("Numara   : "); numara = int.Parse(Console.ReadLine());
                        ogrenciler.sil(numara);
                        break;

                    case 3:
                        // Öğrencileri listeleme.
                        Console.Clear();
                        ogrenciler.yazdir();
                        break;

                    case 4:
                        // En başarılı öğrenciyi bulma.
                        Console.Clear();
                        ogrenciler.enBasariliOgrenci();
                        break;

                    default:
                        Console.WriteLine("Hatalı seçim yaptınız!");
                        break;
                }
                secim = menu(); // Tekrar seçim al.
            }

            Console.WriteLine("Program kapatılıyor...");
        }

        private static int menu()
        {
            // Menü seçeneklerini ekrana yazdır.
            Console.WriteLine("\n1- Öğrenci ekle ");
            Console.WriteLine("2- Öğrenci sil ");
            Console.WriteLine("3- Öğrencileri yazdır ");
            Console.WriteLine("4- En başarılı öğrenciyi göster ");
            Console.WriteLine("0- Programı kapat ");
            Console.Write("Seçiminiz :  ");
            return int.Parse(Console.ReadLine());
        }
    }

    class Ogrenci   // Bağlı liste düğüm yapısı (Node).
    {
        public int numara;
        public string ad, soyad, dersAdi;
        public float vize, final, ortalama;
        public string durum;
        public Ogrenci next; // Sonraki düğümü gösterir.

        public Ogrenci(int n, string a, string s, string d, float v, float f)
        {
            this.numara = n;
            this.ad = a;
            this.soyad = s;
            this.dersAdi = d;
            this.vize = v;
            this.final = f;
            this.ortalama = this.vize * 40 / 100 + this.final * 60 / 100; // Ortalama hesaplanır.
            this.durum = this.ortalama < 50 ? "Kaldı" : "Geçti"; // Başarı durumu belirlenir.
            this.next = null;
        }
    }

    class Liste // Bağlı liste sınıfı.
    {
        Ogrenci head; // Listenin başlangıç düğümü.

        public Liste()
        {
            head = null;
        }

        public void ekle(int n, string a, string s, string d, float v, float f)
        {
            Ogrenci ogr = new Ogrenci(n, a, s, d, v, f);

            if (head == null)
            {
                head = ogr; // İlk öğrenci ekleniyor.
            }
            else
            {
                ogr.next = head;
                head = ogr; // Yeni öğrenci başa ekleniyor.
            }
            Console.WriteLine(n + " numaralı öğrenci eklendi.");
        }

        public void sil(int numara)
        {
            Ogrenci temp = head, prev = null;

            if (temp != null && temp.numara == numara)
            {
                head = temp.next; // İlk elemanı silme işlemi.
                Console.WriteLine(numara + " numaralı öğrenci silindi.");
                return;
            }

            while (temp != null && temp.numara != numara)
            {
                prev = temp;
                temp = temp.next;
            }

            if (temp == null)
            {
                Console.WriteLine("Öğrenci bulunamadı.");
                return;
            }

            prev.next = temp.next; // Öğrenci listeden çıkarılıyor.
            Console.WriteLine(numara + " numaralı öğrenci silindi.");
        }

        public void yazdir()
        {
            Ogrenci temp = head;

            if (temp == null)
            {
                Console.WriteLine("Liste boş.");
                return;
            }

            while (temp != null)
            {
                Console.WriteLine($"Numara: {temp.numara}, İsim: {temp.ad} {temp.soyad}, Ders: {temp.dersAdi}, Ortalama: {temp.ortalama}, Durum: {temp.durum}");
                temp = temp.next;
            }
        }

        public void enBasariliOgrenci()
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş.");
                return;
            }

            Ogrenci enBasarili = head;
            Ogrenci temp = head.next;

            while (temp != null)
            {
                if (temp.ortalama > enBasarili.ortalama)
                {
                    enBasarili = temp; // En yüksek ortalamayı bul.
                }
                temp = temp.next;
            }

            Console.WriteLine($"En başarılı öğrenci: {enBasarili.ad} {enBasarili.soyad}, Ortalama: {enBasarili.ortalama}");
        }
    }
}
