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
            Program2 help = new Program2();
            List<string> input = new List<string>(File.ReadAllLines("data.txt"));

            for(int i = 0; i < input.Count; i++) {
                var newInput = new List<string>(input);
                string oldCommand = newInput[i];
                
                switch(oldCommand.Substring(0,3)) {
                    case "nop":
                        newInput[i] = oldCommand.Replace("nop", "jmp");
                        break;
                    case "jmp":
                        newInput[i] = oldCommand.Replace("jmp", "nop");
                        break;
                    default:
                        continue;
                }
                var worked = help.figureItOut(newInput);

                if(worked.Item1)
                    Console.WriteLine($"It worked! Value: {worked.Item2}");
            }
        }
    }

    class Program2 {
        public Tuple<bool, double> figureItOut(List<string> input) {
            Dictionary<int, string> completedInstructions = new Dictionary<int, string>();
            int i = 0;
            double accumulator = 0;
            bool working = true;

            while(i < input.Count) {
                string instruction = input[i];

                if(completedInstructions.ContainsKey(i)) {
                    working = false;
                    break;
                } else {
                    completedInstructions.Add(i, instruction);
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
            return new Tuple<bool, double>(working, accumulator);
        }
    }
}
