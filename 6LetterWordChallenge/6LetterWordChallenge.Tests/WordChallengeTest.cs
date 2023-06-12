using _6LetterWordChallenge.Config;
using _6LetterWordChallenge.Models;
using _6LetterWordChallenge.Tools;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace _6LetterWordChallenge.Tests
{
    public class WordChallengeTest
    {
        private IConfiguration GetTestConfiguration()
        {
            // Create a test configuration with the desired values
            string configFilePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "Config");

            var configuration = new ConfigurationBuilder()
                .SetBasePath(configFilePath)
                .AddJsonFile("appsettings.json")
                .Build();

            return configuration;
        }

        [Fact]
        public void ConfigFilePath_Exists()
        {
            // Arrange
            string configFilePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "Config");

            // Act
            bool pathExists = Directory.Exists(configFilePath);

            // Assert
            Assert.True(pathExists);
        }

        [Fact]
        public void FindCombination_ReturnsAUniqueCombination()
        {
            {
                // Arrange
                List<Word> words = new List<Word>
            {
                new Word("osine"),
                new Word("them"),
                new Word("narro"),
                new Word("w"),
                new Word("awler"),
                new Word("narrow"),
                new Word("word1"),
                new Word("word3")
            };

                IConfiguration configuration = GetTestConfiguration();

                WordFinder wordFinder = new WordFinder(words);

                // Act
                HashSet<WordCombination> combinations = wordFinder.FindCombinations(configuration);

                // Assert
                Assert.Single(combinations);
                Assert.Contains(combinations, c => c.Combination == "narrow");
            }
        }
        [Fact]
        public void IsValid_ReturnsTrue_WhenCombinationIsValid()
        {
            // Arrange
            Word word1 = new Word("hello");
            Word word2 = new Word("world");
            int lengthOfWord = 10;

            WordCombination wordCombination = new WordCombination(word1, word2, lengthOfWord);
            List<Word> words = new List<Word>
            {
                new Word("helloworld"),
                new Word("hello"),
                new Word("world"),
                new Word("other"),
            };

            // Act
            bool isValid = wordCombination.IsValid(words);

            // Assert
            Assert.True(isValid);
        }

        [Fact]
        public void IsValid_ReturnsFalse_WhenCombinationIsInvalid()
        {
            // Arrange
            Word word1 = new Word("hello");
            Word word2 = new Word("world");
            int lengthOfWord = 10;

            WordCombination wordCombination = new WordCombination(word1, word2, lengthOfWord);
            List<Word> words = new List<Word>
            {
                new Word("helloWorld"),
                new Word("hello"),
                new Word("other"),
            };

            // Act
            bool isValid = wordCombination.IsValid(words);

            // Assert
            Assert.False(isValid);
        }

        [Fact]
        public void ToString_ReturnsExpectedStringRepresentation()
        {
            // Arrange
            Word word1 = new Word("hello");
            Word word2 = new Word("world");
            int lengthOfWord = 10;

            WordCombination wordCombination = new WordCombination(word1, word2, lengthOfWord);

            // Act
            string result = wordCombination.ToString();

            // Assert
            Assert.Equal("helloworld = hello + world", result);
        }
        [Fact]
        public void ReadWordsFromFile_WithNonExistingFile_ReturnsEmptyListOfWords()
        {
            // Arrange
            string nonExistingFilePath = "";
            FileReader fileReader = new FileReader();

            // Act
            List<Word> actualWords = fileReader.ReadWordsFromFile(nonExistingFilePath);

            // Assert
            Assert.Empty(actualWords);
        }
        [Fact]
        public void ReadWordsFromFile_WithExistingFile_ReturnsListOfWords()
        {
            // Arrange
            string textInput = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "Config", "input.txt");
            FileReader fileReader = new FileReader();

            // Act
            List<Word> actualWords = fileReader.ReadWordsFromFile(textInput);

            // Assert
            Assert.NotEmpty(actualWords);
        }
    }
}