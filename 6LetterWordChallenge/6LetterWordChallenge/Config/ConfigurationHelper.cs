using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _6LetterWordChallenge.Config
{
    public class ConfigurationHelper
    {
        
        private readonly IConfiguration configuration;
        public ConfigurationHelper()
        {
            string configFilePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "Config");

            configuration = new ConfigurationBuilder()
                .SetBasePath(configFilePath)
                .AddJsonFile("appsettings.json")
                .Build();
        }
        public IConfiguration GetConfiguration()
        {
            return configuration;
        }
        public string GetInputFilePath()
        {
            string configFilePath = Path.Combine(Directory.GetCurrentDirectory(), "..", "..", "..", "Config");
            return Path.Combine(configFilePath, configuration["FilePath"]);
        }
    }
}
