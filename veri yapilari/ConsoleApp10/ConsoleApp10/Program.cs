using System;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ağaç veri yapısını oluşturuyoruz.
            Console.WriteLine("Ağaç veri yapısı");

            Tree bst = new Tree();

            // Ağaç düğümlerini ekliyoruz.
            bst.root = bst.insert(bst.root, 10);
            bst.root = bst.insert(bst.root, 5);
            bst.root = bst.insert(bst.root, 15);
            bst.root = bst.insert(bst.root, 20);
            bst.root = bst.insert(bst.root, 3);
            bst.root = bst.insert(bst.root, 12);
            bst.root = bst.insert(bst.root, 9);

            // Öncelikli sıralama (preOrder) işlemi
            Console.WriteLine("PreOrder: ");
            bst.preOrder(bst.root);
            Console.WriteLine();

            // Ortadan sıralama (inOrder) işlemi
            Console.WriteLine("InOrder: ");
            bst.inOrder(bst.root);
            Console.WriteLine();

            // Sonradan sıralama (postOrder) işlemi
            Console.WriteLine("PostOrder: ");
            bst.postOrder(bst.root);
            Console.WriteLine();

            Console.ReadKey();
        }
    }

    // Düğüm (Node) sınıfı
    class Node
    {
        public int data; // Düğümün tuttuğu veri
        public Node left; // Sol çocuk düğüm
        public Node right; // Sağ çocuk düğüm

        public Node(int data)
        {
            this.data = data;
            left = null;
            right = null;
        }
    }

    // Ağaç (Tree) sınıfı
    class Tree
    {
        public Node root; // Ağacın kök düğümü

        public Tree()
        {
            root = null; // Başlangıçta ağaç boş
        }

        // Yeni düğüm oluşturma fonksiyonu
        public Node newNode(int data)
        {
            return new Node(data);
        }

        // Ağaca eleman ekleme fonksiyonu
        public Node insert(Node root, int data)
        {
            if (root == null)
            {
                return newNode(data); // Eğer kök boşsa, yeni düğüm oluştur
            }

            if (data < root.data)
            {
                root.left = insert(root.left, data); // Eğer eklenen veri kökten küçükse sol alt ağaçta ilerle
            }
            else
            {
                root.right = insert(root.right, data); // Eğer eklenen veri kökten büyükse sağ alt ağaçta ilerle
            }

            return root; // Güncellenmiş ağacı geri döndür
        }

        // PreOrder sıralama: Kök -> Sol -> Sağ
        public void preOrder(Node root)
        {
            if (root != null)
            {
                Console.Write(root.data + "    ");
                preOrder(root.left);
                preOrder(root.right);
            }
        }

        // InOrder sıralama: Sol -> Kök -> Sağ
        public void inOrder(Node root)
        {
            if (root != null)
            {
                inOrder(root.left);
                Console.Write(root.data + "    ");
                inOrder(root.right);
            }
        }

        // PostOrder sıralama: Sol -> Sağ -> Kök
        public void postOrder(Node root)
        {
            if (root != null)
            {
                postOrder(root.left);
                postOrder(root.right);
                Console.Write(root.data + "    ");
            }
        }
    }
}
