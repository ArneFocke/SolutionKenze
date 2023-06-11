using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using _6LetterWordChallenge.Models;
using _6LetterWordChallenge.Tools;

class Program
{
    static void Main()
    {
        var FileReader = new FileReader();

        Console.WriteLine("reading file and searching for combinations");
        List<Word> words = FileReader.ReadWordsFromFile();

        WordFinder combinationFinder = new WordFinder(words);
        HashSet<WordCombination> combinations = combinationFinder.FindCombinations();

        List<WordCombination> sortedCombinations = combinations.OrderBy(c => c.Combination).ToList();

        foreach (WordCombination combination in sortedCombinations)
        {
            Console.WriteLine(combination);
        }

        Console.WriteLine($"amount of unique combinations: {combinations.Count}");

        Console.ReadLine();
    }
}