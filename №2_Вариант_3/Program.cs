using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_Вариант_3
{
    class Program
    {
        //1 - 14  .. 0:50
        // 0 - 20 ..
        //Создание массива по бинарному коду
        static void BinaryCode(int stepen, string[] A)
        {
            int value = 1;
            
            for (int i = 1; i <= stepen; i++){
                value *= 2;}
                        
            for (int i = 0; i < value - 1; i++) {
                string BinaryCode = (Convert.ToString(i, 2));
                double len = stepen - BinaryCode.Length;
                for (int j = 0; j < len; j++){
                    BinaryCode = "0" + BinaryCode;}
                for (int j = 0; j < BinaryCode.Length; j++)
                { //проходим по каждому элементу из бинарного кода. 
                    if (BinaryCode[j] == '1')
                    {// 0 - ничего; 1 - вывод соответствующего числа
                        Console.Write($"{A[j]} ");
                    }
                }
                Console.WriteLine();
            };
        }
           
        
        static void Main(string[] args)
        {
            
            Console.WriteLine("Введите множество:");
            string[] A = Console.ReadLine().Split(' ');
            var N = A.Length; //количество элементов
            BinaryCode(N, A);

                

            Console.ReadKey();            
        }
    }
}
