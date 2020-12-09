using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace day7
{
    class Program
    {
        static void Main(string[] args)
        {
            Helper helper = new Helper();

            ImmutableList<string> input = ImmutableList.Create<string>(File.ReadAllLines("data.txt"));
            
            double badNumber = helper.findBadNumber(input);
            Console.WriteLine($"Bad Number: {badNumber}");

            var result = helper.findContiguousSet(badNumber, input);

            if(result.Item1) {
                Console.WriteLine($"Min: {result.Item2}; Max: {result.Item3}; Sum: {result.Item2 + result.Item3}");
            } else {
                Console.WriteLine("Not Found");
            }
        }
    }

    class Helper {
        public Tuple<bool, double, double> findContiguousSet(double lookFor, ImmutableList<string> listToSearch) {
            List<double> contiguousList = new List<double>();

            int index = 0;
            int startIndex = 0;

            bool found = false;
            double min = 0;
            double max = 0;

            while(index < listToSearch.Count) {
                double searchNumber = double.Parse(listToSearch[index]);

                if(contiguousList.Count == 0) {
                    startIndex = index;
                }

                contiguousList.Add(searchNumber);

                if(contiguousList.Sum() > lookFor) {
                    contiguousList.Clear();
                    index = startIndex + 1;
                    continue;
                } else if (contiguousList.Sum() < lookFor) {
                    index++;
                    continue;
                } else if (contiguousList.Sum() == lookFor) {
                    if(contiguousList.Count == 1) {
                        contiguousList.Clear();
                        index = startIndex + 1;
                        continue;
                    }
                    min = contiguousList.Min();
                    max = contiguousList.Max();
                    found = true;
                    break;
                }
            }

            return new Tuple<bool, double, double>(found, min, max);
        }
        public double findBadNumber(ImmutableList<string> listToSearch) {
            double badNumber = 0;

            for(int i = 25; i < listToSearch.Count; i++) {
                double currentNumber = double.Parse(listToSearch[i]);
                ImmutableList<string> subInput = listToSearch.GetRange(i-25, 25);

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
                    badNumber = currentNumber;
                    break;
                }
            }

            return badNumber;
        }
    }
}
