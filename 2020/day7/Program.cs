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
            Program2 helper = new Program2();

            List<string> rulesInput = new List<string>(File.ReadAllLines("data.txt"));
            Dictionary<string, List<string>> rules = new Dictionary<string, List<string>>();

            Dictionary<string, bool> bagCanContain = new Dictionary<string, bool>();

            foreach(string line in rulesInput) {
                string[] bagInfo = line.Split("contain");
                List<string> allowedBags = new List<string>();

                string bagColor = Regex.Replace(bagInfo[0], @"bags?", "").Trim();
                foreach(string bag in Regex.Replace(bagInfo[1], @"bags?", "").TrimEnd('.').Split(',')) {
                    allowedBags.Add(bag.Trim());
                }

                rules.Add(bagColor, allowedBags);
            }

            int number = helper.CountBagsContained("shiny gold", rules, 1);

            Console.WriteLine($"There are {number} contained bags");
        }
    }

    class Program2 {
        public int CountBagsContained(
            string key,
            Dictionary<string, List<string>> rules,
            int keyCount) {

            int totalBags = 0;

            foreach(string value in rules[key]) {
                string newBagColor = Regex.Replace(value, @"\d{1,}", "").Trim();
                int newBagCount = 0;
                int.TryParse(Regex.Match(value, @"\d{1,}").Value.Trim(), out newBagCount);

                if (value.Contains("no other")) {
                    totalBags += 0;
                } else {
                    totalBags += newBagCount + (newBagCount * CountBagsContained(newBagColor, rules, newBagCount));
                }
            }

            return totalBags;
        }
    }
}
