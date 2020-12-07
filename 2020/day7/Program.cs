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
            // Do some recursion
            Dictionary<string, List<string>> rules = new Dictionary<string, List<string>>();
            // muted yellow, [2 shiny gold, 9 faded plum]
            // muted yellow, [no other]

            Dictionary<string, bool> bagCanContain = new Dictionary<string, bool>();

            int total = 0;

            foreach(string line in rulesInput) {
                string[] bagInfo = line.Split("contain");
                List<string> allowedBags = new List<string>();

                string bagColor = Regex.Replace(bagInfo[0], @"bags?", "").Trim();
                foreach(string bag in Regex.Replace(bagInfo[1], @"bags?", "").TrimEnd('.').Split(',')) {
                    allowedBags.Add(bag.Trim());
                }

                rules.Add(bagColor, allowedBags);
            }

            foreach(KeyValuePair<string, List<string>> rule in rules) {
                if(helper.CanContainColor(
                    rule.Key,
                    rule.Value, 
                    "shiny gold", 
                    rules, 
                    bagCanContain))
                    total++;
            }

            Console.WriteLine($"There are {total} bag colors");
        }
    }

    class Program2 {
        public Boolean CanContainColor(
            string key,
            List<string> values, 
            string color, 
            Dictionary<string, List<string>> rules,
            Dictionary<string, bool> alreadyChecked) {

            bool canContain = false;

            foreach(string value in values) {
                string newBagColor = Regex.Replace(value, @"\d{1,}", "").Trim();

                if(alreadyChecked.ContainsKey(key)) {
                    canContain = alreadyChecked[key];
                } else if (value.Contains(color)) {
                    canContain = true;
                } else if (value.Contains("no other")) {
                    canContain = false;
                } else {
                    canContain = CanContainColor(newBagColor, rules[newBagColor], color, rules, alreadyChecked);
                }

                if(canContain) {
                    if(!alreadyChecked.ContainsKey(key))
                        alreadyChecked.Add(key, canContain);
                    return canContain;
                }
            }

            if(!alreadyChecked.ContainsKey(key))
                alreadyChecked.Add(key, canContain);
            return canContain;
        }
    }
}
