using System;

namespace Bankamatik
{
    class Program
    {
        static void Main(string[] args)
        {
            int bakiye = 1000;

            // Kullanıcıdan kullanıcı adı ve şifre belirlemesini iste
            Console.WriteLine("Bankamatik Sistemine Hoş Geldiniz!");
            Console.Write("Lütfen bir kullanıcı adı oluşturun: ");
            string kullaniciAdi = Console.ReadLine();

            Console.Write("Lütfen bir şifre oluşturun: ");
            string sifre = Console.ReadLine();

            Console.WriteLine("Kullanıcı adı ve şifre başarıyla oluşturuldu!");
            Console.WriteLine("Giriş ekranına yönlendiriliyorsunuz...\n");

            // Kullanıcı giriş sistemi
            Console.Write("Kullanıcı Adınızı Girin: ");
            string girilenKullaniciAdi = Console.ReadLine();

            Console.Write("Şifrenizi Girin: ");
            string girilenSifre = Console.ReadLine();

            if (girilenKullaniciAdi != kullaniciAdi || girilenSifre != sifre)
            {
                Console.WriteLine("Hatalı kullanıcı adı veya şifre!");
                return;
            }

            Console.WriteLine("Giriş başarılı!");

            while (true) // Kullanıcı çıkana kadar devam edecek
            {
                // Menü seçenekleri
                Console.WriteLine("\nLütfen bir işlem seçin:");
                Console.WriteLine("1. Bakiye Görüntüle");
                Console.WriteLine("2. Para Yatır");
                Console.WriteLine("3. Para Çek");
                Console.WriteLine("4. Çıkış");

                Console.Write("Seçiminiz: ");
                string secim = Console.ReadLine();

                if (secim == "1") // Bakiye Görüntüleme
                {
                    Console.WriteLine($"Bakiyeniz: {bakiye} TL");
                }
                else if (secim == "2") // Para Yatırma
                {
                    Console.Write("Yatırmak istediğiniz tutarı girin: ");
                    int yatirilanTutar = Convert.ToInt32(Console.ReadLine());
                    if (yatirilanTutar > 0)
                    {
                        bakiye += yatirilanTutar;
                        Console.WriteLine($"Yeni bakiyeniz: {bakiye} TL");
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz tutar!");
                    }
                }
                else if (secim == "3") // Para Çekme
                {
                    Console.Write("Çekmek istediğiniz tutarı girin: ");
                    int cekilenTutar = Convert.ToInt32(Console.ReadLine());
                    if (cekilenTutar > 0 && cekilenTutar <= bakiye)
                    {
                        bakiye -= cekilenTutar;
                        Console.WriteLine($"Yeni bakiyeniz: {bakiye} TL");
                    }
                    else if (cekilenTutar > bakiye)
                    {
                        Console.WriteLine("Yetersiz bakiye!");
                    }
                    else
                    {
                        Console.WriteLine("Geçersiz tutar!");
                    }
                }
                else if (secim == "4") // Çıkış
                {
                    Console.WriteLine("Çıkış yapılıyor. İyi günler!");
                    break;
                }
                else
                {
                    Console.WriteLine("Geçersiz seçim, lütfen tekrar deneyin.");
                }
            }
        }
    }
}
