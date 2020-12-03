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

                int firstPos = int.Parse(timesAllowed.Split('-')[0]) - 1;
                int secondPos = int.Parse(timesAllowed.Split('-')[1]) - 1;

                if(
                    (password[firstPos] == allowedChar &&
                    password[secondPos] != allowedChar) || 
                    (password[firstPos] != allowedChar &&
                    password[secondPos] == allowedChar)
                ){
                    correctPasswords++;
                }
            }

            Console.WriteLine($"There are {correctPasswords} correct passwords.");
        }
    }
}
