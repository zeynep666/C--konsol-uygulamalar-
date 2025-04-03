using System;

namespace ConsoleApp7
{
    class Program
    {
        static void Main(string[] args)
        {
            Liste cydaliste = new Liste(); // Liste nesnesi oluşturuluyor
            int sayi, indis;

            int secim = menu(); // Menü fonksiyonu çağrılır

            // Kullanıcı sıfır seçeneği ile çıkmadığı sürece döngü devam eder
            while (secim != 0)
            {
                Console.Clear(); // Menü her döngü başında temizlensin

                switch (secim)
                {
                    case 1: // Başa eleman ekleme
                        Console.Write("Sayı: ");
                        sayi = int.Parse(Console.ReadLine());
                        cydaliste.basaEkle(sayi); // Başa eleman eklenir
                        cydaliste.yazdir(); // Liste yazdırılır
                        break;

                    case 2: // Sona eleman ekleme
                        Console.Write("Sayı: ");
                        sayi = int.Parse(Console.ReadLine());
                        cydaliste.sonaEkle(sayi); // Sona eleman eklenir
                        cydaliste.yazdir(); // Liste yazdırılır
                        break;

                    case 3: // Araya eleman ekleme
                        Console.Write("İndis: ");
                        indis = int.Parse(Console.ReadLine());
                        Console.Write("Sayı: ");
                        sayi = int.Parse(Console.ReadLine());
                        cydaliste.arayaEkle(indis, sayi); // Belirtilen indise eleman eklenir
                        cydaliste.yazdir(); // Liste yazdırılır
                        break;

                    case 4: // Baştan eleman silme
                        cydaliste.bastanSil(); // Baştan eleman silinir
                        cydaliste.yazdir(); // Liste yazdırılır
                        break;

                    case 5: // Sondan eleman silme
                        cydaliste.sondanSil(); // Sondan eleman silinir
                        cydaliste.yazdir(); // Liste yazdırılır
                        break;

                    case 6: // Belirtilen indisten eleman silme
                        Console.Write("İndis: ");
                        indis = int.Parse(Console.ReadLine());
                        cydaliste.aradanSil(indis); // Aradan eleman silinir
                        cydaliste.yazdir(); // Liste yazdırılır
                        break;

                    case 7: // Listeyi tersten yazdırma
                        cydaliste.terstenYazdir(); // Liste tersten yazdırılır
                        break;

                    case 0: // Program sonlandırma
                        break;

                    default: // Hatalı seçim
                        Console.WriteLine("Hatalı seçim yaptınız!"); // Hatalı seçim mesajı
                        break;
                }

                secim = menu(); // Yeni bir seçim alınır
            }

            Console.WriteLine("Program kapatıldı.");
            Console.ReadKey();
        }

        // Menü fonksiyonu
        private static int menu()
        {
            Console.WriteLine("\n\n1 - Başa ekle");
            Console.WriteLine("2 - Sona ekle");
            Console.WriteLine("3 - Araya ekle");
            Console.WriteLine("4 - Baştan sil");
            Console.WriteLine("5 - Sondan sil");
            Console.WriteLine("6 - Aradan sil");
            Console.WriteLine("7 - Tersten yazdır");
            Console.WriteLine("0 - Programı kapat");
            Console.Write("Seçiminiz: ");

            return int.Parse(Console.ReadLine()); // Kullanıcının seçimi alınır
        }
    }

    // Liste elemanını temsil eden Node sınıfı
    class Node
    {
        public int data; // Veri
        public Node next; // Sonraki eleman
        public Node prev; // Önceki eleman

        public Node(int data)
        {
            this.data = data;
            this.next = null;
            this.prev = null;
        }
    }

    // Çift yönlü bağlı listeyi temsil eden Liste sınıfı
    class Liste
    {
        Node head; // Baş eleman
        Node tail; // Son eleman

        public Liste()
        {
            this.head = null; // Baş eleman başlangıçta null
            this.tail = null; // Son eleman başlangıçta null
        }

        // Başa eleman ekleme fonksiyonu
        public void basaEkle(int data)
        {
            Node eleman = new Node(data); // Yeni eleman oluşturuluyor

            if (head == null)
            {
                head = tail = eleman; // Liste boşsa, yeni eleman hem baş hem de son olur
                tail.next = head; // Sondan başa bağlantı
                tail.prev = head; // Baştan sona bağlantı
                head.next = tail; // Baştan sona bağlantı
                head.prev = tail; // Sondan başa bağlantı
                Console.WriteLine("Liste yapısı oluşturuldu, ilk eleman eklendi.");
            }
            else
            {
                eleman.next = head; // Yeni eleman başa bağlanır
                head.prev = eleman; // Başın önceki bağlantısı yeni elemana yapılır

                head = eleman; // Baş eleman güncellenir

                head.prev = tail; // Yeni başın önceki bağlantısı son elemana yapılır
                tail.next = head; // Son elemanın sonraki bağlantısı baş elemana yapılır
                Console.WriteLine("Başa eleman eklendi.");
            }
        }

        // Sona eleman ekleme fonksiyonu
        public void sonaEkle(int data)
        {
            Node eleman = new Node(data); // Yeni eleman oluşturuluyor

            if (head == null)
            {
                head = tail = eleman; // Liste boşsa, yeni eleman hem baş hem de son olur
                tail.next = head; // Sondan başa bağlantı
                tail.prev = head; // Baştan sona bağlantı
                head.next = tail; // Baştan sona bağlantı
                head.prev = tail; // Sondan başa bağlantı
                Console.WriteLine("Liste yapısı oluşturuldu, ilk eleman eklendi.");
            }
            else
            {
                tail.next = eleman; // Sona yeni eleman eklenir
                eleman.prev = tail; // Yeni elemanın önceki bağlantısı son elemana yapılır

                tail = eleman; // Son eleman güncellenir

                tail.next = head; // Son elemanın sonraki bağlantısı baş elemana yapılır
                head.prev = tail; // Baş elemanın önceki bağlantısı son elemana yapılır

                Console.WriteLine("Sona eleman eklendi.");
            }
        }

