using Newtonsoft.Json;
using System;
using System.IO;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader jsonLoader = new StreamReader(@"..\..\..\ConfigSettings.json"))
            {
                string json = jsonLoader.ReadToEnd();

                var myDeserializedClass = JsonConvert.DeserializeObject<ConfigSettingsDeserialized>(json);
                ParseCsFiles(myDeserializedClass);
            }
        }

        private static void ParseCsFiles(ConfigSettingsDeserialized myDeserializedClass)
        {
            var oldProjectDirectory = @"F:\MigrationProjects\WebApiToCoreMigration-master\SimpleWebApi";
            string[] filePaths = Directory.GetFiles(oldProjectDirectory, "*.cs",
                                         SearchOption.AllDirectories);
            foreach (var filePath in filePaths)
            {
                using (StreamReader reader = new StreamReader($@"{filePath}"))
                {
                    string textContent = reader.ReadToEnd();
                    string newTextContent = textContent.Replace("System.Web", "Microsoft.AspNetCore.Mvc");
                    System.IO.File.WriteAllText(@"F:\MigrationProjects\TestFiles\HomeController.cs", newTextContent);



                }
            }
            
        }
    }
}
