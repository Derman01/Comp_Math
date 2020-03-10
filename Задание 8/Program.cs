using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Задание_9
{
    class Program
    {
        static void Zadanie()
        {
            int[] U = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            // __1__
            {
                BitArray A = Bits_read(new int[] { 0, 2, 3, 4, 6, 7 }, U);
                BitArray B = Bits_read(new int[] { 1, 2, 4, 5, 7, 8 }, U);
                BitArray C = Bits_read(new int[] { 1, 3, 5, 7, 9 }, U);
                BitArray Result = (B.Or(C)).Not();
                Bits_write("1. ", Result, U);

            }
            {
                BitArray B = Bits_read(new int[] { 4, 8 }, U);
                BitArray C = Bits_read(new int[] { 1, 3, 5, 7, 9 }, U);
                BitArray Result = B.And(C.Not());
                Bits_write("2. ", Result, U);
            }
            {
                BitArray A = Bits_read(new int[] { 1, 3, 6, 7, 9 }, U);
                BitArray C = Bits_read(new int[] { 2, 4, 8 }, U);
                BitArray Result = A.Or(C);
                Bits_write("3. ", Result, U);
            }


        }
        static void Main(string[] args)
        {
            G:
            Console.WriteLine("Выберите Пункт:" +
                "\n 1. Ввод множеств" +
                "\n 2. Проверка 4ого задания ");
            if (Console.ReadLine() == "1") { Read(); }
            else{Zadanie();}
            Console.ReadKey();
            Console.Clear();
            goto G;
        }
        
        static void Read()
        {
            Console.Write("Введите универсум: ");
            int[] U = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
            Console.WriteLine("Введите два множества:");
            Console.Write("M1: "); int[] M1 = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
            Console.Write("M2: "); int[] M2 = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();

            BitArray b1 = Bits_read(M1, U);
            BitArray b2 = Bits_read(M2, U);

            BitArray or = new BitArray(b1);           or.Or(b2); 
            BitArray and = new BitArray(b1);          and.And(b2);
            BitArray xor_1 = new BitArray(b1);        xor_1.And(b2.Not());
            BitArray xor_2 = new BitArray(b2.Not());  xor_2.And(b1.Not());
            BitArray not_1 = new BitArray(b1);  
            BitArray not_2 = new BitArray(b2.Not());  
            
            Bits_write("Объединение", or, U);
            Bits_write("Пересечение", and, U);
            Bits_write("Разность М1 на М2", xor_1, U);
            Bits_write("Разность М2 на М1", xor_2, U);
            Bits_write("Дополнени М1", not_1, U);
            Bits_write("Дополнение M2", not_2, U);
        }
        //  ВВОД МНОЖЕСТВА ИЗ БИНАРНОГО КОДА
        static BitArray Bits_read(int[] M1, int[] U)
        {
            
            var len = U.Length; var k = 0; var i = 0;
            BitArray bit = new BitArray(len);
            while(k < M1.Length)
            {
                if (M1[k] == U[i]) { bit[i] = true; k++; }
                i++;
            }
            return bit;
        }
        //  ВЫВОД МНОЖЕСТВА ИЗ БИНАРНОГО КОДА
        static void Bits_write(string str, BitArray bit, int[] U)
        {
            Console.Write(str + ": ");
            for (int i = 0; i < U.Length; i++)
            {
                if (bit[i] == true){
                    Console.Write(U[i] + " ");}
            }

            Console.WriteLine();
        }
    }
}
