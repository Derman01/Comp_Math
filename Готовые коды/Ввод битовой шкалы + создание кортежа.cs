
// Ввод булевой матрицы 
 static bool[,] Read_Matrix(int len)
        {
            bool[,] matrix = new bool[len, len];
            for (int i = 0; i < len; i++)
            {
                string[] write = Console.ReadLine().Split(' '); //вводим строку матрицы
                for (int j = 0; j < write.Length; j++)
                    if (write[j] == "1") matrix[i, j] = true;
            }
            return matrix;
        }

//создание кортежа отношений по булевой матрице и множеству
static (string x1, string x2)[] Read_corteg(bool[,] R, string[] A)
        {
            (string x1, string x2)[] corteg = new (string, string)[0];
            int k = 0;
            for(int i = 0; i <A.Length; i++ )
                for(int j = 0; j<A.Length; j++)
                    if (R[i, j])
                    {
                        Array.Resize(ref corteg, ++k);
                        corteg[k - 1].x1 = A[i];
                        corteg[k - 1].x2 = A[j];
                    }
            return corteg;
        }
