using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

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

            int validPassports = 0; // 546 too high, 138 is a little high

            List<string> passportFields = new List<string>();

            foreach(string line in lines) {
                if(line.Trim() == "") {
                    List<string> keys = new List<string>();
                    passportFields.ForEach(field => keys.Add(field.Split(":")[0]));

                    bool isValid = false;
                    var hasAllRequiredFields = 
                        !requiredFields.Except(keys).Any();
                    
                    if(hasAllRequiredFields && keys.Count == keys.Distinct().ToList().Count) {
                        foreach(string field in passportFields) {
                            string key = "";
                            string value = "";

                            key = field.Split(':')[0].Trim();
                            value = field.Split(':')[1].Trim();

                            if (key == "byr") {
                                int numValue;
                                bool success = int.TryParse(value, out numValue);

                                if(success &&
                                    value.Length == 4 && 
                                    numValue >= 1920 && 
                                    numValue <= 2002) {
                                    isValid = true;
                                } else {
                                    isValid = false;
                                    break;
                                }
                            } else if (key == "iyr") {
                                int numValue = int.Parse(value);
                                bool success = int.TryParse(value, out numValue);

                                if(success &&
                                    value.Length == 4 &&
                                    numValue >= 2010 && 
                                    numValue <= 2020) {
                                    isValid = true;
                                } else {
                                    isValid = false;
                                    break;
                                }
                            } else if (key == "eyr") {
                                int numValue = int.Parse(value);
                                bool success = int.TryParse(value, out numValue);

                                if(success &&
                                    value.Length == 4 &&
                                    numValue >= 2020 && 
                                    numValue <= 2030) {
                                    isValid = true;
                                } else {
                                    isValid = false;
                                    break;
                                }
                            } else if (key == "hgt") {
                                Regex regex = new Regex(@"^\d{1,}(cm|in){1}$");
                                Match match = regex.Match(value);

                                if (match.Success) {
                                    string unit = "";
                                    int height = 0;
                                    unit = value.Substring(value.Length - 2);
                                    height = int.Parse(
                                        value.Substring(0, value.Length - 2));
                                    
                                    if(unit == "cm") {
                                        if(height >= 150 && height <= 193) {
                                            isValid = true;
                                        } else {
                                            isValid = false;
                                            break;
                                        }
                                    } else if(unit == "in") {
                                        if(height >= 59 && height <= 76) {
                                            isValid = true;
                                        } else {
                                            isValid = false;
                                            break;
                                        }
                                    } else {
                                        isValid = false;
                                        break;
                                    }
                                } else {
                                    isValid = false;
                                    break;
                                }
                            } else if(key == "hcl") {
                                Regex regex = new Regex(@"^#(\d|[a-f]){6}$");
                                Match match = regex.Match(value);

                                if(match.Success) {
                                    isValid = true;
                                } else {
                                    isValid = false;
                                    break;
                                }
                            } else if(key == "ecl") {
                                List<string> validColors = new List<string>() {
                                    "amb", "blu", "brn", "gry", "grn", "hzl", "oth"
                                };

                                if(validColors.Contains(value)) {
                                    isValid = true;
                                } else {
                                    isValid = false;
                                    break;
                                }
                            } else if(key == "pid") {
                                Regex regex = new Regex(@"^\d{9}$");
                                Match match = regex.Match(value);

                                if(match.Success) {
                                    isValid = true;
                                } else {
                                    isValid = false;
                                    break;
                                }
                            }
                        };

                        if (isValid) {
                            validPassports++;
                            Console.WriteLine("Valid Passport:");
                            passportFields.ForEach(field => Console.Write($"{field} "));
                            Console.WriteLine();
                        }
                    }
                    
                    passportFields.Clear();
                } else {
                    List<string> dataFields = new List<string>(line.Split(' '));

                    dataFields.ForEach(field => {
                        passportFields.Add(field);
                    });
                }
            }

            Console.WriteLine($"There are {validPassports} valid passports.");
        }
    }
}
