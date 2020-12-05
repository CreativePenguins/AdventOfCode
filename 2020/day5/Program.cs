using System;
using System.Collections.Generic;
using System.IO;

namespace day5
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("data.txt");
            List<int> seatIds = new List<int>();

            foreach(string line in lines) {
                string rowCode = line.Substring(0, 7);
                string columnCode = line.Substring(6);

                int rowMax = 128;
                int rowMin = 0;

                int columnMax = 8;
                int columnMin = 0;

                foreach(char letter in rowCode) {
                    switch(letter) {
                        case 'F':
                            rowMax -= (rowMax - rowMin) / 2;
                            break;
                        case 'B':
                            rowMin += (rowMax - rowMin) / 2;
                            break;
                    }
                }

                foreach(char letter in columnCode) {
                    switch(letter) {
                        case 'L':
                            columnMax -= (columnMax - columnMin) / 2;
                            break;
                        case 'R':
                            columnMin += (columnMax - columnMin) / 2;
                            break;
                    }
                }

                int seatId = rowMin * 8 + columnMin;
                seatIds.Add(seatId);
            }

            seatIds.Sort();

            for(int i = 0; i + 1 < seatIds.Count; i++) {
                if(seatIds[i + 1] - seatIds[i] != 1) {
                    Console.WriteLine($"Your seat id is: {seatIds[i] + 1}");
                }
            }
        }
    }
}
