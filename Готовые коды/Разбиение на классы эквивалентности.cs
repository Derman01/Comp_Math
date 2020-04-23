
//Разбиение множества на классы эквивалентности
static string[][] Ekv(string[] M, HashSet<(string x1,string x2)> corteg)
        {
            var B = new string[1][];
            B[0] = new string[1];
            foreach (var a in M)
            {
                var was = false;
                for (int i = 0; i < B.Length; i++)
                {
                    for (int j = 0; j < B[i].Length; j++)
                        if (corteg.Contains((B[i][j], a)))
                        {
                            Array.Resize(ref B[i], B[i].Length + 1);
                            B[i][B[i].Length - 1] = a;
                            was = true;
                            break;
                        }
                }
                if (!was)
                {
                    Array.Resize(ref B, B.Length + 1);
                    Array.Resize(ref B[B.Length - 1], 1);
                    B[B.Length - 1][0] = a;
                }
            }
            return B;
        }
