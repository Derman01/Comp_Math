using System;

namespace _4_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ввести самому матрицу?\n 1.ДА\t 2. НЕТ");
            var matrix = (Console.ReadLine() == "2" ? R : Matrix_Read());
            Console.Clear();
            Matrix_Write("Матрицы весов", matrix);
            var T = Ostrov(matrix);
            foreach (var i in T)
                Console.Write(i != Int32.MaxValue ? i + " ": "- ");

            Console.ReadKey();

        }
        static int[] Ostrov(int[,] C)
        {
            var T = new int[C.GetLength(0)];
            for (var i = 0; i < C.GetLength(0); i++)
                T[i] = C[0, i];

            for (var i = 1; i < C.GetLength(0); i++)
                for (var j = 0; j < C.GetLength(1); j++)
                    if (i != j && C[j, i] != Int32.MaxValue)
                        T[i] = (T[i] > T[j] + C[j, i]) && (T[j]!=Int32.MaxValue)  ? T[j] + C[j, i]: T[i];
            return T;
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
           { 0, 2, 5, 5, Int32.MaxValue, 11},
           {Int32.MaxValue, 0, 3, 1, Int32.MaxValue, Int32.MaxValue },
           {Int32.MaxValue, Int32.MaxValue, 0, Int32.MaxValue, 2, Int32.MaxValue},
           {Int32.MaxValue, Int32.MaxValue, Int32.MaxValue, 0, 3, Int32.MaxValue},
           {Int32.MaxValue, Int32.MaxValue, Int32.MaxValue, Int32.MaxValue, 0, 2},
           {Int32.MaxValue, Int32.MaxValue, Int32.MaxValue, Int32.MaxValue, Int32.MaxValue, 0}
        };
        static void Matrix_Write(string name, int[,] matrix)
        {
            Console.WriteLine(name);
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                    Console.Write(matrix[i, j] == Int32.MaxValue ? $"- " : $"{matrix[i, j]} ");
                Console.WriteLine();
            }
        }
    }
}
