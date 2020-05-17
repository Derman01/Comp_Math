 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Алгоритм_флойда
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ввести самому матрицу?\n 1.ДА\t 2. НЕТ");
            var matrix = (Console.ReadLine() == "2"? R: Matrix_Read());
            Console.Clear();
            Matrix_Write(matrix);
            (var T, var H) = Floid(matrix);

            Console.WriteLine("Матрица длин кратчайших путей:");
            Matrix_Write(T);
            Console.WriteLine("Матрица кратчайших путей:");
            Matrix_Write(H);

            Console.WriteLine("Найти кратчайший путь соединяющий две вершины:");
            int[] V = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
            var way = Shortcut(V[0], V[1], H);
            Console.WriteLine($"Крайтчаший путь от вершины v{V[0]} к v{V[1]}:");
            
            foreach (var i in way)
                Console.Write($"v{i + 1} ");

            Console.ReadKey();
        }

        static (int[,], int[,]) Floid(int[,] C)
        {
            var T = new int[C.GetLength(0), C.GetLength(1)];
            var H = new int[C.GetLength(0), C.GetLength(1)];

            for (int i = 0; i < C.GetLength(0); i++) //шаг 1
                for (int j = 0; j < C.GetLength(1); j++) {
                    T[i, j] = C[i, j];
                    H[i, j] = C[i, j] == Int32.MaxValue ? 0 : j + 1; 
                }
            Matrix_Write(H);
            for (int i = 0; i < C.GetLength(0); i++) {

                for (int j = 0; j < C.GetLength(1); j++)
                    for (int k = 0; k < C.GetLength(0); k++)
                        if (i != j && T[j, i] != Int32.MaxValue && i != k && T[i, k] != Int32.MaxValue && (T[j, k] == Int32.MaxValue || T[j, k] > T[j, i] + T[i, k]))
                        {
                            H[j, k] = H[j, i];
                            T[j, k] = T[j, i] + T[i, k];
                        }
                
            }


            return (T, H);
        }
        static List<int> Shortcut(int i, int j, int[,] H)
        {
            var w = --i; j--;
            var shortcut = new List<int>();
            shortcut.Add(w);
            while (w != j)
                shortcut.Add(w = H[w, j] - 1);
            return shortcut;
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
        static void Matrix_Write(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write(matrix[i,j] == Int32.MaxValue ? $"- " : $"{matrix[i, j]} ");
                Console.WriteLine();
            }
        }
        static int[,] R = new int[,]
        {
           { 0, 11, Int32.MaxValue,5,5,2},
           {Int32.MaxValue, 0, Int32.MaxValue, Int32.MaxValue, Int32.MaxValue, Int32.MaxValue,},
           {Int32.MaxValue, 2, 0, Int32.MaxValue, Int32.MaxValue, Int32.MaxValue},
           {Int32.MaxValue, Int32.MaxValue, 3, 0, Int32.MaxValue, Int32.MaxValue},
           {Int32.MaxValue, Int32.MaxValue, 2, Int32.MaxValue, 0, Int32.MaxValue},
           {Int32.MaxValue, Int32.MaxValue, Int32.MaxValue, 1, 3, 0}
        };
    }
}
