using System;

namespace Lab3
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Checked input = new Checked();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("1. Задание 1 (Конструкторы заполнения матриц)");
                Console.WriteLine("2. Задание 2 (Произведение столбцов)");
                Console.WriteLine("3. Задание 3 (Матричное выражение 7*A - (B^T - 3*C))");
                Console.WriteLine("4. Задание 4 (Бинарные файлы: произведения соседних)");
                Console.WriteLine("5. Задание 5 (XML-сериализация: игрушки)");
                Console.WriteLine("6. Задание 6 (Текстовый файл: числа + 1)");
                Console.WriteLine("7. Задание 7 (Текстовый файл: сумма первого и min)");
                Console.WriteLine("8. Задание 8 (Текстовый файл: строки на букву 'б')");
                Console.WriteLine("0. Выход");
                
                int choice = input.ReadCount("Введите номер задания (от 0 до 8): ", 0,8);
                if (choice == 0)
                {
                    Console.WriteLine("\nЗавершение работы программы.");
                    break;
                }

                Console.WriteLine();

                switch (choice)
                {
                    case 1:
                    {
                        while (true)
                        {
                            Console.WriteLine("1. Матрица 1 (по диагоналям параллельным побочной)");
                            Console.WriteLine("2. Матрица 2 (случайными числами из интервала [0;1)");
                            Console.WriteLine("3. Матрица 3 (улиткой)");
                            Console.WriteLine("0. Вернуться в меню");


                            int choice1 = input.ReadCount("Введите номер матрицы (от 0 до 3): ", 0, 3);
                            if (choice1 == 0)
                            {
                                Console.WriteLine("\nВозврат в меню");
                                break;
                            }

                            switch (choice1)
                            {
                                case 1:
                                {
                                    Console.WriteLine("\nПользовательский ввод");
                                    while (true)
                                    {
                                        int n = input.ReadCount("\nВведите количество строк N (0 для выхода): ", 0, 0);
                                        if (n == 0)
                                        {
                                            break;
                                        }

                                        int m = input.ReadCount("Введите количество столбцов M: ", 1, 0);

                                        Matrix m1 = new Matrix(n, m, true);
                                        Console.WriteLine("\nПолученная матрица:");
                                        Console.WriteLine(m1.ToString());
                                    }

                                    break;
                                }
                                case 2:
                                {
                                    Console.WriteLine("\nМатрица 4x4 (случайные числа [0;1]):");
                                    Matrix m2 = new Matrix(4, new Random());
                                    Console.WriteLine(m2.ToString());

                                    Console.WriteLine("\nПользовательский ввод");
                                    while (true)
                                    {
                                        int n = input.ReadCount("\nВведите размер (0 для выхода): ", 0, 0);
                                        if (n == 0)
                                        {
                                            break;
                                        }

                                        Matrix m2_user = new Matrix(n, new Random());
                                        Console.WriteLine("\nПолученная матрица:");
                                        Console.WriteLine(m2_user.ToString());
                                    }

                                    break;
                                }
                                case 3:
                                {
                                    Console.WriteLine("Матрица 5x5 (заполнение по спирали):");
                                    Matrix m3 = new Matrix(5);
                                    Console.WriteLine(m3.ToString());

                                    Console.WriteLine("\nПользовательский ввод");
                                    while (true)
                                    {
                                        int n = input.ReadCount("\nВведите размер (0 для выхода): ", 0, 0);
                                        if (n == 0)
                                        {
                                            break;
                                        }

                                        Matrix m3_user = new Matrix(n);
                                        Console.WriteLine("\nПолученная матрица:");
                                        Console.WriteLine(m3_user.ToString());
                                    }

                                    break;
                                }
                            }
                        }
                        break;
                    }
                    case 2:
                    {
                        double[,] testArr = new double[,]
                        {
                            { 15, 2, 20 },
                            {  1, 5,  3 },
                            {  4, 2,  6 }
                        };
                        Matrix matrix = new Matrix(testArr);
                        Console.WriteLine("Исходная матрица:");
                        Console.WriteLine(matrix.ToString());
                        matrix.Task2_MultiplyColumns();
                        Console.WriteLine("\nПользовательский ввод");
                        while (true)
                        {
                            int size = input.ReadCount("\nВведите размер квадратной матрицы N (0 для выхода): ",0,0);
                            if (size == 0)
                            {
                                break;
                            }
                            Matrix customMatrix = new Matrix(size, size, true);
                            Console.WriteLine("\nВведенная матрица:\n" + customMatrix.ToString());
                            customMatrix.Task2_MultiplyColumns();
                        }
                        break;
                    }
                    case 3:
                    {
                        double[,] dataA = { { 1, 2 }, { 3, 4 } };
                        double[,] dataB = { { 5, 6 }, { 7, 8 } };
                        double[,] dataC = { { 2, 0 }, { 1, 3 } };

                        Matrix A = new Matrix(dataA);
                        Matrix B = new Matrix(dataB);
                        Matrix C = new Matrix(dataC);

                        Console.WriteLine("Матрица A:\n" + A.ToString());
                        Console.WriteLine("Матрица B:\n" + B.ToString());
                        Console.WriteLine("Матрица C:\n" + C.ToString());

                        Matrix B_T = B.Transpose();
                        Matrix threeC = 3.0 * C;
                        Matrix bracket = B_T - threeC;
                        Matrix sevenA = 7.0 * A;
                        Matrix result = sevenA - bracket;

                        Console.WriteLine("Результат выражения:\n" + result.ToString());
                        Console.WriteLine("\nПользовательский ввод");
                        while (true)
                        {
                            int size = input.ReadCount("\nВведите размеры квадратной матриц (0 для выхода): ",0,0);
                            if (size == 0)
                            {
                                break;
                            }
                            Console.WriteLine("\nВвод матрицы A:");
                            Matrix userA = new Matrix(size, size, true);
                            Console.WriteLine("\nВвод матрицы B:");
                            Matrix userB = new Matrix(size, size, true);
                            Console.WriteLine("\nВвод матрицы C:");
                            Matrix userC = new Matrix(size, size, true);
                            Matrix userResult = 7.0 * userA - (userB.Transpose() - 3.0 * userC);
                            Console.WriteLine("\nРезультат:\n" + userResult.ToString());
                        }
                        break;
                    }
                    case 4:
                    {
                        int count = input.NewReadInt("Введите количество чисел для генерации в бинарный файл: ");
                        string inputFile = @"..\..\..\t4_in.bin";
                        string outputFile = @"..\..\..\t4_out.bin";
                        FileTasks.GenerateBinaryNumbers(inputFile, count);
                        FileTasks.Task4_AdjacentProducts(inputFile, outputFile);
                        FileTasks.PrintBinaryFile(inputFile);
                        FileTasks.PrintBinaryFile(outputFile);
                        break;
                    }
                    case 5:
                    {
                        FileTasks.GenerateToysXml(@"..\..\..\toys.xml");
                        FileTasks.Task5_FindConstructorAge(@"..\..\..\toys.xml");
                        break;
                    }
                    case 6:
                    {
                        int count = input.NewReadInt("Введите количество чисел для генерации в текстовый файл: ");
                        string inputFile = @"..\..\..\t6_in.txt";
                        string outputFile = @"..\..\..\t6_out.txt";
                        FileTasks.GenerateTextFileSingle(inputFile, count);
                        FileTasks.Task6_IncrementEach(inputFile, outputFile);
                        FileTasks.PrintTextFile(inputFile);
                        FileTasks.PrintTextFile(outputFile);
                        break;
                    }
                    case 7:
                    {   
                        string inputFile = @"..\..\..\t7.txt";
                        while (true)
                        {
                            int rows = input.ReadCount("\nВведите количество строк N (0 для выхода): ", 0, 0);
                            if (rows == 0)
                            {
                                break;
                            }

                            int cols = input.ReadCount("Введите количество столбцов M: ", 1, 0);

                            FileTasks.GenerateTextFileMultiple(inputFile, rows, cols);
                            FileTasks.PrintTextFile(inputFile);
                            FileTasks.Task7_FirstAndMinSum(inputFile);
                        }
                        break;
                    }
                    case 8:
                    {   
                        string inputFile = @"..\..\..\t8_in.txt";
                        string outputFile = @"..\..\..\t8_out.txt";
                        Console.WriteLine("Введите строки текста (Enter на пустой строке для завершения ввода):");
                        List<string> userLines = new List<string>();
                        while (true)
                        {
                            Console.Write($"Строка {userLines.Count + 1}: ");
                            string line = Console.ReadLine();

                            if (string.IsNullOrWhiteSpace(line))
                            {
                                if (userLines.Count == 0)
                                {
                                    Console.WriteLine("Список пуст, введите строку");
                                    continue;
                                }
                                break;
                            }

                            userLines.Add(line);
                        }
                        Console.WriteLine();
                        FileTasks.GenerateCustomTextFile(inputFile, userLines);
                        FileTasks.PrintTextFile(inputFile);
                        
                        Console.WriteLine();
                        FileTasks.Task8_FilterLinesEndingWithB(inputFile, outputFile);
                        FileTasks.PrintTextFile(outputFile);
                        break;
                    }
                }
                Console.WriteLine("\nНажмите любую клавишу для возврата в меню...");
                Console.ReadKey();
            }
        }
    }
}