using System; //temel sistem işlevlerini kullanabilmek için gerekli olan namespacei içe aktarmaya yarar

namespace geometrikOrtalama //namespace kodun mantıksal bir yapıda organize edilmesine yardımcı olur geometrikOrtalama ise bu isim altındaki tüm kodların bu isme bağlı olarak organize edilmesini sağlar
{
    class Ortalama //bir sınıf tanımladım ve metodları bu sınıfın içine yazdım
    {
        static void Main(string[] args) //programın başlangıç noktası
        {
            // Kullanıcıdan ilk sayıyı alıyoruz
            Console.Write("Birinci sayıyı giriniz: ");
            double sayi1 = Convert.ToDouble(Console.ReadLine());
            // Burda da kullanıcıdan ikinci sayıyı alıyoruz
            Console.Write("İkinci sayıyı giriniz: ");
            double sayi2 = Convert.ToDouble(Console.ReadLine());

            // Geometrik ortalama hesaplanması
            //iki sayıyı çarpıp kare kökünü almak icin Math.Sqrt() metodunu kullandım
            double geometrikOrtalama = Math.Sqrt(sayi1 * sayi2);

            // Sonucu ekrana yazdırdım 
            Console.WriteLine("Geometrik Ortalama: " + geometrikOrtalama);
            //kullanıcının sonucu bi tuşa basılana kadargörebilmesi için kullandım
            Console.ReadLine();
        }
    }
}

