using System;
using System.Collections.Generic;
using System.Linq;

namespace Алгоритм_прима
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ввести самому матрицу?\n 1.ДА\t 2. НЕТ");
            var matrix = (Console.ReadLine() == "2" ? R : Matrix_Read());
            Console.Clear();
            Matrix_Write(matrix);

            var T = Prima(matrix);
            Console.WriteLine();
            foreach (var i in T)
                Console.Write(i + " ");
            Console.ReadKey();
        }

        static List<(int, int)> Prima(int[,] C)
        {
            var V = new List<int>(); for (var i = 0; i < C.GetLength(0); i++) V.Add(i);
            var u = 0;
            var S = new List<int>() {u}; //вершины кратчайщий остров
            var T = new List<(int, int)>(0); //ребра кратчайшего отсрова
            var alfa = new int[C.GetLength(0)];
            var beta = new int[C.GetLength(0)];
            //шаг 2
            foreach (var v in WithOut(V, new List<int>(){u}))
            {
                var g = G(C, u);
                (alfa[v], beta[v]) = g.Contains(v) ? (u, C[u, v]) : (0, Int32.MaxValue);
            }
            //шаг 3
            for (int i = 0; i < C.GetLength(0) - 1; i++)
            {
                var x = Int32.MaxValue; int w = 0;
                //шаг 3.2
                foreach (var v in WithOut(V, S)) 
                    if (beta[v] < x)
                        (w, x) = (v , beta[v]);
                //шаг 3.3
                S.Add(w); T.Add((alfa[w], w));
                //шаг 3.4
                foreach (var v in G(C, w))
                    if (!S.Contains(v) && beta[v] > C[v, w])
                        (alfa[v], beta[v]) = (w, C[v, w]);
            }
            return (T);
        }
        static List<int> WithOut(List<int> A, List<int> B) {
            return A.Except(B).ToList();
        }
        static List<int> G(int[,] C, int u)
        {
            var smeg = new List<int>(0);
            for (int i = 0; i < C.GetLength(0); i++)
                if (C[u, i] != 0 && C[u, i] != Int32.MaxValue)
                    smeg.Add(i);
            return smeg;
        }
       
        static void Matrix_Write(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write(matrix[i, j] == Int32.MaxValue ? $"- " : $"{matrix[i, j]} ");
                Console.WriteLine();
            }
        }
        static int[,] Matrix_Read()
        {
            Console.Write("Матрица порядка n = "); int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите матрицу весов");
            var matrix = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                var str = Console.ReadLine().Split(' ');
                for (int j = 0; j < str.Length; j++)
                    matrix[i, j] = (str[j] == "-" ? Int32.MaxValue : int.Parse(str[j]));
            }
            return matrix;
        }
        static int[,] R = new int[,]
        {
           { 0, 2, 3, 4 , Int32.MaxValue, Int32.MaxValue},
           {2, 0, Int32.MaxValue, 3, Int32.MaxValue, Int32.MaxValue},
           {3, Int32.MaxValue, 0, 2, 4, 5},
           {4, 3, 2, 0, Int32.MaxValue, 4},
           {Int32.MaxValue, Int32.MaxValue, 4, Int32.MaxValue, 0, 2},
           {Int32.MaxValue, Int32.MaxValue, 5, 4, 2, 0}
        };
    }
}
