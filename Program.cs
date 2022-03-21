using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Post_Office
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] inputs = Console.ReadLine().Split('|', StringSplitOptions.RemoveEmptyEntries);

            string inputLetters = inputs[0];
            string lettersPosition = inputs[1];
            string lettersValue = inputs[2];

            Regex regexLetters = new Regex(@"([\D+\d+]+)?([\$\#\%\&\*]{1})(?'firstLetter'[A-Z]+)\2([\D+\d+])*");
            Regex regexPositions = new Regex(@"(?'asciiLENGTH'(?'charNumber'\d{2}):(?'wordLength'\d{2}))");
            Regex regexValue = new Regex(@"\b(?'word'[A-Z][\S]+)\b");

            Match matchLetters = regexLetters.Match(inputLetters);
            MatchCollection matchesPositions = regexPositions.Matches(lettersPosition);
            MatchCollection matchesValue = regexValue.Matches(lettersValue);

            string letters = matchLetters.Groups["firstLetter"].Value;
            List<string> output = new List<string>();

            for (int i = 0; i < letters.Length; i++)
            {
                foreach (Match m in matchesPositions)
                {
                    char newChar = (char)int.Parse(m.Groups["charNumber"].Value);
                    int wordLength = int.Parse(m.Groups["wordLength"].Value);
                    if (letters[i] == newChar)
                    {
                        foreach (var item in matchesValue)
                        {
                            string word = item.ToString();
                            char newCharValue = Convert.ToChar(word.Substring(0, 1));
                            if (letters[i] == newCharValue && word.Length == wordLength + 1)
                            {
                                if (output.Contains(word))
                                {
                                    continue;
                                }
                                output.Add(word);
                            }
                        }
                    }
                }
                
            }

            foreach (var word in output)
            {
                Console.WriteLine(word);
            }
        }
    }
}
