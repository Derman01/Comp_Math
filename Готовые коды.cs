//Ввод пар отношения
static (string x1, string x2)[] Corteg_Read()
        {
            Console.Write("Введите пары отношения: \n");
            (string x1, string x2)[] corteg = new (string, string)[0];

            int i = 1; // счетчик
            Console.Write($"{i}. "); string[] A = Console.ReadLine().Split(' ');
            if (A.Length != 2) return corteg;
            while (1 == 1 ) { 
                Array.Resize(ref corteg, i); //увеличиваем массив кортежей
                corteg[i - 1].x1 = A[0]; corteg[i - 1].x2 = A[1]; //запоминаем элементы
                i++; // увеличиваем счетчик
                Console.Write($"{i}. ");  A = Console.ReadLine().Split(' '); //снова вводим элементы
                if (A.Length != 2) return corteg;
            }
            
            
        }

//Создание булевой матрицы по парам 
static bool[,] Matrix_Read((string x1, string x2)[] corteg, string[] X, int len)
        {
            bool[,] R = new bool[len, len];
            for (int j = 0; j < corteg.Length; j++)
            {
                int X_1 = 0; int X_2 = 0;
                for (int i = 0; i < len; i++)
                {
                    if (X[i] == corteg[j].x1) X_1 = i;
                    if (X[i] == corteg[j].x2) X_2 = i;
                }
                R[X_1, X_2] = true;
            }
            return R;
        }

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
