using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace öyylesine
{
    class Node1
    {
        public EgeDeniziB data;
        public Node1 left;
        public Node1 right;

        public Node1(EgeDeniziB data)
        {
            this.data = data;
            left = null;
            right = null;
        }



    }


    internal class BalıkAgacı
    {
        public Node1 root;
        public Node1 getRoot()
        {
            return root;
        }
        public BalıkAgacı()
        {
            root = null;
        }
        public Node1 newNode(EgeDeniziB data)
        {
            root = new Node1(data);

            return root;
        }

        public Node1 insert(Node1 root, EgeDeniziB data)
        {
            Node1 eleman = new Node1(data);

            if (root != null)
            {

                if (data.balıkAdı.ToLower().CompareTo(root.data.balıkAdı.ToLower()) < 0)
                {
                    root.left = insert(root.left, data);

                }
                else
                {
                    root.right = insert(root.right, data);

                }

            }
            else
            {
                root = newNode(data);

            }
            return root;

        }

       public void BuildBalancedTree(EgeDeniziB[] sortedBalıklar)//1.d için
        {
            this.root = BuildBalancedTreeRecursive(sortedBalıklar,0,sortedBalıklar.Length-1);
        }

        public Node1 BuildBalancedTreeRecursive(EgeDeniziB[] sortedBalıklar, int startIndex, int endIndex)//1.d içinıı
        {
            if (startIndex>endIndex)
            {
                return null;
            }

            int mid=(startIndex+endIndex)/2;
            Node1 node = newNode(sortedBalıklar[mid]);
            node.left = BuildBalancedTreeRecursive(sortedBalıklar, startIndex, mid - 1);
            node.right=BuildBalancedTreeRecursive(sortedBalıklar, mid + 1, endIndex );

            return node;


        }

          

        //orderlarda balık adını yazdırıyoruz.
        public void preOrder1(Node1 root)
        {
            if (root != null)
            {
                Console.WriteLine(root.data.balıkAdı + " ");
                preOrder1(root.left);
                preOrder1(root.right);
            }


        }
        public void inOrder1(Node1 rooot)//1.a kısmı burada komple halledildi
        {
            if (rooot != null)
            {
                inOrder1(rooot.left);
                Console.WriteLine("mevcut balık: "+rooot.data.balıkAdı);
                Console.WriteLine(rooot.data.balıkAdı+" balığının kelimeler ağacının inorder sıralanması: ");
                rooot.data.kelimelerAğacı.inOrder(rooot.data.kelimelerAğacı.root);
                Console.WriteLine("\n");
                inOrder1(rooot.right);
            }
            

        }

        public void postOrder1(Node1 root)
        {
            if (root != null)
            {
                postOrder1(root.left);
                postOrder1(root.right);
                Console.WriteLine(root.data.balıkAdı + " ");

            }


        }


        public int size(Node1 root)
        {
            if (root == null)
            {
                return 0;

            }
            else
            {

                return size(root.left) + 1 + size(root.right);

            }




        }


        public int height(Node1 root)
        {
            if (root == null)
            {
                return -1;//yükseklik yok!
            }

            else
            {
                int l, r;

                l = height(root.left);
                r = height(root.right);

                return Math.Max(l, r) + 1;




            }


        }

    }

    internal class Heap//3.a kısmı(kitaptan bakarak yazdım ancak doğru çalışmadı(son balık Sardalya dedi o yüzden aşağıda tekrardan yaptım) )
    {

        public Node1[] heapArray;
        public int maxSize;
        public int currentSize;

        public Heap(int mx)
        {
            this.maxSize = mx;
            currentSize = 0;
            heapArray = new Node1[maxSize];

        }

        public EgeDeniziB ExtractMax()
        {
            if (heapArray.Length == 0)
                throw new InvalidOperationException("Heap is empty.");

            EgeDeniziB max = heapArray[0].data;
            heapArray[0] = heapArray[heapArray.Length - 1];
            //heap.RemoveAt(heap.Count - 1);
            trickleDown(0);
            return max;
        }

        public bool isEmpty()
        {
            return currentSize == 0;
        }

        public bool insert(EgeDeniziB key)
        {
            if (currentSize == maxSize)
            {
                return false;

            }
            Node1 newNode = new Node1(key);
            heapArray[currentSize] = newNode;
            trickleUp(currentSize++);
            return true;
        }

        public void trickleUp(int index)
        {

            int parent = (index - 1) / 2;
            //Node1 parentNode= heapArray[parent];
            Node1 bottom = heapArray[index];
            while (index > 0 && heapArray[parent].data.balıkAdı.ToLower().CompareTo(bottom.data.balıkAdı.ToLower()) < 0)
            {
                heapArray[index] = heapArray[parent];
                index = parent;
                parent = (parent - 1) / 2;


            }
            heapArray[index] = bottom;

        }

        public Node1 remove()
        {
            Node1 root = heapArray[0];
            heapArray[0] = heapArray[--currentSize];
            trickleDown(0);
            return root;


        }
        public void trickleDown(int index)
        {

            int largerChild;
            Node1 top = heapArray[index];
            while (index < currentSize / 2)
            {
                int leftChild = 2 * index + 1;
                int rightChild = leftChild + 1;
                if (rightChild < currentSize && heapArray[leftChild].data.balıkAdı.ToLower().CompareTo(heapArray[rightChild].data.balıkAdı.ToLower()) < 0)
                {
                    largerChild = rightChild;
                }
                else
                {
                    largerChild = leftChild;

                }

                if (top.data.balıkAdı.ToLower().CompareTo(heapArray[largerChild].data.balıkAdı.ToLower()) > -1)
                {
                    break;
                }
                heapArray[index] = heapArray[largerChild];
                index = largerChild;

            }
            heapArray[index] = top;

        }

        public bool change(int index, EgeDeniziB newValue)
        {
            if (index < 0 || index >= currentSize)
            {
                return false;
            }
            EgeDeniziB oldValue = heapArray[index].data;
            heapArray[index].data = newValue;
            if (oldValue.balıkAdı.ToLower().CompareTo(newValue.balıkAdı.ToLower()) < 0)
            {
                trickleUp(index);
            }
            else
            {
                trickleDown(index);
            }

            return true;

        }
        public void displayHeap()//gerek kalmadı
        {
            Console.WriteLine();

            Console.WriteLine("heapArray: ");
            for (int m = 0; m < currentSize; m++)
            {
                if (heapArray[m] != null)
                {
                    Console.WriteLine(heapArray[m].data.balıkAdı + " ");
                }
                else
                {
                    Console.WriteLine("--");
                }
            }

                Console.WriteLine();
                int nBlanks = 32;
                int itemsPerRow = 1;
                int column = 0;
                int j = 0;
                string dots = "..................";
                Console.WriteLine(dots + dots);

                while (currentSize > 0)
                {
                    if (column == 0)
                    {
                        for (int k = 0; k < nBlanks; k++)
                        {
                            Console.WriteLine(' ');
                        }
                    }
                    Console.WriteLine(heapArray[j].data.balıkAdı);

                    if (++j == currentSize)
                    {
                        break;
                    }

                    if (++column == itemsPerRow)
                    {
                        nBlanks /= 2;
                        itemsPerRow *= 2;
                        column = 0;
                        Console.WriteLine();

                    }
                    else { 
                    for (int k = 0; k < nBlanks * 2 - 2; k++)
                        {
                            Console.WriteLine();
                        }

                    }




                }





            

            





        }
    }


    class MaxHeap
    {
        private List<EgeDeniziB> heap;

        public MaxHeap()
        {
            heap = new List<EgeDeniziB>();
        }

        public void Insert(EgeDeniziB egeDeniziB)
        {
            heap.Add(egeDeniziB);
            HeapifyUp(heap.Count - 1);
        }

        public EgeDeniziB ExtractMax()
        {
            if (heap.Count == 0)
                throw new InvalidOperationException("Heap is empty.");

            EgeDeniziB max = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            HeapifyDown(0);
            return max;
        }

        public int Count => heap.Count;

        private void HeapifyUp(int index)
        {
            while (index > 0)
            {
                int parentIndex = (index - 1) / 2;
                if (string.Compare(heap[index].balıkAdı, heap[parentIndex].balıkAdı) > 0)
                {
                    Swap(index, parentIndex);
                    index = parentIndex;
                }
                else
                {
                    break;
                }
            }
        }

        private void HeapifyDown(int index)
        {
            int lastIndex = heap.Count - 1;
            while (index <= lastIndex)
            {
                int leftChildIndex = 2 * index + 1;
                int rightChildIndex = 2 * index + 2;
                int largestIndex = index;

                if (leftChildIndex <= lastIndex && string.Compare(heap[leftChildIndex].balıkAdı, heap[largestIndex].balıkAdı) > 0)
                {
                    largestIndex = leftChildIndex;
                }

                if (rightChildIndex <= lastIndex && string.Compare(heap[rightChildIndex].balıkAdı, heap[largestIndex].balıkAdı) > 0)
                {
                    largestIndex = rightChildIndex;
                }

                if (largestIndex != index)
                {
                    Swap(index, largestIndex);
                    index = largestIndex;
                }
                else
                {
                    break;
                }
            }
        }

        private void Swap(int index1, int index2)
        {
            EgeDeniziB temp = heap[index1];
            heap[index1] = heap[index2];
            heap[index2] = temp;
        }
    }






}
