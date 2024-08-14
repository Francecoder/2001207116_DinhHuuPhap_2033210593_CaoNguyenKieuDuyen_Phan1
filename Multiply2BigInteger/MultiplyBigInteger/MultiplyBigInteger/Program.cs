using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiplyBigInteger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region
            // NHAN 2 SO NGUYEN LON
            Console.WriteLine("Nhap vao so nguyen lon thu nhat: ");
            List<int> a = ReadBigInteger();
            Console.WriteLine("Nhap vao so nguyen lon thu hai: ");
            List<int> b = ReadBigInteger();
            //S int n = int.Parse(Console.ReadLine());
            // Nhân số lớn a và số nhỏ n
            //S PrintBigInteger(Multiply(a, IntToVi(n)));
            Console.WriteLine();
            // Nhân hai số lớn a và b
            Console.WriteLine("Ket qua:");
            PrintBigInteger(Multiply(a, b));
            Console.ReadKey();
            #endregion

        }
        #region
        // Nhập số lớn dưới dạng chuỗi và chuyển thành danh sách các chữ số
        //Link tham khao: https://viblo.asia/p/xu-ly-so-nguyen-lon-phan-2-cac-phep-toan-nhan-Qpmle1Yolrd
        public static List<int> ReadBigInteger()
        {
            string s = Console.ReadLine();
            List<int> a = new List<int>();

            foreach (char c in s)
                a.Add(c - '0');

            return a;
        }

        // In số lớn từ danh sách các chữ số
        public static void PrintBigInteger(List<int> a)
        {
            foreach (int d in a)
                Console.Write(d);
        }

        // Xóa các số 0 vô nghĩa ở đầu
        public static void DelZero(List<int> a)
        {
            a.Reverse();

            while (a.Count >= 2 && a[a.Count - 1] == 0)
                a.RemoveAt(a.Count - 1);

            a.Reverse();
        }

        // Chuyển số nguyên thành danh sách các chữ số
        public static List<int> IntToVi(int n)
        {
            List<int> res = new List<int>();
            if (n == 0)
            {
                res.Add(n);
                return res;
            }

            while (n > 0)
            {
                res.Add(n % 10);
                n /= 10;
            }

            return res;
        }

        // Nhân hai số lớn
        public static List<int> Multiply(List<int> a, List<int> b)
        {
            a.Reverse();
            b.Reverse();

            List<int> c = new List<int>(new int[a.Count + b.Count + 1]);

            for (int i = 0; i < a.Count; ++i)
                for (int j = 0; j < b.Count; ++j)
                {
                    c[i + j] += (a[i] * b[j]);
                    c[i + j + 1] += (c[i + j] / 10);
                    c[i + j] %= 10;
                }

            c.Add(0);
            for (int i = 0; i < c.Count - 1; ++i)
            {
                c[i + 1] += (c[i] / 10);
                c[i] %= 10;
            }

            c.Reverse();
            DelZero(c);

            return c;
        }

        #endregion

    }
}
