﻿using _6LetterWordChallenge.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6LetterWordChallenge.Tools
{
    public class FileReader
    {
        public List<Word> ReadWordsFromFile(string filePath)
        {
            List<Word> words = new List<Word>();
            string jsonPath = "C:\\Users\\Arne\\source\\repos\\6LetterWordChallenge\\6LetterWordChallenge\\Config";

            try
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(jsonPath)
                    .AddJsonFile("appsettings.json")
                    .Build();

                string inputFilePath = configuration["FilePath"];

                using (StreamReader sr = new StreamReader(inputFilePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] lineWords = line.Split(' ');

                        foreach (string word in lineWords)
                        {
                            words.Add(new Word(word));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
            }

            return words;
        }
    }
}