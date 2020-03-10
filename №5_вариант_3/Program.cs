using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_вариант_3
{
    class Program
    {
        static void Write(IEnumerable<int> M)
        {
            foreach (var x in M){
                Console.Write($"{x} ");
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
        G:
            Console.WriteLine("Выберите Пункт:" +
                "\n 1. Ввод множеств" +
                "\n 2. Проверка 4ого задания ");
            if (Console.ReadLine() == "1") { Read(); }
            else { Zadanie(); }
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


            IEnumerable<int> obedinenie = M1.Union(M2);
            IEnumerable<int> peresechenie = M1.Intersect(M2);
            IEnumerable<int> raznost1 = M1.Except(M2);
            IEnumerable<int> raznost2 = M2.Except(M1);
            IEnumerable<int> dopolenie_1 = U.Except(M1);
            IEnumerable<int> dopolenie_2 = U.Except(M2);

            Console.Write("\nОбъединение: "); Write(obedinenie);
            Console.Write("Пересечение: "); Write(peresechenie);
            Console.Write("M1 / M2: "); Write(raznost1);
            Console.Write("M2 / M1: "); Write(raznost2);
            Console.Write("Дополнение M1: "); Write(dopolenie_1);
            Console.Write("Дополнение M2: "); Write(dopolenie_2);

            
        }
        static void Zadanie()
        {
            int[] U = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            //пункт 1
            {
                int[] A = { 0, 2, 3, 4, 6, 7 };
                int[] B = { 1, 2, 4, 5, 7, 8 };
                int[] C = { 1, 3, 5, 7, 9 };
                IEnumerable<int> Result = ((A.Union(U.Except(B))).Union(C)).Except(B.Union(C));
                IEnumerable<int> Result_2 = (U.Except(B)).Intersect(U.Except(C));
                Console.Write("\n1.1.  "); Write(Result);
                Console.Write("1.2.  "); Write(Result_2);
            }
            //пункт 2
            {
                int[] B = { 4, 8};
                int[] C = { 1, 3, 5, 7, 9 };
                IEnumerable<int> Result = U.Except(((U.Except(B)).Intersect(C)).Union((U.Except(B)).Intersect(U.Except(C))).Union(B.Intersect(C)));
                IEnumerable<int> Result_2 = B.Intersect(U.Except(C));
                Console.Write("\n2.1.  "); Write(Result);
                Console.Write("2.2.  "); Write(Result_2);
            }
            //пунк 3
            {
                
                int[] A = { 1, 3, 6, 7, 9 };
                int[] C = { 2, 4, 8 };
                IEnumerable<int> Result = (A.Intersect(C)).Union(A).Intersect(U.Except(C)).Union((U.Except(A)).Intersect(C));
                IEnumerable<int> Result_2 = (A).Union(C);
                Console.Write("\n3.1.  "); Write(Result);
                Console.Write("3.2.  "); Write(Result_2);
                
            }


        }
    }
}
