using System;

namespace ConsoleApp11
{
    // Bu sınıf tabloyu temsil eder ve Node tipindeki diziyi içerir.
    class Tablo
    {
        Node[] dizi;
        int size;

        public Tablo(int size)
        {
            this.size = size;
            dizi = new Node[size];

            for (int i = 0; i < size; i++)
            {
                dizi[i] = new Node();
            }
        }

        public int indexUret(int key)
        {
            return key % size;
        }

        public void ekle(int key, string isim)
        {
            int indis = indexUret(key);
            Node eleman = new Node(key, isim);
            Node temp = dizi[indis];

            if (temp.next == null)
            {
                temp.next = eleman;
                Console.WriteLine("Sütunun ilk elemanı eklendi");
            }
            else
            {
                eleman.next = dizi[indis].next;
                dizi[indis].next = eleman;

                Console.WriteLine(key + " eklendi");
            }
        }

        public void sil(int key)
        {
            bool sonuc = false;
            int indis = indexUret(key);
            Node temp = dizi[indis];

            if (temp.next == null)
            {
                Console.WriteLine(key + " numaralı kayıt yok!");
                sonuc = true;
            }
            else if (temp.next.next == null && temp.next.key == key)
            {
                temp.next = null;
                Console.WriteLine(key + " numaralı kişi silindi");
                sonuc = true;
            }
            else
            {
                Node temp2 = temp;
                while (temp.next != null)
                {
                    temp2 = temp;
                    temp = temp.next;
                    if (temp.key == key)
                    {
                        temp2.next = temp.next;
                        Console.WriteLine(key + " numaralı kişi silindi");
                        sonuc = true;
                        break;
                    }
                }
                if (!sonuc)
                {
                    Console.WriteLine(key + " numaralı kişi bulunamadı");
                }
            }
        }

        public void yazdir()
        {
            for (int i = 0; i < size; i++)
            {
                Node temp = dizi[i];
                Console.Write("Dizi [{0}] -> ", i);

                while (temp.next != null)
                {
                    temp = temp.next;
                    Console.Write(temp.key + " " + temp.isim + " -> ");
                }

                Console.WriteLine();
            }
        }

        public void adetBul()
        {
            int sayac = 0;
            for (int i = 0; i < size; i++)
            {
                Node temp = dizi[i];

                while (temp.next != null)
                {
                    temp = temp.next;
                    sayac++;
                }
            }

            if (sayac == 0)
            {
                Console.WriteLine("Tabloda kayıtlı veri yok");
            }
            else
            {
                Console.WriteLine("Tabloda kayıtlı kişi sayısı: " + sayac);
            }
        }

        public void kisiBul(int key)
        {
            bool sonuc = false;
            for (int i = 0; i < size; i++)
            {
                Node temp = dizi[i];

                while (temp.next != null)
                {
                    temp = temp.next;
                    if (key == temp.key)
                    {
                        Console.WriteLine(temp.key + " numaralı kişi bilgileri: " + temp.isim);
                        sonuc = true;
                        break;
                    }
                }
            }

            if (!sonuc)
            {
                Console.WriteLine(key + " numaralı kişi bulunamadı!");
            }
        }
    }
}
