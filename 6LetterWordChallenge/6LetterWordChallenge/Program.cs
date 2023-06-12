using System;
using System.IO;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using _6LetterWordChallenge.Models;
using _6LetterWordChallenge.Tools;
using _6LetterWordChallenge.Config;

class Program
{
    static void Main()
    {
        ConfigurationHelper configurationHelper = new ConfigurationHelper();
        FileReader fileReader = new FileReader();

        Console.WriteLine("Reading file and searching for combinations");

        List<Word> words = fileReader.ReadWordsFromFile(configurationHelper.GetInputFilePath());
        WordFinder combinationFinder = new WordFinder(words);
        List<WordCombination> combinations = combinationFinder.FindCombinations(configurationHelper.GetConfiguration()).OrderBy(c => c.Combination).ToList();
        HashSet<WordCombination> combinationSet = new HashSet<WordCombination>(combinations);

        foreach (WordCombination combination in combinationSet)
        {
            Console.WriteLine(combination);
        }

        Console.WriteLine($"Amount of unique combinations: {combinations.Count}");

        Console.ReadLine();
    }
}