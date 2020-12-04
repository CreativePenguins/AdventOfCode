using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace day4
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("data.txt");
            List<string> requiredFields = new List<string>() {
                "byr",
                "iyr",
                "eyr",
                "hgt",
                "hcl",
                "ecl",
                "pid"
            };

            int validPassports = 0;

            List<string> passportFields = new List<string>();

            foreach(string line in lines) {
                if(line.Trim() == "") {
                    var hasAllRequiredFields = !requiredFields.Except(passportFields).Any();
                    
                    if(hasAllRequiredFields) 
                        validPassports++;
                    
                    passportFields.Clear();
                } else {
                    List<string> dataFields = new List<string>(line.Split(' '));

                    dataFields.ForEach(field => {
                        passportFields.Add(field.Substring(0, 3));
                    });
                }
            }

            Console.WriteLine($"There are {validPassports} valid passports.");
        }
    }
}
