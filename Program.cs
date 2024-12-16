using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static List<Kullanici> kullanicilar = new List<Kullanici>(); // Tüm kullanıcıları tutan liste
    static Kullanici aktifKullanici = null; // Şu an giriş yapmış kullanıcı

    static void Main(string[] args)
    {
        while (true)
        {
            Console.Clear();
            if (aktifKullanici == null)
            {
                Console.WriteLine("1. Kayıt Ol");
                Console.WriteLine("2. Giriş Yap");
                Console.WriteLine("3. Çıkış");
                Console.Write("Seçiminiz: ");
                string secim = Console.ReadLine();

                if (secim == "1")
                {
                    KayitOl();
                }
                else if (secim == "2")
                {
                    GirisYap();
                }
                else if (secim == "3")
                {
                    Console.WriteLine("Sistemden çıkılıyor...");
                    break;
                }
                else
                {
                    Console.WriteLine("Geçersiz seçim. Tekrar deneyin.");
                    Console.ReadLine();
                }
            }
            else
            {
                AnaMenu();
            }
        }
    }

    static void KayitOl()
    {
        Console.Clear();
        Console.WriteLine("Kayıt Ol");

        // Kullanıcı adı doğrulama
        string kullaniciAdi;
        while (true)
        {
            Console.Write("Kullanıcı Adı: ");
            kullaniciAdi = Console.ReadLine();
            if (!string.IsNullOrEmpty(kullaniciAdi) && kullaniciAdi.All(char.IsLetter))
            {
                break;
            }
            Console.WriteLine("Hatalı giriş! Kullanıcı adı sadece harflerden oluşmalıdır.");
        }

        // Şifre doğrulama
        string sifre;
        while (true)
        {
            Console.Write("Şifre (sadece rakamlar): ");
            sifre = Console.ReadLine();
            if (!string.IsNullOrEmpty(sifre) && sifre.All(char.IsDigit))
            {
                break;
            }
            Console.WriteLine("Hatalı giriş! Şifre sadece rakamlardan oluşmalıdır.");
        }

        // Müşteri temsilcisi doğrulama
        string musteriTemsilcisi;
        while (true)
        {
            Console.Write("Müşteri Temsilcisi: ");
            musteriTemsilcisi = Console.ReadLine();
            if (!string.IsNullOrEmpty(musteriTemsilcisi) && musteriTemsilcisi.All(char.IsLetter))
            {
                break;
            }
            Console.WriteLine("Hatalı giriş! Müşteri temsilcisi adı sadece harflerden oluşmalıdır.");
        }

        Kullanici yeniKullanici = new Kullanici
        {
            KullaniciAdi = kullaniciAdi,
            Sifre = sifre,
            KullaniciHesabi = new Hesap
            {
                HesapSahibi = kullaniciAdi,
                Bakiye = 0.0, // Yeni kullanıcı için bakiye sıfır
                MusteriTemsilcisi = musteriTemsilcisi
            }
        };

        kullanicilar.Add(yeniKullanici);
        Console.WriteLine("Kayıt başarılı! Giriş yapabilirsiniz.");
        Console.ReadLine();
    }

    static void GirisYap()
    {
        Console.Clear();
        Console.WriteLine("Giriş Yap");
        Console.Write("Kullanıcı Adı: ");
        string girisKullaniciAdi = Console.ReadLine();
        Console.Write("Şifre: ");
        string girisSifre = Console.ReadLine();

        foreach (var kullanici in kullanicilar)
        {
            if (kullanici.KullaniciAdi == girisKullaniciAdi && kullanici.Sifre == girisSifre)
            {
                aktifKullanici = kullanici;
                Console.WriteLine("Giriş başarılı!");
                Console.ReadLine();
                return;
            }
        }

        Console.WriteLine("Hatalı kullanıcı adı veya şifre. Tekrar deneyin.");
        Console.ReadLine();
    }

    static void AnaMenu()
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Hoş geldiniz, {aktifKullanici.KullaniciAdi}");
            Console.WriteLine($"Müşteri Temsilcisi: {aktifKullanici.KullaniciHesabi.MusteriTemsilcisi}");
            Console.WriteLine("1. Bakiye Görüntüle");
            Console.WriteLine("2. Para Yatır");
            Console.WriteLine("3. Para Çek");
            Console.WriteLine("4. Hesap Geçmişi Görüntüle");
            Console.WriteLine("5. Havale/EFT Yap");
            Console.WriteLine("6. Çıkış Yap");
            Console.Write("Seçiminiz: ");
            string secim = Console.ReadLine();

            if (secim == "1")
            {
                BakiyeGoruntule();
            }
            else if (secim == "2")
            {
                ParaYatir();
            }
            else if (secim == "3")
            {
                ParaCek();
            }
            else if (secim == "4")
            {
                HesapGecmisi();
            }
            else if (secim == "5")
            {
                HavaleEFT();
            }
            else if (secim == "6")
            {
                aktifKullanici = null;
                Console.WriteLine("Çıkış yapılıyor...");
                break;
            }
            else
            {
                Console.WriteLine("Geçersiz seçim. Tekrar deneyin.");
                Console.ReadLine();
            }
        }
    }

    static void BakiyeGoruntule()
    {
        Console.Clear();
        Console.WriteLine($"Mevcut Bakiyeniz: {aktifKullanici.KullaniciHesabi.Bakiye:F2} TL");
        Console.ReadLine();
    }

    static void ParaYatir()
    {
        Console.Clear();
        Console.Write("Yatırılacak Tutar: ");
        double miktar = Convert.ToDouble(Console.ReadLine());

        if (miktar > 0)
        {
            aktifKullanici.KullaniciHesabi.Bakiye += miktar;
            aktifKullanici.KullaniciHesabi.Hareketler.Add(new HesapHareketi
            {
                Tur = "Para Yatırma",
                Tutar = miktar,
                Tarih = DateTime.Now
            });

            Console.WriteLine("Para yatırma işlemi başarılı!");
        }
        else
        {
            Console.WriteLine("Geçersiz tutar.");
        }
        Console.ReadLine();
    }

    static void ParaCek()
    {
        Console.Clear();
        Console.Write("Çekilecek Tutar: ");
        double miktar = Convert.ToDouble(Console.ReadLine());

        if (miktar > 0 && miktar <= aktifKullanici.KullaniciHesabi.Bakiye)
        {
            aktifKullanici.KullaniciHesabi.Bakiye -= miktar;
            aktifKullanici.KullaniciHesabi.Hareketler.Add(new HesapHareketi
            {
                Tur = "Para Çekme",
                Tutar = miktar,
                Tarih = DateTime.Now
            });

            Console.WriteLine("Para çekme işlemi başarılı!");
        }
        else
        {
            Console.WriteLine("Geçersiz tutar veya yetersiz bakiye.");
        }
        Console.ReadLine();
    }

    static void HesapGecmisi()
    {
        Console.Clear();
        Console.WriteLine("Hesap Geçmişi:");
        foreach (var hareket in aktifKullanici.KullaniciHesabi.Hareketler)
        {
            Console.WriteLine($"{hareket.Tarih}: {hareket.Tur} - {hareket.Tutar:F2} TL");
        }

        if (aktifKullanici.KullaniciHesabi.Hareketler.Count == 0)
        {
            Console.WriteLine("Henüz işlem yapılmamış.");
        }
        Console.ReadLine();
    }

    static void HavaleEFT()
    {
        Console.Clear();
        Console.Write("Gönderilecek Tutar: ");
        double miktar = Convert.ToDouble(Console.ReadLine());
        Console.Write("Hedef Hesap Sahibi: ");
        string hedefHesapSahibi = Console.ReadLine();
        Console.Write("Hesap no: ");
        string hesapno = Console.ReadLine();

        if (miktar > 0 && miktar <= aktifKullanici.KullaniciHesabi.Bakiye)
        {
            aktifKullanici.KullaniciHesabi.Bakiye -= miktar;
            aktifKullanici.KullaniciHesabi.Hareketler.Add(new HesapHareketi
            {
                Tur = "Havale/EFT",
                Tutar = miktar,
                Tarih = DateTime.Now
            });

            Console.WriteLine($"Havale/EFT işlemi başarılı! {hedefHesapSahibi} hesabına {miktar:F2} TL gönderildi.");
        }
        else
        {
            Console.WriteLine("Geçersiz tutar veya yetersiz bakiye.");
        }
        Console.ReadLine();
    }
}

class Kullanici
{
    public string KullaniciAdi { get; set; }
    public string Sifre { get; set; }
    public Hesap KullaniciHesabi { get; set; }
}

class Hesap
{
    public string HesapSahibi { get; set; }
    public double Bakiye { get; set; }
    public string MusteriTemsilcisi { get; set; }
    public List<HesapHareketi> Hareketler { get; set; } = new List<HesapHareketi>();
}

class HesapHareketi
{
    public string Tur { get; set; } // İşlem türü (ör. "Para Yatırma", "Para Çekme")
    public double Tutar { get; set; } // İşlem tutarı
    public DateTime Tarih { get; set; } // İşlem tarihi
}
