using _6LetterWordChallenge.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace _6LetterWordChallenge.Tests
{
    public class WordChallengeTest
    {
        string jsonPath = "C:\\Users\\Arne\\source\\repos\\6LetterWordChallenge\\6LetterWordChallenge\\Config";

        [Fact]
        public void Configuration_FilePathExists()
        {
            // Arrange
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(jsonPath)
                .AddJsonFile("appsettings.json")
                .Build();

            // Act
            string filePath = configuration["FilePath"];

            // Assert
            Assert.False(string.IsNullOrEmpty(filePath));
            Assert.True(File.Exists(filePath));
        }

        [Fact]
        public void FindCombination_ReturnsAUniqueCombination()
        {
            // Arrange
            var words = new List<Word>
            {
                new Word("apple"),
                new Word("b"),
                new Word("banana"),
                new Word("cherry"),
                new Word("appleb")
            };

            var wordFinder = new WordFinder(words);

            // Act
            var combinations = wordFinder.FindCombinations();

            //Should return a single combination (apple+b = appleb)
            // Assert
            Assert.Single(combinations);
        }
        [Fact]
        public void FindCombinations_ReturnsUniqueCombinations()
        {
            // Arrange
            var words = new List<Word>
            {
                new Word("apple"),
                new Word("a"),
                new Word("b"),
                new Word("c"),
                new Word("banana"),
                new Word("cherry"),
                new Word("applea"),
                new Word("appleb"),
                new Word("applec")
            };

            var wordFinder = new WordFinder(words);

            // Act
            var combinations = wordFinder.FindCombinations();

            //Should return 3 combinations (apple + a = applea / apple+b = appleb /apple+c = applec)
            // Assert
            Assert.Equal(3, combinations.Count);
        }
    }
}