using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_9
{
    class Program
    {
        
        static HashSet<(string x1, string x2)> Corteg_Read()//Создание пар отношения
        {
            Console.Write("Введите пары отношения: \n");
            HashSet<(string x1, string x2)> corteg = new HashSet<(string, string)>(0);

            int i = 1; // счетчик
            Console.Write($"{i}. "); string[] A = Console.ReadLine().Split(' ');
            if (A.Length != 2) return corteg;
            while (1 == 1)
            {
                corteg.Add((A[0], A[1])); 
                i++; // увеличиваем счетчик
                Console.Write($"{i}. "); A = Console.ReadLine().Split(' '); //снова вводим элементы
                if (A.Length != 2) return corteg;
            }


        }
        
        static string[][] Ekv(string[] M, HashSet<(string x1,string x2)> corteg)
        {
            var B = new string[1][];
            B[0] = new string[1];
            foreach (var a in M)
            {
                var was = false;
                for (int i = 0; i < B.Length; i++)
                    if (corteg.Contains((B[i][0], a)))
                    {
                        Array.Resize(ref B[i], B[i].Length + 1);
                        B[i][B[i].Length - 1] = a;
                        was = true;
                        break;
                    }
                if (!was)
                {
                    Array.Resize(ref B, B.Length + 1);
                    Array.Resize(ref B[B.Length - 1], 1);
                    B[B.Length - 1][0] = a;
                }
            }
            return B;
        }
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black; Console.Clear();

            Console.WriteLine("1. Ввод пар отношения эквивалентности \n2. Проверка 2ого пунка");
            if (Console.ReadLine() == "1") Read();
            else Zadanie_2();
        }
        static void Read()
        {
            

            Console.WriteLine("Введите множество: ");
            var M = Console.ReadLine().Split(' ');
            var B = Ekv(M, Corteg_Read());
            foreach (var i in B)
            {
                foreach (var j in i)
                    Console.Write(j + " ");
                Console.WriteLine();
            }
            Console.ReadKey();
        }
        static void Zadanie_2()
        {
            Console.Write("Получить разбиение множества натуральных чисел,\n" +
                "непревосходящих "); var N = int.Parse(Console.ReadLine());
            Console.Write("По отношению <иметь одинаковый остаток от деления на ");
            int del = int.Parse(Console.ReadLine());

            var A = new int[0];
            var corteg = new HashSet<(string, string)>();

            for (int i = 1; i <= N; i++) {
                Array.Resize(ref A, i);
                A[i - 1] = i;}

            for (int i = 0; i < A.Length; i++)
                for (int j = 0; j < A.Length; j++)
                    if (A[i] % del == A[j] % del)
                        corteg.Add( ( Convert.ToString(A[i]), Convert.ToString(A[j])) ); //создание кортежа
            var A_2 = A.Select(s => Convert.ToString(s)).ToArray();
            var B = Ekv(A_2, corteg);
            foreach (var i in B)
            {
                foreach (var j in i)
                    Console.Write(j + " ");
                Console.WriteLine();
            }
            Console.ReadKey();


        }
    }
}
