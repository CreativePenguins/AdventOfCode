using System;
using System.IO;
using System.Linq;

namespace day2
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("data.txt");

            int correctPasswords = 0;

            foreach(string line in lines) {
                string[] passwordAndPolicy = line.Trim().Split(' ');
                
                string timesAllowed = passwordAndPolicy[0];
                char allowedChar = char.Parse(passwordAndPolicy[1].TrimEnd(':'));
                string password = passwordAndPolicy[2];

                int minAllowed = int.Parse(timesAllowed.Split('-')[0]);
                int maxAllowed = int.Parse(timesAllowed.Split('-')[1]);

                int count = password.Count(f => (f == allowedChar));

                if(count >= minAllowed && count <= maxAllowed) {
                    correctPasswords++;
                }
            }

            Console.WriteLine($"There are {correctPasswords} correct passwords.");
        }
    }
}
