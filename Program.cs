using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Santa_s_Secret_Helper
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string command = "";
            List<string> listNames = new List<string>();
            int key = int.Parse(Console.ReadLine());
            
            while ((command = Console.ReadLine()) != "end")
            {
                char[] chars = command.ToCharArray();
                StringBuilder sb = new StringBuilder();

                foreach (char c in chars)
                {
                    sb.Append(Convert.ToChar(c - key));
                }

                string names = sb.ToString();

                Regex regex = new Regex(@"@(?'name'[A-Za-z]+)\S[^-@!:>]+!(?'behavior'[G|N]{1})!");

                MatchCollection matches = regex.Matches(names);

                foreach (Match match in matches)
                {
                    if (match.Success)
                    {
                        string behavior = match.Groups["behavior"].Value;
                        if (behavior == "N")
                        {
                            continue;
                        }
                        string namesInMatches = match.Groups["name"].Value;
                        listNames.Add(namesInMatches);
                    }
                }
            }
            Console.WriteLine(string.Join("\n", listNames));
        }
    }
}
