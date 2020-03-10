using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace биты
{
    class Program
    {
        static void Main(string[] args)
        {
            
            string[] b = Console.ReadLine().Split(' ');
            BitArray bit = new BitArray(b.Length);
            for (int i = 0; i < b.Length; i++)
            {
                if (b[i] == "1") { bit[i] = true; }

            }
            foreach (bool t in bit)
                Console.Write(t ? 1 : 0);
            Console.WriteLine("\n");

            Console.ReadKey();
        }
    }
}
