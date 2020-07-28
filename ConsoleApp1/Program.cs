using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;

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

            var replacers = myDeserializedClass.GeneralConfig.FileConfigs.Where(x => x.FileExtension == "cs").Select(x => x.Replacers).FirstOrDefault();
            int i = 1;
            foreach (var filePath in filePaths)
            {
                using (StreamReader reader = new StreamReader($@"{filePath}"))
                {
                    string textContent = reader.ReadToEnd();
                    
                    foreach (var replacer in replacers)
                    {
                        textContent = textContent.Replace(replacer.ActualCode, replacer.ReplacingCode);
                    }
                    i++;
                    System.IO.File.WriteAllText(@$"F:\MigrationProjects\TestFiles\HomeController{i}.cs", textContent);



                }
            }
            
        }
    }
}
