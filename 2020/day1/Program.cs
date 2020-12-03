using System;
using System.IO;

namespace day1
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("numbers.txt");

            int num1, num2, num3 = 0;

            for(int i = 0; i < lines.Length; i++) {
                num1 = int.Parse(lines[i]);

                for(int j = i + 1; j < lines.Length; j++){
                    num2 = int.Parse(lines[j]);

                    for(int k = j + 1; k < lines.Length; k++){
                        num3 = int.Parse(lines[k]);

                        if(num1 + num2 + num3 == 2020) {
                            Console.WriteLine($"The numbers are {num1}, {num2}, and {num3}.");
                            Console.WriteLine($"Their sum is {num1 * num2 * num3}.");
                        }
                    }

                }
            }
        }
    }
}
