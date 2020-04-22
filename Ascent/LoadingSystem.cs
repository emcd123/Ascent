using System.Text.Json;
using System.Text.Json.Serialization;
using System;
using System.IO;
using Ascent;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using Ascent.Entities;
using SadConsole.Entities;

namespace MyProject
{
    public class LoadingSystem
    {
        public static void SaveGameToFileJson()
        {
            var FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SaveFile.json");
            JsonSerializerSettings settings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented,
            };
            string JsonSaveData;
            JsonSaveData = JsonConvert.SerializeObject(GameLoop.GameDataManager.Player);
            File.WriteAllText(FilePath, JsonSaveData);
            var Player = JsonConvert.DeserializeObject<Player>(JsonSaveData);
        }

        public static void LoadGameFromJson()
        {
            throw new NotImplementedException();
        }

        public static void NewGameOverWriteJson()
        {
            throw new NotImplementedException();
        }
    }
}