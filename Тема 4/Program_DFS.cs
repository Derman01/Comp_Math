using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DFS
{
    class Program_DFS
    {
        static Dictionary<string, string[]> spisok; //список смежности
        static string[] massiv; 
        static Dictionary<string, int> dfs; //список обхода
        

        static void Main(string[] args)
        {       
            Console.WriteLine("Введите массив:");
            massiv = Console.ReadLine().Split(' ');
            Console.WriteLine("Введите список смежности:");
            create_spisok();

            DFS();
            Console.WriteLine("Список обхода:");
            foreach(var i in dfs)
                Console.WriteLine($"{i.Key} : {i.Value}");

            Console.ReadKey();
        }
        static void create_spisok() //создание списка
        {
            spisok = new Dictionary<string, string[]>();
            dfs = new Dictionary<string, int>();
            for (int i = 0; i < massiv.Length; i++)
            {
                Console.Write($"{massiv[i]} : ");
                spisok.Add(massiv[i], Console.ReadLine().Split(' ')); //добавляем вершину и смежные ей вершины
                dfs.Add(massiv[i], 0); // добавляем вершину в списко обхода
            }
        }

        static int num = 1;
        static void DFS( )
        {
            foreach (var i in spisok)
                if (dfs[i.Key]== 0)
                    DFS(i.Key, i.Value );
        }
        static void DFS(string key, string[] value)
        {
            if (dfs[key] == 0)
            {
                dfs[key] = num++;
                foreach (var i in value)
                    DFS(i, spisok[i]);
            }
            
        }
    }
}
