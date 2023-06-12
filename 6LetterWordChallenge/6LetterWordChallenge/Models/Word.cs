using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6LetterWordChallenge.Models
{
    
    public class Word
    {
        [ExcludeFromCodeCoverage]
        public string Value { get; }
        [ExcludeFromCodeCoverage]
        public Word(string value)
        {
            Value = value;
        }
    }
}
