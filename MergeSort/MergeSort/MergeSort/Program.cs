using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeSort
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<int> unsorted = new List<int>();// Khoi tao mang va dat ten la chua sap xep de phan biet
            List<int> sorted;//Khoi tao mang sap xep de sap xep xong thi do vao mang nay

            Random random = new Random();
            Console.WriteLine("Sap xep tron (Merge Sort) trong C#:");
            Console.WriteLine("------------------------------------");
            Console.WriteLine("In mang ban dau:");
            for (int i = 0; i < 10; i++)
            {
                unsorted.Add(random.Next(0, 100));
                Console.Write(unsorted[i] + " ");
            }
            Console.WriteLine();
            sorted = MergeSort(unsorted);

            Console.WriteLine("\nIn mang da qua sap xep: ");
            foreach (int x in sorted)
            {
                Console.Write(x + " ");
            }
            Console.Write("\n");

            Console.ReadKey();

        }

        private static List<int> MergeSort(List<int> unsorted)
        {
            if (unsorted.Count <= 1)
                return unsorted;

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            int middle = unsorted.Count / 2;
            for (int i = 0; i < middle; i++)  //chia danh sach chua qua sap xep  
            {
                left.Add(unsorted[i]);
            }
            for (int i = middle; i < unsorted.Count; i++)
            {
                right.Add(unsorted[i]);
            }

            left = MergeSort(left);
            right = MergeSort(right);
            return Merge(left, right);
        }

        private static List<int> Merge(List<int> left, List<int> right)
        {
            List<int> result = new List<int>();

            while (left.Count > 0 || right.Count > 0)
            {
                if (left.Count > 0 && right.Count > 0)
                {
                    if (left.First() <= right.First())  //so sanh hai phan tu dau tien  
                    {                                   //de xem phan tu nao nho hon
                        result.Add(left.First());
                        left.Remove(left.First());      //phan con lai cua list, ngoai tru  
                    }                                   //phan tu dau tien
                    else
                    {
                        result.Add(right.First());
                        right.Remove(right.First());
                    }
                }
                else if (left.Count > 0)
                {
                    result.Add(left.First());
                    left.Remove(left.First());
                }
                else if (right.Count > 0)
                {
                    result.Add(right.First());
                    right.Remove(right.First());
                }
            }
            return result;
        }
    }
}
