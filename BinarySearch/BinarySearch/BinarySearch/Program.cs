using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearch
{
    internal class Program
    {
        static void Main(string[] args)
        {

           int[] arr = { 2, 3, 4, 10, 40,50,60 };
           int n = arr.Length;
           int x = 40;
            Console.WriteLine("Cac phan tu ban dau cua mang la :");
            for (int i=0;i<n;i++)
            {
                Console.Write(arr[i]);
                Console.Write("\t");
            }
           Console.WriteLine("");
           int result = binarySearch(arr, 0, n - 1, x);

           if (result == -1)
                Console.WriteLine("Phan tu {0} khong ton tai trong mang", x);
            else
                Console.WriteLine("Phan tu {0} duoc tim thay o vi tri {1} cua mang", x, result);

            Console.ReadKey();


        }
        static int binarySearch(int[] arr, int l, int r, int x)//Binary Search Chi Nen Ap Dung cho Mang Tang Hoac Giam, Hon loan se ko hieu qua!
        {
            if (r >= l)
            {
                int mid = l + (r - l) / 2;//Khoi tao gia tri phan doi Mang bang cach lay 0 + n-1(so luong phan tu tru di 1) /2 (Mang co 5 phan tu nen gia tri mid la 2)

                // If the element is present at the 
                // middle itself 
                if (arr[mid] == x)//Day la vi tri giua mang-> neu nam o day la qua may man
                    return mid;

                // If element is smaller than mid, then 
                // it can only be present in left subarray 
                if (arr[mid] > x)// Nam o phia truoc mang( gia tri giua>gia tri can tim)
                    return binarySearch(arr, l, mid - 1, x);

                // Else the element can only be present 
                // in right subarray 
                //Nam o phia sau mang(gia tri giua < gia tri can tim)
                return binarySearch(arr, mid + 1, r, x);
            }

            // We reach here when element is not present 
            // in array 
            return -1;
        }
    }
}