        // Araya eleman ekleme fonksiyonu
        public void arayaEkle(int indis, int data)
        {
            Node eleman = new Node(data); // Yeni eleman oluşturuluyor

            if (head == null && indis == 0)
            {
                basaEkle(data); // Liste boşsa, başa eklenir
            }
            else if (head != null && indis == 0)
            {
                basaEkle(data); // Liste boş değilse, başa eklenir
            }
            else
            {
                int i = 0;
                Node temp = head;
                Node temp2 = temp;

                // İndise kadar geçilir ve doğru yer bulunduğunda eleman eklenir
                while (temp != tail)
                {
                    if (i == indis)
                    {
                        temp2.next = eleman; // Geçici önceki elemanın sonraki bağlantısı yeni elemana yapılır
                        eleman.prev = temp2; // Yeni elemanın önceki bağlantısı geçici elemana yapılır

                        eleman.next = temp; // Yeni elemanın sonraki bağlantısı geçici sonraki elemana yapılır
                        temp.prev = eleman; // Geçici sonraki elemanın önceki bağlantısı yeni elemana yapılır
                        Console.WriteLine("Araya eleman eklendi.");
                        return;
                    }

                    temp2 = temp;
                    temp = temp.next;
                    i++;
                }
                if (i == indis)
                {
                    temp2.next = eleman; // Sonraki eleman bulunduğunda yeni eleman eklenir
                    eleman.prev = temp2; // Yeni elemanın önceki bağlantısı geçici elemana yapılır

                    eleman.next = temp; // Yeni elemanın sonraki bağlantısı geçici sonraki elemana yapılır
                    temp.prev = eleman; // Geçici sonraki elemanın önceki bağlantısı yeni elemana yapılır
                    Console.WriteLine("Araya eleman eklendi.");
                }
            }
        }

        // Listeyi yazdırma fonksiyonu
        public void yazdir()
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş.");
                return;
            }

            Node temp = head;
            Console.Write("Baş -> ");
            // Liste baştan sona doğru yazdırılır
            while (temp != tail)
            {
                Console.Write(temp.data + " -> ");
                temp = temp.next;
            }
            Console.WriteLine(temp.data + " -> Son.");
        }

        // Listeyi tersten yazdırma fonksiyonu
        public void terstenYazdir()
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş.");
                return;
            }

            Node temp = tail;
            Console.Write("Son -> ");
            // Liste sondan başa doğru yazdırılır
            while (temp != head)
            {
                Console.Write(temp.data + " -> ");
                temp = temp.prev;
            }
            Console.WriteLine(temp.data + " -> Baş.");
        }

        // Baştan eleman silme fonksiyonu
        public void bastanSil()
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş.");
            }
            else if (head.next == head)
            {
                head = tail = null; // Liste tek elemanlıysa baş ve son null yapılır
                Console.WriteLine("Eleman silindi, listede eleman kalmadı.");
            }
            else
            {
                head = head.next; // Baş eleman bir sonraki elemana güncellenir
                head.prev = tail; // Baş elemanın önceki bağlantısı son elemana yapılır
                tail.next = head; // Son elemanın sonraki bağlantısı baş elemana yapılır
                Console.WriteLine("Baştan eleman silindi.");
            }
        }

        // Sondan eleman silme fonksiyonu
        public void sondanSil()
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş.");
            }
            else if (head.next == head)
            {
                head = tail = null; // Liste tek elemanlıysa baş ve son null yapılır
                Console.WriteLine("Eleman silindi, listede eleman kalmadı.");
            }
            else
            {
                tail = tail.prev; // Son eleman bir önceki elemana güncellenir
                tail.next = head; // Son elemanın sonraki bağlantısı baş elemana yapılır
                head.prev = tail; // Baş elemanın önceki bağlantısı son elemana yapılır
                Console.WriteLine("Sondan eleman silindi.");
            }
        }

        // Aradan eleman silme fonksiyonu
        public void aradanSil(int indis)
        {
            if (head == null)
            {
                Console.WriteLine("Liste boş.");
            }
            else if (head.next != head && indis == 0)
            {
                bastanSil(); // İndis 0 ise baştan silme yapılır
            }
            else
            {
                Node temp = head;
                Node temp2 = temp;
                int i = 0;

                // Belirtilen indise kadar gidilir ve o indisteki eleman silinir
                while (temp != tail)
                {
                    if (i == indis)
                    {
                        temp2.next = temp.next; // Geçici önceki elemanın sonraki bağlantısı yeni sonraki elemana yapılır
                        temp.next.prev = temp2; // Yeni sonraki elemanın önceki bağlantısı geç

                        // Yeni sonraki elemanın önceki bağlantısı geçici elemana yapılır
                        temp.next.prev = temp2;
                        Console.WriteLine("Aradan eleman silindi.");
                        return;
                    }
                    temp2 = temp;
                    temp = temp.next;
                    i++;
                }
                // Eğer son elemanda belirtilen indeks varsa, sondan silme yapılır
                if (i == indis)
                {
                    temp2.next = temp.next;
                    temp.next.prev = temp2;
                    Console.WriteLine("Aradan eleman silindi.");
                }
            }
        }
    }
}