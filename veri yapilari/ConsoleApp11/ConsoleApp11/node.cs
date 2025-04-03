using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp11
{
    // Bu sınıf, düğüm yapısını temsil eder. Linked List (Bağlı Liste) için kullanılacak.
    class Node
    {
        public int key;       // Her düğümün benzersiz anahtarı (ID gibi düşünebiliriz)
        public string isim;    // Düğüme ait isim bilgisi
        public Node next;      // Sonraki düğüme işaret eden gösterici

        // Varsayılan Yapıcı Metod: Boş bir düğüm oluşturur.
        public Node()
        {
            this.next = null;  // Başlangıçta bir sonraki düğüm yok.
        }

        // Parametreli Yapıcı Metod: Anahtar ve isimle birlikte bir düğüm oluşturur.
        public Node(int key, string isim)
        {
            this.key = key;
            this.isim = isim;
            this.next = null; // Başlangıçta bir sonraki düğüm yok
        }
    }
}