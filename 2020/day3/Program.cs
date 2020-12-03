using System;
using System.IO;

namespace day3
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("data.txt");
            int trees1 = 0;
            int trees2 = 0;
            int trees3 = 0;
            int trees4 = 0;
            int trees5 = 0;

            for(int i = 0; i < lines.Length; i++) {
                string treeLine = lines[i];

                int position1 = i * 1 % treeLine.Length;
                int position2 = i * 3 % treeLine.Length;
                int position3 = i * 5 % treeLine.Length;
                int position4 = i * 7 % treeLine.Length;
                int position5 = (i / 2) * 1 % treeLine.Length;

                if(treeLine[position1] == '#') {
                    trees1++;
                }

                if(treeLine[position2] == '#') {
                    trees2++;
                }

                if(treeLine[position3] == '#') {
                    trees3++;
                }

                if(treeLine[position4] == '#') {
                    trees4++;
                }

                if(i % 2 == 0 && treeLine[position5] == '#') {
                    trees5++;
                }
            }

            int totalTrees = trees1 * trees2 * trees3 * trees4 * trees5;

            Console.WriteLine($"There are {totalTrees} trees."); // 2051376015
        }
    }
}
