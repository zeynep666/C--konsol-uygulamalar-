using System;

namespace Bankamatik
{
    class Program
    {
        static void Main(string[] args)
        {
            int bakiye = 1000;

            Console.WriteLine("Bankamatik Sistemine Hoş Geldiniz!");
            Console.Write("Lütfen bir kullanıcı adı oluşturun: ");
            string kullaniciAdi = Console.ReadLine();
            Console.Write("Lütfen bir şifre oluşturun: ");
            
            string sifre = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("\nKullanıcı adı ve şifre başarıyla oluşturuldu!");
            Console.WriteLine("Giriş ekranına yönlendiriliyorsunuz...\n");
            Console.Write("Kullanıcı Adınızı Girin: ");
            string girilenKullaniciAdi = Console.ReadLine();

            Console.Write("Şifrenizi Girin: ");
            string girilenSifre = Console.ReadLine();

            if (girilenKullaniciAdi != kullaniciAdi || girilenSifre != sifre)
            {
                Console.WriteLine("Hatalı kullanıcı adı veya şifre!");
                Console.ReadLine();
            }
            
            Console.WriteLine("Giriş başarılı!");

            while (true)
            {
               
                Console.WriteLine("\nLütfen bir işlem seçin:");
                Console.WriteLine("1. Bakiye Görüntüle");
                Console.WriteLine("2. Para Yatır");
                Console.WriteLine("3. Para Çek");
                Console.WriteLine("4. Çıkış");

                Console.Write("Seçiminiz: ");
                string secim = Console.ReadLine();

                switch (secim)
                {
                    case "1": 
                        Console.WriteLine($"Bakiyeniz: {bakiye} TL");
                        break;

                    case "2": 
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
                        break;

                    case "3": 
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
                        break;

                    case "4": 
                        Console.WriteLine("Çıkış yapılıyor. İyi günler!");
                        return;

                    default:
                        Console.WriteLine("Geçersiz seçim, lütfen tekrar deneyin.");
                        break;
                }
            }
        }
    }
}

