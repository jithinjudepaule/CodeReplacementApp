using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
   
    

    public class ConfigSettingsDeserialized
    {
        public GeneralConfig GeneralConfig { get; set; }
        public List<ProjectConfig> ProjectConfigs { get; set; }

    }

    public class ProjectConfig
    {
        public string ProjectType { get; set; }
        public object NotRequireFiles { get; set; }
        public object NotRequiredDir { get; set; }
        public object FileConfigs { get; set; }
        public List<FileAddition> FileAdditions { get; set; }

    }

    public class GeneralConfig
    {
        public object ProjectType { get; set; }
        public List<NotRequireFile> NotRequireFiles { get; set; }
        public List<NotRequiredDir> NotRequiredDir { get; set; }
        public List<FileConfig> FileConfigs { get; set; }
        public object FileAdditions { get; set; }

    }

    public class FileConfig
    {
        public string FileExtension { get; set; }
        public object FileName { get; set; }
        public bool isRegex { get; set; }
        public List<Replacer> Replacers { get; set; }

    }

    public class Replacer
    {
        public string ActualCode { get; set; }
        public string ReplacingCode { get; set; }
        public bool isRegex { get; set; }

    }
    public class FileAddition
    {
        public string FileName { get; set; }
        public object FolderPath { get; set; }
        public string FileRepoPath { get; set; }

    }
    public class NotRequireFile
    {
        public string Item1 { get; set; }
        public string Item2 { get; set; }

    }

    public class NotRequiredDir
    {
        public string Item1 { get; set; }
        public string Item2 { get; set; }

    }

  

  

   


}
