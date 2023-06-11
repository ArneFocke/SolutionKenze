using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace _6LetterWordChallenge.Models
{
    public class WordFinder
    {
        private List<Word> Words;

        public WordFinder(List<Word> words)
        {
            Words = words;
        }

        public HashSet<WordCombination> FindCombinations()
        {
            string configFilePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "Config");
            var configuration = new ConfigurationBuilder()
                .SetBasePath(configFilePath)
                .AddJsonFile("appsettings.json")
                .Build();

            int lengthOfWord = int.Parse(configuration["LengthOfWord"]);
            HashSet<WordCombination> combinations = new HashSet<WordCombination>();
            HashSet<string> encounteredCombinations = new HashSet<string>();

            for (int i = 0; i < Words.Count; i++)
            {
                for (int j = i + 1; j < Words.Count; j++)
                {
                    WordCombination combination = new WordCombination(Words[i], Words[j], lengthOfWord);

                    if (combination.IsValid(Words) && !encounteredCombinations.Contains(combination.Combination))
                    {
                        combinations.Add(combination);
                        encounteredCombinations.Add(combination.Combination);
                    }
                }
            }

            return combinations;
        }
    }
}