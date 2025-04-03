using System;

namespace ConsoleApp9
{
    class Program
    {
        static void Main(string[] args)
        {
            // Stack yapısını oluşturuyoruz.
            StackYapisi stc = new StackYapisi();
            int sayi;

            int secim = menu();
            while (secim != 0)
            {
                switch (secim)
                {
                    case 1:
                        Console.Write("Sayı girin: ");
                        sayi = int.Parse(Console.ReadLine()); // Kullanıcıdan bir sayı alıyoruz.
                        stc.push(sayi); // Sayıyı stack'e ekliyoruz.
                        break;

                    case 2:
                        sayi = stc.pop(); // Stack'ten bir eleman çıkarıyoruz.
                        if (sayi != -1)
                        {
                            Console.WriteLine("Çıkan sayı: " + sayi);
                        }
                        else
                        {
                            Console.WriteLine("Stack boş.");
                        }
                        break;

                    case 3:
                        stc.print(); // Stack'in içeriğini yazdırıyoruz.
                        break;

                    case 4:
                        stc.topPrint(); // Stack'in en üstündeki elemanı yazdırıyoruz.
                        break;

                    default:
                        Console.WriteLine("Hatalı seçim! Lütfen tekrar deneyin.");
                        break;
                }
                secim = menu(); // Kullanıcıdan yeni bir seçim alıyor
                
                //Console.Clear();
            }
            
            Console.WriteLine("Program sonlandırıldı.");
            
        }

        private static int menu()
        {
            // Kullanıcıya menü seçeneklerini gösteriyoruz.
            Console.WriteLine("\n===== Stack İşlemleri =====");
            Console.WriteLine("1 - Push (Eleman Ekle)");
            Console.WriteLine("2 - Pop (Eleman Çıkar)");
            Console.WriteLine("3 - Print (Stack’i Yazdır)");
            Console.WriteLine("4 - Top (Üstteki Elemanı Göster)");
            Console.WriteLine("0 - Exit (Çıkış)");
            Console.Write("Seçiminiz: ");

            int secim;
            while (!int.TryParse(Console.ReadLine(), out secim))
            {
                Console.Write("Lütfen geçerli bir sayı girin: ");
            }

            return secim;
        }
    }

    // Stack'te kullanılacak düğüm sınıfı
    class Node
    {
        public int data; // Düğümün tuttuğu veri
        public Node next; // Bir sonraki düğüme referans

        public Node(int data)
        {
            this.data = data;
            next = null;
        }
    }

    class StackYapisi
    {
        private Node top; // Stack'in en üstündeki düğümü tutan değişken

        public StackYapisi()
        {
            top = null; // Stack başlangıçta boş
        }

        // Stack'e yeni eleman ekleme (push) işlemi
        public void push(int data)
        {
            Node eleman = new Node(data);
            if (top == null)
            {
                top = eleman;
                Console.WriteLine("Stack oluşturuldu, ilk eleman eklendi.");
            }
            else
            {
                eleman.next = top; // Yeni düğüm eski top'un önüne eklenir
                top = eleman; // Yeni eleman artık en üstte
                Console.WriteLine("Eleman eklendi.");
            }
        }

        // Stack'ten eleman çıkarma (pop) işlemi
        public int pop()
        {
            if (top == null)
            {
                Console.WriteLine("Stack boş! Çıkarılacak eleman yok.");
                return -1;
            }
            else
            {
                int sayi = top.data; // En üstteki elemanı alıyoruz
                top = top.next; // En üstteki elemanı çıkartıyoruz
                return sayi;
            }
        }

        // Stack içeriğini ekrana yazdırma
        public void print()
        {
            if (top == null)
            {
                Console.WriteLine("Stack boş.");
            }
            else
            {
                Node temp = top;
                Console.WriteLine("\nStack içeriği:");
                while (temp != null)
                {
                    Console.WriteLine(temp.data);
                    temp = temp.next;
                }
            }
        }

        // Stack'in en üstündeki elemanı ekrana yazdırma
        public void topPrint()
        {
            if (top == null)
            {
                Console.WriteLine("Stack boş.");
            }
            else
            {
                Console.WriteLine("Üstteki eleman: " + top.data);
            }
        }
    }
}