using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_вариант_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите слово: "); string Word = Console.ReadLine();
            //Создаем массив из букв, введенного слова
            char[] CH = Word.ToCharArray();
            //Создаем Множества типа char
            HashSet<char> M = new HashSet<char>();
            //Добавляем во множество буквы, с проверкой есть ли она уже во множестве
            foreach (var item in CH){
                if(M.Contains(item) == false) { M.Add(item); }
            }
            //Выводим элементы множества
            foreach (var item in M) { 
                Console.Write("{0} ", item);
            }
        
            Console.ReadKey();
        }
    }
}
