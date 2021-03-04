using System;
using System.Linq;

namespace Class_Work_2
{
    class Program
    {
        static void Rand(int [] arr,int left = 0, int rigth = 0)
        {
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(left,rigth);
            }
        }
        static void PrintArray(int[] arr)
        {
            foreach (var item in arr)
            {
                Console.Write($"{item}\t");
            }
        }
        static void  Main(string[] args)
        { 
            //Tast 1
            int[] arr = new int[]{2,1,-4,-55,-7,100,10 };
            int[] arrNegative = Array.FindAll(arr, (e) => { return e < 0; });
            int[] arrPositive = Array.FindAll(arr, (e) => { return e > 0; });
            arrNegative.CopyTo(arr,0);
            arrPositive.CopyTo(arr, arrNegative.Length);
            PrintArray(arr);
            //Task2
            Console.Write("Enter number for search : ");
            int num = int.Parse(Console.ReadLine());
            int [] arrNum = new int[10];
            Rand(arrNum);
            Console.WriteLine($"Count {num} in arr  was rand { arr.Count(x => x == num)}");
            //Task 3
            int max = arr.Max();
            int min = arr.Min();
            int  iMax =Array.IndexOf(arr, max);
            int iMin =Array.IndexOf(arr, min);
            int[] arrTemp = new int[arr.Length];
            if(iMax > iMin)
            {
                Array.Copy(arr, iMin, arrTemp, 0, iMax - iMin);
            }else if(iMax < iMin)
            {
                Array.Copy(arr, iMax, arrTemp, 0,iMin -  iMax);
            }
            else
            {
                Console.WriteLine("Sum = 0");
            }
            PrintArray(arrTemp);
            Console.WriteLine($"Sum  = {arrTemp.Sum()}");
        }
    }
}
