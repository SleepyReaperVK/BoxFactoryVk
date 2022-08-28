using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxFactory.Logi
{
    public class Configuration
    {
        public ConfigData Data { get; set; }

        public Configuration()
        {
            var currentDir = Environment.CurrentDirectory;
            var fileName = "configuration.json";
            var configPath = Path.Combine(currentDir, fileName);
            var raw = File.ReadAllText(configPath);
            Data = JsonConvert.DeserializeObject<ConfigData>(raw);
        }
    }

    public class ConfigData
    {
        public int MaxBoxes { get; set; }
        public string Foo { get; set; }
        public double XXXXXXXXX { get; set; }
    }
}
