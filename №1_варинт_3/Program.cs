    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_варинт_3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] A = new int[0];
            // {x - целые числа, кратные 3, в промежутке от -11 до 7}

            for (int i = -11; i <= 7; i++){
                if (i % 3 == 0){    
                    Array.Resize(ref A, A.Length + 1); //увеличиваем массив на 1 элемент
                    A[A.Length - 1] = i; //заполняем последний элемент массива
                }
            }

            foreach (var x in A) {
                Console.Write("{0} ", x);
            }
            Console.WriteLine("\n Мощность множества: {0}", A.Length);
            Console.ReadKey();
        }
    }
}
