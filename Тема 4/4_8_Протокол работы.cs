using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Алгоритм_прима
{
    class Program
    {
        public static string Str = "";
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
            Str +=pic("T = ", T);
            var f = new StreamWriter("text.txt");
            f.WriteLine(Str);
            f.Close();
        }

        static List<(int, int)> Prima(int[,] C)
        {
            
            var V = new List<int>(); for (var i = 0; i < C.GetLength(0); i++) V.Add(i);
            var u = 0;
            var S = new List<int>() {u}; //вершины кратчайщий остров
            var T = new List<(int, int)>(0); //ребра кратчайшего отсрова
            var alfa = new int[C.GetLength(0)];
            var beta = new int[C.GetLength(0)];
            Str +=pic("s = {", S);
            Str += pic("T = ", T);
            //шаг 2
            Str += pic($"V / {u} = ",WithOut(V, new List<int>() { u }));
            var g = G(C, u);
            Str += pic($"Г({u}) = ", g);
            foreach (var v in WithOut(V, new List<int>(){u}))
            {
                Str += $"v = {v}\n";
                if (g.Contains(v))
                {
                    Str += $"\t{v} принадлежит Г({u})\n";
                    (alfa[v], beta[v]) = (u, C[u, v]);
                    Str += $"\t=> a[{v}] = {u}\n";
                    Str += $"   \tв[{v}] = C[{u},{v}] = {C[u, v]}\n";

                }
                else
                {
                    Str += $"\t{v} НЕпринадлежит Г({u})\n";
                    (alfa[v], beta[v]) = (0, Int32.MaxValue);
                    Str += $"\t=> a[{v}] = 0\n";
                    Str += $"   \tв[{v}] = бесконечноть\n";
                }
            }
            Str +="__________\n Итог:\n";
            Str += pic("a = ", alfa);
            Str += pic("b = ", beta);
            Str += "ШАГ 3 :\n";
            //шаг 3
            for (int i = 0; i < C.GetLength(0) - 1; i++)
            {
                Str += $"i = {i}\n";
                Str += pic($"V / S = ", WithOut(V, new List<int>() { u }));
                var x = Int32.MaxValue; int w = 0;
                //шаг 3.2
                foreach (var v in WithOut(V, S))
                    if (beta[v] < x)
                    {
                        Str +=$"\tb[{v}] = {beta[v]} < x = {x}\n";
                        (w, x) = (v, beta[v]);
                        Str += $"\t=> w = {v}\n";
                        Str += $"..\t x = b[{v}] = {beta[v]}\n";
                    }
                //шаг 3.3
                S.Add(w); T.Add((alfa[w], w));
                Str += pic("S = S U w =", S);
                Str += pic("T = T U (a[w], w) =", T);
                //шаг 3.4
                Str += pic($"Г(w) = Г({w}) = ", G(C, w));
                foreach (var v in G(C, w))
                    if (!S.Contains(v) && beta[v] > C[v, w])
                    {
                        Str += $"{v} НЕпринадлижит S && b[{v}] = {beta[v]} > C[{v},{w}] = {C[v,w]}\n";
                        (alfa[v], beta[v]) = (w, C[v, w]);
                        Str += $"\t=> a[{v}] = w = {w}\n";
                        Str += $"\t.. b[{v}] = C[{v},{w}] = {C[v, w]}\n";
                    }
                Str += "__________\n Итог:\n";
                Str += pic("a = ", alfa);
                Str += pic("b = ", beta);
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

        static string pic(string name, List<int> A)
        {
            string F = name + " ";
            foreach (var i in A)
                F +=$"{i} ";
            F += "\n";
            return F;
        }
        static string pic(string name, int[] A)
        {
            string F = name + " ";
            foreach (var i in A)
                F += $"{i} ";
            F += "\n";
            return F;
        }
        static string pic(string name, List<(int, int)> A)
        {
            string F = name + " ";
            foreach (var i in A)
                F += $"{i} ";
            F += "\n";
            return F;
        }
    }
}
