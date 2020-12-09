using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Text.RegularExpressions;

namespace day7
{
    class Program
    {
        static void Main(string[] args)
        {
            ImmutableList<string> input = ImmutableList.Create<string>(File.ReadAllLines("data.txt"));

            for(int i = 25; i < input.Count; i++) {
                double currentNumber = double.Parse(input[i]);
                ImmutableList<string> subInput = input.GetRange(i-25, 25);

                bool doesContain = false;
                
                foreach(string num in subInput) {
                    double partner = currentNumber - double.Parse(num);
                    if(subInput.Contains(partner.ToString())) {
                        doesContain = true;
                        break;
                    } else {
                        continue;
                    }
                }

                if(!doesContain) {
                    Console.WriteLine($"The number is {currentNumber}");
                    break;
                }
            }
        }
    }
}
