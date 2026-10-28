using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Lab3
{
    public static class FileTasks
    {
        public static void GenerateBinaryNumbers(string fileName, int count)
        {
            Random rnd = new Random();
            using (BinaryWriter writer = new BinaryWriter(File.Open(fileName, FileMode.Create)))
            {
                for (int i = 0; i < count; i++)
                {
                    writer.Write(rnd.Next(1, 10));
                }
            }
        }

        public static void Task4_AdjacentProducts(string inputFile, string outputFile)
        {
            List<int> numbers = new List<int>();
            using (BinaryReader reader = new BinaryReader(File.Open(inputFile, FileMode.Open)))
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    numbers.Add(reader.ReadInt32());
                }
            }

            using (BinaryWriter writer = new BinaryWriter(File.Open(outputFile, FileMode.Create)))
            {
                for (int i = 0; i < numbers.Count - 1; i++)
                {
                    int product = numbers[i] * numbers[i + 1];
                    writer.Write(product);
                }
            }
            Console.WriteLine("Произведения соседних элементов записаны в бинарный файл");
        }
        
        public static void PrintBinaryFile(string fileName)
        {
            Console.WriteLine($"Содержимое бинарного файла {fileName}:");
            using (BinaryReader reader = new BinaryReader(File.Open(fileName, FileMode.Open)))
            {
                while (reader.BaseStream.Position < reader.BaseStream.Length)
                {
                    int number = reader.ReadInt32();
                    Console.Write(number + " ");
                }
            }
            Console.WriteLine();
        }
        
        public static void GenerateToysXml(string fileName)
        {
            Toy[] toys = new Toy[3];
            toys[0] = new Toy("Кукла", 1200, 3, 7);
            toys[1] = new Toy("Конструктор LEGO", 3500, 5, 12);
            toys[2] = new Toy("Мяч", 800, 4, 16);

            XmlSerializer serializer = new XmlSerializer(typeof(Toy[]));
            using (FileStream fs = new FileStream(fileName, FileMode.Create))
            {
                serializer.Serialize(fs, toys);
            }
        }

        public static void Task5_FindConstructorAge(string fileName)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Toy[]));
            Toy[] toys;

            using (FileStream fs = new FileStream(fileName, FileMode.Open))
            {
                toys = (Toy[])serializer.Deserialize(fs);
            }

            foreach (Toy toy in toys)
            {
                Console.WriteLine(toy.ToString());
                if (toy.Name.Contains("Конструктор"))
                {
                    Console.WriteLine($"---Этот конструктор для детей от {toy.MinAge} до {toy.MaxAge} лет");
                }
            }
        }
        
        public static void GenerateTextFileSingle(string fileName, int count)
        {
            Random rnd = new Random();
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                for (int i = 0; i < count; i++)
                {
                    sw.WriteLine(rnd.Next(-10, 10));
                }
            }
        }

        public static void Task6_IncrementEach(string inputFile, string outputFile)
        {
            string[] lines = File.ReadAllLines(inputFile);
            using (StreamWriter sw = new StreamWriter(outputFile))
            {
                foreach (string line in lines)
                {
                    int val = int.Parse(line);
                    sw.WriteLine(val + 1);
                }
            }
            Console.WriteLine("Все числа увеличены на 1 и записаны в новый файл");
        }
        
        public static void GenerateTextFileMultiple(string fileName, int rows, int cols)
        {
            Random rnd = new Random();
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                for (int i = 0; i < rows; i++)
                {
                    string line = "";
                    for (int j = 0; j < cols; j++)
                    {
                        line += rnd.Next(1, 100) + " ";
                    }
                    sw.WriteLine(line.Trim());
                }
            }
        }

        public static void Task7_FirstAndMinSum(string fileName)
        {
            string[] lines = File.ReadAllLines(fileName);
            
            bool isFirst = true;
            int firstElement = 0;
            int minElement = 999999;

            foreach (string line in lines)
            {
                string[] parts = line.Split(' ');
                foreach (string part in parts)
                {
                    int val = int.Parse(part);
                    
                    if (isFirst)
                    {
                        firstElement = val;
                        isFirst = false;
                    }
                    
                    if (val < minElement)
                    {
                        minElement = val;
                    }
                }
            }

            int sum = firstElement + minElement;
            Console.WriteLine("Первый элемент: " + firstElement);
            Console.WriteLine("Минимальный элемент: " + minElement);
            Console.WriteLine("Сумма: " + sum);
        }
        
        public static void GenerateSampleText(string fileName)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                sw.WriteLine("Большой дуб");
                sw.WriteLine("Тестовая строка");
                sw.WriteLine("Храбрый краб");
                sw.WriteLine("Просто текст");
            }
        }

        public static void Task8_FilterLinesEndingWithB(string inputFile, string outputFile)
        {
            string[] lines = File.ReadAllLines(inputFile);
            using (StreamWriter sw = new StreamWriter(outputFile))
            {
                foreach (string line in lines)
                {
                    string trimmed = line.Trim();
                    if (trimmed.EndsWith("б") || trimmed.EndsWith("Б")) 
                    {
                        sw.WriteLine(line);
                    }
                }
            }
            Console.WriteLine("Строки, оканчивающиеся на 'б', переписаны");
        }
        
        public static void GenerateCustomTextFile(string fileName, List<string> lines)
        {
            using (StreamWriter sw = new StreamWriter(fileName))
            {
                foreach (string line in lines)
                {
                    sw.WriteLine(line);
                }
            }
        }
        
        public static void PrintTextFile(string fileName)
        {
            Console.WriteLine($"Содержимое файла {fileName}:");
            string[] lines = File.ReadAllLines(fileName);
            foreach (string line in lines)
            {
                Console.WriteLine(line);
            }
        }
    }
}