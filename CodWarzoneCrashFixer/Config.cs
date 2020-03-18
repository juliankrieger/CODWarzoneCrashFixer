using System;
using System.IO;
using Newtonsoft.Json;

namespace CodWarzoneCrashFixer {
    public struct Config  {

        public Config(String configPath=null, bool enabled=false) {
            ConfigPath = configPath;
            Enabled = enabled;
        }

        public static void Init() {
            if (!System.IO.Directory.Exists(RootPath)) {
                DirectoryInfo info = System.IO.Directory.CreateDirectory(
                    RootPath
                );
            }
            
            if (!System.IO.File.Exists(ConfigFile)) {
                FileStream stream = System.IO.File.Create(
                    ConfigFile
                );
                
                stream.Close();
            }
        }
        
        public string ConfigPath { get; set; }
        public bool Enabled { get; set; }
        
        private static readonly string RootPath = System.IO.Path.Combine(
            Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
            "ModernWarfareCrashFixer");

        private static readonly string ConfigFile = System.IO.Path.Combine(
            RootPath,
            "config.json"
        );

        public static string GetConfigFilePath() {
            return ConfigFile;
        }

        public static void WriteConfig(Config config) {
            System.IO.File.WriteAllText(ConfigFile, string.Empty);
            System.IO.File.WriteAllText(ConfigFile, JsonConvert.SerializeObject(config));
        }
        
        public static Config GetConfig() {


            string content = System.IO.File.ReadAllText(ConfigFile);
            Config config = JsonConvert.DeserializeObject<Config>(content);
            return config;
        }
    }
}