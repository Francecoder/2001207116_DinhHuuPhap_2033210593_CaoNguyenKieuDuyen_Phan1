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
            int choose = 1;
            Console.OutputEncoding = Encoding.UTF8;
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("1. Tìm kiếm phần tử bất kỳ bằng tìm kiếm nhị phân dùng đệ quy");
            Console.WriteLine("2. Tìm kiếm phần tử bất kỳ bằng tìm kiếm nhị phân KHÔNG dùng đệ quy");
            do
            {
                Console.WriteLine("Mời thầy nhập bài toán cần giải quyết trong các bài trên và bấm 0 để kết thúc");

                choose = Convert.ToInt32(Console.ReadLine());
                luachon(choose);
            } while (choose != 0);
            Console.ReadKey();

        }
        public static void luachon(int choose)
        {
            int[] arr = { 21, 12, 33, 44, 22, 66 };
            Console.WriteLine("Tất cả phần tử ban đầu của mảng là: ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($" {arr[i]}");
            }
            Console.WriteLine();
            switch (choose)
            {
                case 1:
                    int n = 6;// so luong phan tu cua mang
                    Console.WriteLine("Nhập giá trị X muốn tìm:");
                    int x = Convert.ToInt32(Console.ReadLine());
                    int result = BinarySearch(arr, 0, n - 1, x);
                    if (result == -1)
                        Console.WriteLine("Element not present");
                    else
                        Console.WriteLine("Element found at index "
                                          + result);
                    Console.ReadKey();
                    break;
                case 2:
                    Console.WriteLine("Nhập giá trị X muốn tìm:");
                    int x5 = Convert.ToInt32(Console.ReadLine());
                    int result5 = BinarySearchNoRecursive(arr, x5);

                    if (result5 == -1)
                        Console.WriteLine("Element not present");
                    else
                        Console.WriteLine("Element found at index "
                                          + result5);
                    Console.ReadKey();
                    break;

            }
        }
        //DeQuy
        static int BinarySearch(int[] arr, int l, int r, int x)//Binary Search Chi Nen Ap Dung cho Mang Tang Hoac Giam, Hon loan se ko hieu qua!
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
                    return BinarySearch(arr, l, mid - 1, x);

                // Else the element can only be present 
                // in right subarray 
                //Nam o phia sau mang(gia tri giua < gia tri can tim)
                return BinarySearch(arr, mid + 1, r, x);
            }

            // We reach here when element is not present 
            // in array 
            return -1;
        }
        //Khong de quy
        static int BinarySearchNoRecursive(int[] arr, int x)
        {
            int left = 0, right = arr.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;

                // Check if x is present at mid
                if (arr[mid] == x)
                    return mid;

                // If x greater, ignore left half
                if (arr[mid] < x)
                    left = mid + 1;

                // If x is smaller, ignore right half
                else
                    right = mid - 1;
            }

            // if we reach here, then element was not present
            return -1;
        }
    }
}

