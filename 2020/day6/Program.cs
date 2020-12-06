using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day6
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("data.txt");
            List<char> answers = new List<char>();
            int total = 0;

            foreach(string line in lines) {
                if(line.Trim() == "") {
                    total += answers.Count;
                    answers.Clear();
                } else if (line.Trim() == lines.Last().Trim()) {
                    foreach(char c in line.Trim()) {
                        if(!answers.Contains(c)) {
                            answers.Add(c);
                        }
                    }
                    total += answers.Count;
                    answers.Clear();
                } else {
                    foreach(char c in line.Trim()) {
                        if(!answers.Contains(c)) {
                            answers.Add(c);
                        }
                    }
                }
            }

            Console.WriteLine($"Total is {total}"); 
        }
    }
}
