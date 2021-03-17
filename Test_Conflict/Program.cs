using System;


namespace Task_9
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;

            int m;
            int n;
            m = MyProgram.GetData_keyb("значення M кількість стрічок масиву");
            n = MyProgram.GetData_keyb("значення N кількість стовпців масиву");

            int[,] mas = new int[m, n];

            MyProgram.Arr_rand(ref mas);
            MyProgram.Arr_print(mas);

            int key;
            key = MyProgram.GetData_keyb("значення 'ключа' для пошуку", "numb");

            MyProgram.Arr_find(mas, key);

            MyProgram.Arr_func(mas);

            MyProgram.IsEqual func = MyProgram.ConditionCheck;

            Console.WriteLine("\n   Викликаємо функцію з делегатом\n");

            MyProgram.MyCalculation(mas, func);

            Console.WriteLine("\n   Викликаємо функцію з лямбда-виразом\n");

            MyProgram.MyCalculation(mas, x => x <= 27);

        }
    }

    class MyProgram
    {
        public static int GetData_keyb(string s, string mode = "arr")
        {
            int x = 0;
            Console.Write($"\nВведіть {s}: ");
            string str = Console.ReadLine();
            switch (mode)
            {
                case "arr":
                    while (!int.TryParse(str, out x) | x <= 0)
                    {
                        Console.WriteLine("Було введено некоректне значення, спробуйте ще раз...");
                        str = Console.ReadLine();
                    }
                    break;

                case "numb":
                    while (!int.TryParse(str, out x))
                    {
                        Console.WriteLine("Було введено некоректне значення, спробуйте ще раз...");
                        str = Console.ReadLine();
                    }
                    break;
            }
            return x;
        }

        public static void Arr_rand(ref int[,] arr)
        {
            Random rnd = new Random();
            int m = arr.GetUpperBound(0) + 1;
            int n = arr.GetUpperBound(1) + 1;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    arr[i, j] = rnd.Next(1, 41);
                }
            }
        }

        public static void Arr_print(int[,] arr)
        {
            int m = arr.GetUpperBound(0) + 1;
            int n = arr.GetUpperBound(1) + 1;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write($"{arr[i, j]} \t");
                }

                Console.WriteLine();

            }
        }

        public static void Arr_find(int[,] arr, int key)
        {
            int m = arr.GetUpperBound(0) + 1;
            int n = arr.GetUpperBound(1) + 1;
            bool flag = true;
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (arr[i, j] == key)
                    {
                        Console.WriteLine($"array[{i},{j}] = {arr[i, j]}");
                        flag = false;
                    }
                }
            }

            if (flag)
            {
                Console.WriteLine($"У масиві немає елемента {key}");
            }
            Console.WriteLine();
        }

        public static void Arr_func(int[,] arr)
        {
            int m = arr.GetUpperBound(0) + 1;
            int n = arr.GetUpperBound(1) + 1;
            int max;
            int min;
            for (int i = 0; i < m; i++)
            {
                max = arr[i, 0];
                min = arr[i, 0];
                for (int j = 0; j < n; j++)
                {
                    if (arr[i, j] > max)
                    {
                        max = arr[i, j];
                    }

                    if (arr[i, j] < min)
                    {
                        min = arr[i, j];
                    }
                }

                Console.WriteLine($"{i + 1}. min({min}) + max({max}) = {min + max}");

            }
        }




        public delegate bool IsEqual(int x);

        public static bool ConditionCheck(int x)
        {
            if (x % 7 == 0)
            {
                return true;
            }
            return false;
        }

        static public void MyCalculation(int[,] arr, IsEqual func)
        {
            int m = arr.GetUpperBound(0) + 1;
            int n = arr.GetUpperBound(1) + 1;
            int max;
            int min;
            for (int i = 0; i < m; i++)
            {
                max = int.MinValue;
                min = int.MaxValue;
                bool flag_min = false;
                bool flag_max = false;
                for (int j = 0; j < n; j++)
                {
                    if (arr[i, j] > max && func(arr[i, j]))
                    {
                        max = arr[i, j];
                        flag_max = true;
                    }

                    if (arr[i, j] < min && func(arr[i, j]))
                    {
                        min = arr[i, j];
                        flag_min = true;
                    }
                }

                if (!flag_max)
                {
                    max = 0;
                }

                if (!flag_min)
                {
                    min = 0;
                }

                if (max == 0 && min == 0)
                {
                    Console.WriteLine($"У рядку {i + 1} не знайдено елементи, що задовільняють умову");
                }
                else
                {
                    Console.WriteLine($"{i + 1}. min({min}) + max({max}) = {min + max}");
                }

            }

        }
    }

}


