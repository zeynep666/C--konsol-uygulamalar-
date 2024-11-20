using System;

namespace kullaniciBilgi
{
    class Bligi
    {
        static void Main(string[] args) 
        {
            // Kullanıcıdan bilgilerini aldım
            Console.Write("Adınızı giriniz: ");
            string ad = Console.ReadLine();

            Console.Write("Soyadınızı giriniz: ");
            string soyad = Console.ReadLine();

            Console.Write("Öğrenci numaranızı giriniz: ");
            string ogrenciNo = Console.ReadLine();

            Console.Write("Telefon numaranızı giriniz: ");
            string telNo = Console.ReadLine();

            Console.Write("TC no giriniz: ");
            string tcNo = Console.ReadLine();

            Console.Write("Doğum tarihinizi giriniz (örneğin:22.10.2000): ");
            string dogumTarih = Console.ReadLine();

            Console.Write("Yaşınızı giriniz: ");
            string yas = Console.ReadLine();

            if (telNo.Length == 10) // telefon numarasını 10 olarak aldığımdan böyle bir yol kullandım
            {
               telNo = telNo.Insert(3, "-").Insert(7, "-").Insert(10, "-"); // aralara çizgi koymasını sağlamak için ınsert metodunu kullandım
            }
            // Bilgilerin ekrana yazdırılması
            Console.WriteLine("\n--- Kullanıcı Bilgileri ---");
            Console.WriteLine("Ad: " + ad);
            Console.WriteLine("Soyad: " + soyad);
            Console.WriteLine("Öğrenci No: " + ogrenciNo);
            Console.WriteLine("Cep Telefonu: " + telNo);
            Console.WriteLine("TC no:" + tcNo);
            Console.WriteLine("Doğum tarihi:" + dogumTarih);
            Console.WriteLine("Yaş:" + yas);

            Console.ReadLine(); // Konsolu açık tutmak için
        }
    }
}

