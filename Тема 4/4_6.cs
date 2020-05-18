using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Дейкстри
{
    class Program
    {
        static string Protokol = "";

        static (int[], int[]) Deykstri(int[,] C, int s, int t)
        {
            //шаг 1 и 2
            var T = new int[C.GetLength(0)];
            for (int i = 0; i < T.Length; i++) T[i] = Int32.MaxValue; T[s] = 0;
            var X = new int[C.GetLength(0)];   X[s] = 1;
            var H = new int[C.GetLength(0)]; 
            //for (int i = 0; i < H.Length; i++) H[i] = -1;
            var v = s;
            Protokol += "Шаг 1:\n T = (∞,∞,∞,∞,∞,∞)\n" +
                " X = (0,0,0,0,0,0)\n" +
                "Шаг2:\n" +
                $" H[s] = H[{s + 1}] = 0; T[s] = T[{s + 1}] = 0\n" +
                $" X[s] = H[{s + 1}] = 1; v = {v + 1}\n" +
                $" T = ({Mas_protokol(T)}) \n X = ({Mas_protokol(X)})\n H = ({Mas_protokol(H)})\n";
                
            while (true)
            {//шаг 3 
                Protokol += "Шаг3: \n"+
                    " Г(v) = {v?,..}\n";
                for (int u = 0; u < C.GetLength(0); u++)
                    if (X[u] == 0 && T[u] > T[v] + C[v, u] && v != u && C[v, u] != Int32.MaxValue)
                    {
                        Protokol += $"\tu = {u + 1}\n\t" +
                            $"\tx[{u + 1}] = 0 & T[{u + 1}] > T[{v + 1}] + C[{v + 1},{u + 1}] = {T[v]} + {C[v,u]} = {T[v] + C[v, u]}\n" +
                            $"\t\t=> T[{u + 1}] = T[{v + 1}] + C[{v + 1},{u + 1}] = {T[v] + C[v, u]}; H[{u + 1}] = {v + 1}\n" ;
                        (T[u], H[u]) = (T[v] + C[v, u], v + 1);
                    }
                Protokol += $" T = ({Mas_protokol(T)}) \n X = ({Mas_protokol(X)})\n H = ({Mas_protokol(H)})\n";
                //шаг 4
                Protokol +="Шаг 4:\n" +
                    "m = ∞, v = 0;\n";
                var m = Int32.MaxValue; v = 0;
                for (int u = 0; u < C.GetLength(0); u++)
                    if (X[u] == 0 && T[u] < m)
                    {
                        Protokol += $"\tu = {u + 1}\n\t\t X[{u + 1}] = 0 & T[{u + 1}] < {m}\n" +
                            $"\t\t\t=>v = {u + 1}, m = T[{u + 1}] = {T[u]}\n";
                        (v, m) = (u, T[u]);
                        
                    }
                if (v == -1) return (null, null);
                if (v == t)  return (T, H);
                X[v] = 1;
                Protokol += $"v≠0; v≠{t + 1}\n";
                Protokol += $"X[{v + 1}] = 1\n";
                Protokol += $" T = ({Mas_protokol(T)}) \n X = ({Mas_protokol(X)})\n H = ({Mas_protokol(H)})\n";
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
            Protokol += $"ИЗ вершины v{V[0]} в v{V[1]}\n" + new string('_', 100) + "\n";
            var (T, H) = Deykstri(matrix, V[0] - 1, V[1] - 1);
            Protokol += $"v = t = {V[1] + 1}\n";
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

            Protokol += $"T = ({Mas_protokol(T)}) \nH = ({Mas_protokol(H)})\n";
            var f = new StreamWriter("Протокол.txt");
            f.WriteLine(Protokol);
            f.Close();
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
        static string Mas_protokol(int[] mas)
        {
            string k = "";
            foreach (var i in mas)
            {
                if (i == Int32.MaxValue) k += "∞, ";
                else k +=$"{i}, ";
            }
            return k;
        }
    }
}
