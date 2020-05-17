using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Дейкстри
{
    class Program
    {

        static (int[], int[]) Deykstri(int[,] C, int s, int t)
        {
            //шаг 1 и 2
            var T = new int[C.GetLength(0)];
            for (int i = 0; i < T.Length; i++) T[i] = Int32.MaxValue; T[s] = 0;
            var X = new int[C.GetLength(0)];   X[s] = 1;
            var H = new int[C.GetLength(0)]; 
            //for (int i = 0; i < H.Length; i++) H[i] = -1;
            var v = s;

            while (true)
            {//шаг 3 
                for (int u = 0; u < C.GetLength(0); u++)
                    if (X[u] == 0 && T[u] > T[v] + C[v, u] && v != u && C[v, u] != Int32.MaxValue)
                    {
                        (T[u], H[u]) = (T[v] + C[v, u], v + 1);
                    }
                
                //шаг 4
                var m = Int32.MaxValue; v = 0;
                for (int u = 0; u < C.GetLength(0); u++)
                    if (X[u] == 0 && T[u] < m)
                        (v, m) = (u, T[u]);
                if (v == -1) return (null, null);
                if (v == t) return (T, H);
                X[v] = 1;
            }
           
           
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Ввести самому матрицу?\n 1.ДА\t 2. НЕТ");
            var matrix = (Console.ReadLine() == "2" ? R : Matrix_Read());
            Console.Clear();
            Matrix_Write(matrix);
            Console.WriteLine("из какой вершины в какую?");
            var V = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
            var (T, H) = Deykstri(matrix, V[0] - 1, V[1] - 1);
            if (T != null)
            {
                Massiv_Write("Матрица T", T);
                Massiv_Write("Матрица H", H);
            }
            else Console.WriteLine("Нет пути");
            var way = Shotcut(H, V[0] - 1, V[1] - 1);
            Console.WriteLine($"Кратчайший путь из v{V[0]} в v{V[1]}");
            foreach (var i in way)
                Console.Write($"v{i} ");
            Console.ReadKey();
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
                    Console.Write(matrix[i, j] == Int32.MaxValue ? $"- " : $"{matrix[i, j]} ");
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
        static void Massiv_Write(string name, int[] M)
        {
            Console.WriteLine( name);
            foreach (var i in M)
                Console.Write($"{i} ");
            Console.WriteLine();
        }
        static int[] Shotcut(int[] H, int s, int t)
        {
            var cut = new List<int>();
            cut.Add(t + 1);
            while (s != t)
            {
                cut.Add(H[t]);
                t = H[t] - 1;
            }
            cut.Reverse();
            int[] A = cut.ToArray();
            return A;
        }
    }
}
