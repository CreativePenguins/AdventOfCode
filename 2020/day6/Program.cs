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
            int total = 0;

            List<char> answers = new List<char>();
            Dictionary<char, int> charCount = new Dictionary<char, int>();
            int people = 0;

            foreach(string line in lines) {
                if(line.Trim() == "") {
                    foreach(char c in answers) {
                        if(charCount.ContainsKey(c)) {
                            charCount[c] += 1;
                        } else {
                            charCount.Add(c, 1);
                        }
                    }

                    foreach(var entry in charCount) {
                        if(charCount[entry.Key] == people)
                            total++;
                    }

                    people = 0;
                    answers.Clear();
                    charCount.Clear();
                } else if (line.Trim() == lines.Last().Trim()) {
                    people++;
                    foreach(char c in line) {
                        answers.Add(c);
                    }

                    foreach(char c in answers) {
                        if(charCount.ContainsKey(c)) {
                            charCount[c] += 1;
                        } else {
                            charCount.Add(c, 1);
                        }
                    }

                    foreach(var entry in charCount) {
                        if(charCount[entry.Key] == people)
                            total++;
                    }

                    people = 0;
                    answers.Clear();
                    charCount.Clear();
                } else {
                    people++;
                    foreach(char c in line) {
                        answers.Add(c);
                    }
                }
            }

            Console.WriteLine($"Total is {total}"); 
            // 11902 too high
        }
    }
}
