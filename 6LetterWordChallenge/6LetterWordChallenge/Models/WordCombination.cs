using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6LetterWordChallenge.Models
{
    public class WordCombination
    {
        public int LengthOfWord { get; }
        public Word FirstPartOfWord { get; }
        public Word SecondPartOfWord { get; }
        public string Combination { get; }

        public WordCombination(Word word1, Word word2, int lengthOfWord)
        {
            FirstPartOfWord = word1;
            SecondPartOfWord = word2;
            LengthOfWord = lengthOfWord;
            Combination = word1.Value + word2.Value;
        }

        public bool IsValid(List<Word> words)
        {
            return Combination.Length == LengthOfWord && words.Exists(w => w.Value == Combination);
        }

        [ExcludeFromCodeCoverage]
        public override string ToString()
        {
            return $"{Combination} = {FirstPartOfWord.Value} + {SecondPartOfWord.Value}";
        }
    }
}
