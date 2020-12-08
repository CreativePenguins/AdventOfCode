using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace day7
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> input = new List<string>(File.ReadAllLines("data.txt"));
            double accumulator = 0;

            List<int> completedInstructions = new List<int>();

            int i = 0;
            while(i < input.Count) {
                string instruction = input[i];

                if(completedInstructions.Contains(i)) {
                    Console.WriteLine($"Acc val is {accumulator}");
                    break;
                } else {
                    completedInstructions.Add(i);
                }


                string operation = instruction.Split(' ')[0].Trim();
                string op = instruction.Split(' ')[1]
                    .Trim()
                    .Substring(0, 1);
                int num = int.Parse(instruction.Split(' ')[1]
                    .Trim()
                    .Substring(1));

                switch(operation) {
                    case "nop":
                        i++;
                        continue;
                    case "acc":
                        i++;
                        if (op == "+")
                            accumulator += num;
                        else 
                            accumulator -= num;
                        continue;
                    case "jmp":
                        if (op == "+")
                            i += num;
                        else
                            i -= num;
                        continue;
                }
            }
        }
    }
}
