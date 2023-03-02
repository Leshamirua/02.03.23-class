using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._03._23_class
{
    internal class Program
    {
        static public int[] GetRandomHundred()
        {
            int[] ints= new int[100];
            Random random = new Random();
            for (int i = 0; i <ints.Length ; i++)
                    ints[i] = random.Next(0, 1000);
            return ints;
        }
        private static bool IsPerfectSquare(int num)
        {
            int sq = (int)Math.Sqrt(num);
            return sq * sq == num;
        }

        public static int[] fibonacciArrayNum(int[] arr)
        {
            int[] res = new int[arr.Length];
            for (int i = 0; i < arr.Length; i++)
            {
                res[i] = arr[i];
            }
            int count = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (IsPerfectSquare(arr[i] * arr[i] + 4) || IsPerfectSquare(arr[i] * arr[i] - 4))
                {
                    count++;
                }
                else res[i] = -1;
            }
            int[] _res = new int[count];
            foreach (int i in _res)
            {
                foreach (int j in res)
                {
                    if (arr[j] == -1) continue;
                    _res[i] = res[j];
                }
            }
            return _res;
        }
        public static int[] primeArrayNum(int[] array)
        {
            int count = 0;
            foreach (var i in array)
            {
                if (i % 2 != 0) count++;
            }
            int[] res = new int[count];
            count = 0;
            foreach (var i in array)
            {
                if (i == 1) continue;
                if (i == 2) res[count] = i;

                var limit = Math.Ceiling(Math.Sqrt(i));

                for (int a = 2; a <= limit; ++a)
                    if (a % a == 0)
                        continue;
                res[count] = i;
            }
            return res;
        }
        static void Intofile(int[] array, string filename)
        {
            try
            {
                StreamWriter file = new StreamWriter(filename, true);
                int j = 0;
                for (int i = 0; i < array.Length; i++)
                {
                    file.WriteLine(array[i]);
                }
                file.Close();
                Console.WriteLine("File written");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        static void Main(string[] args)
        {
            int[] ints= GetRandomHundred();
            foreach (var a in ints)
            {
                Console.Write("{0} ", a);
            }
            Console.WriteLine();
            Console.WriteLine();
            int[] ints2 = primeArrayNum(ints);
            foreach (var a in ints2)
            {
                Console.Write("{0} ", a);
            }

            Intofile(ints2, "Fibonacci.txt");
            int[] ints3 = primeArrayNum(ints);
            Intofile(ints3, "Prime.txt");
        }
    }
}
