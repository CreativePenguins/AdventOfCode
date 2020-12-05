using System;
using System.IO;

namespace day5
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("data.txt");
            int maxSeatId = 0;

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
                maxSeatId = seatId > maxSeatId ? seatId : maxSeatId;
            }

            Console.WriteLine($"The max seat id is {maxSeatId}");
        }
    }
}
