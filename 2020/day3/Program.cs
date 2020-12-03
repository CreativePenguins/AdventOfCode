using System;
using System.IO;

namespace day3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("data.txt");
            int trees = 0;

            for(int i = 0; i < lines.Length; i++) {
                string treeLine = lines[i];
                int position = i * 3 % treeLine.Length;

                if (treeLine[position] == '#') {
                    trees++;
                }
            }

            Console.WriteLine($"There are {trees} trees.");
        }
    }
}
