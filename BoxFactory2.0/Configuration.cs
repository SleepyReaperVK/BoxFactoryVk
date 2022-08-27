using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxFactory2._0
{
    public class Configuration
    {
        public ConfigData Data { get; set; }

        public Configuration()
        {
            //
            var currentDir = AppContext.BaseDirectory;
           
            var fileName = "configuration.json";
            var configPath = Path.Combine(currentDir, fileName);
            var raw = File.ReadAllText(configPath);
            Data = JsonConvert.DeserializeObject<ConfigData>(raw);
        }

        public void update(ConfigData data)
        {
            var currentDir = Environment.CurrentDirectory;
            var fileName = "configuration.json";
            var configPath = Path.Combine(currentDir, fileName);
            var tempData = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText(configPath, tempData);
        }

        public class ConfigData
        {
            public int MaxBoxes { get; set; }
            public string Foo { get; set; }
            public double XXXXXXXXX { get; set; }
        }
    }
}
