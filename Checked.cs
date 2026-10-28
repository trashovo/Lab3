using System;

namespace Lab3
{
    internal class Checked
    {
        public int ReadInt(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            int x = 0;
            
            while (true)
            {
                if (int.TryParse(input, out x))
                {
                    return x;
                }
                else
                {
                    Console.Write("Ошибка ввода! Повторите ввод: ");
                    input = Console.ReadLine();
                }
            }
        }
        
        public int NewReadInt(string prompt)
        {
            Console.Write(prompt);
            string input = Console.ReadLine();
            int x = 0;
            
            while (true)
            {
                if (int.TryParse(input, out x) && x > 0)
                {
                    return x;
                }
                else
                {
                    Console.Write("Ошибка! Введите целое число больше нуля: ");
                    input = Console.ReadLine();
                }
            }
        }
        
        public int ReadCount(string prompt, int minRequired, int maxRequired)
        {
            while (true)
            {
                int count = ReadInt(prompt);
                if (maxRequired == 0)
                {
                    if (count < minRequired)
                    {
                        Console.WriteLine($"Ошибка, введите значение >= {minRequired}");
                        continue;
                    }
                }
                else
                {
                    if ((count < minRequired) || (count > maxRequired))
                    {
                        Console.WriteLine($"Ошибка, введите значение от {minRequired} до {maxRequired}");
                        continue;
                    }
                }
                
                return count;
            }
        }
    }
}