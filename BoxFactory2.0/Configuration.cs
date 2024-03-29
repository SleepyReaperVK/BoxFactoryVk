﻿using Newtonsoft.Json;
using BoxFactory;
using System;
using System.Collections.Generic;
using System.IO;
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
            var currentDir = Environment.CurrentDirectory;
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
            var tempData = JsonConvert.SerializeObject(data);
            File.WriteAllText(configPath, tempData);
        }
    }

        public class ConfigData
        {
            public int MaxBoxes { get; set; }
            public int MinBoxes { get; set; }
            public xtree DataXTree { get; set; }
        }
    }
