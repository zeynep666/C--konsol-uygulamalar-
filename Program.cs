using System;
using System.Collections.Generic;

namespace DepoProgrami
{
    class Urun
    {
        public int UrunId { get; set; }
        public string UrunAdi { get; set; }
        public int StokMiktari { get; set; }
        public int AlisFiyati { get; set; }
        public int SatisFiyati { get; set; }

        public Urun(int id, string ad, int miktar, int alisFiyati)
        {
            UrunId = id;
            UrunAdi = ad;
            StokMiktari = miktar;
            AlisFiyati = alisFiyati;
            SatisFiyati = HesaplaSatisFiyati(alisFiyati);
        }

        // Satış fiyatını hesaplama
        private int HesaplaSatisFiyati(int alisFiyati)
        {
            double kdv = alisFiyati * 0.10;
            double kar = alisFiyati * 0.30;
            return Convert.ToInt32(alisFiyati + kdv + kar);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Urun> urunListesi = new List<Urun>();
            int urunSayaci = 1;
            int programCalisiyor = 1; 

            // Başlangıç kasası
            int kasa = 10000; 
            int toplamAlis = 0;
            int toplamSatis = 0;

            while (programCalisiyor == 1)
            {
                Console.Clear(); 
                Console.WriteLine("Depo Yönetimi");
                Console.WriteLine("1. Ürün Ekle");
                Console.WriteLine("2. Ürün Listele");
                Console.WriteLine("3. Stok veya Fiyat Güncelle");
                Console.WriteLine("4. Ürün Satışı Yap");
                Console.WriteLine("5. Gün Sonu Raporu");
                Console.WriteLine("6. Çıkış");
                Console.Write("Seçiminizi yapınız: ");

                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1":
                        // Ürün ekleme
                        Console.Clear();
                        Console.Write("Ürün Adını Giriniz: ");
                        string urunAdi = Console.ReadLine();

                        try
                        {
                            Console.Write("Stok Miktarını Giriniz: ");
                            int stokMiktari = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Alış Fiyatını Giriniz: ");
                            int alisFiyati = Convert.ToInt32(Console.ReadLine());

                            urunListesi.Add(new Urun(urunSayaci++, urunAdi, stokMiktari, alisFiyati));
                            toplamAlis += stokMiktari * alisFiyati; 
                            kasa -= stokMiktari * alisFiyati;
                            Console.WriteLine("Ürün başarıyla eklendi.");
                        }
                        catch
                        {
                            Console.WriteLine("Hatalı giriş yaptınız! Lütfen sayısal bir değer giriniz.");
                        }
                        Console.WriteLine("Devam etmek için bir tuşa basın...");
                        Console.ReadKey();
                        break;

                    case "2":
                        // Ürün listeleme
                        Console.Clear();
                        Console.WriteLine("Depodaki Ürünler:");
                        if (urunListesi.Count > 0)
                        {
                            foreach (var urun in urunListesi)
                            {
                                Console.WriteLine($"ID: {urun.UrunId}, Adı: {urun.UrunAdi}, Stok: {urun.StokMiktari}, Alış Fiyatı: {urun.AlisFiyati} TL, Satış Fiyatı: {urun.SatisFiyati} TL");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Depoda ürün bulunmamaktadır.");
                        }
                        Console.WriteLine("Devam etmek için bir tuşa basın...");
                        Console.ReadKey();
                        break;

                    case "3":
                        // Stok veya fiyat güncelleme
                        Console.Clear();
                        try
                        {
                            Console.Write("Güncellemek istediğiniz ürün ID'sini giriniz: ");
                            int idGuncelle = Convert.ToInt32(Console.ReadLine());

                            Urun urunGuncelle = urunListesi.Find(u => u.UrunId == idGuncelle);
                            if (urunGuncelle != null)
                            {
                                Console.WriteLine("1. Stok Güncelle");
                                Console.WriteLine("2. Alış Fiyatını Güncelle");
                                Console.Write("Seçiminizi yapınız: ");
                                string guncelleSecim = Console.ReadLine();

                                if (guncelleSecim == "1")
                                {
                                    Console.Write("Yeni Stok Miktarını Giriniz: ");
                                    int yeniStok = Convert.ToInt32(Console.ReadLine());
                                    urunGuncelle.StokMiktari = yeniStok;
                                    Console.WriteLine("Stok başarıyla güncellendi.");
                                }
                                else if (guncelleSecim == "2")
                                {
                                    Console.Write("Yeni Alış Fiyatını Giriniz: ");
                                    int yeniAlisFiyati = Convert.ToInt32(Console.ReadLine());
                                    urunGuncelle.AlisFiyati = yeniAlisFiyati;
                                    urunGuncelle.SatisFiyati = urunGuncelle.SatisFiyati;
                                    Console.WriteLine("Alış fiyatı ve buna bağlı satış fiyatı başarıyla güncellendi.");
                                }
                                else
                                {
                                    Console.WriteLine("Geçersiz seçim yaptınız!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ürün bulunamadı!");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Hatalı giriş yaptınız! Lütfen sayısal bir değer giriniz.");
                        }
                        Console.WriteLine("Devam etmek için bir tuşa basın...");
                        Console.ReadKey();
                        break;

                    case "4":
                        // Ürün satışı yapma
                        Console.Clear();
                        try
                        {
                            Console.Write("Satış yapmak istediğiniz ürün ID'sini giriniz: ");
                            int idSatis = Convert.ToInt32(Console.ReadLine());

                            Urun urunSatis = urunListesi.Find(u => u.UrunId == idSatis);
                            if (urunSatis != null)
                            {
                                Console.Write("Satılacak miktarı giriniz: ");
                                int satisMiktari = Convert.ToInt32(Console.ReadLine());

                                if (satisMiktari <= urunSatis.StokMiktari)
                                {
                                    urunSatis.StokMiktari -= satisMiktari;
                                    int satisTutari = satisMiktari * urunSatis.SatisFiyati;
                                    toplamSatis += satisTutari; 
                                    kasa += satisTutari;
                                    Console.WriteLine($"Satış başarılı! Kasaya eklenen tutar: {satisTutari} TL");
                                }
                                else
                                {
                                    Console.WriteLine("Yetersiz stok!");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ürün bulunamadı!");
                            }
                        }
                        catch
                        {
                            Console.WriteLine("Hatalı giriş yaptınız! Lütfen sayısal bir değer giriniz.");
                        }
                        Console.WriteLine("Devam etmek için bir tuşa basın...");
                        Console.ReadKey();
                        break;

                    case "5":
                        // Gün sonu raporu
                        Console.Clear();
                        Console.WriteLine("Gün Sonu Raporu");
                        Console.WriteLine($"Toplam Alış: {toplamAlis} TL");
                        Console.WriteLine($"Toplam Satış: {toplamSatis} TL");
                        Console.WriteLine($"Güncel Kasa Miktarı: {kasa} TL");
                        Console.WriteLine("Devam etmek için bir tuşa basın...");
                        Console.ReadKey();
                        break;

                    case "6":
                        // Çıkış
                        Console.Clear();
                        programCalisiyor = 0; 
                        Console.WriteLine("Programdan çıkılıyor...");
                        break;

                    default:
                        Console.WriteLine("Geçersiz bir seçim yaptınız!");
                        Console.WriteLine("Devam etmek için bir tuşa basın...");
                        Console.ReadKey();
                        break;
                }
            }
        }
    }
}
