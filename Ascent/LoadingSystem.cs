﻿using System.Text.Json;
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
using Ascent.Tiles;

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
            JsonSaveData = JsonConvert.SerializeObject(GameLoop.GameDataManager, settings);
            File.WriteAllText(FilePath, JsonSaveData);
        }

        public static void LoadGameFromJson()
        {
            // read file into a string and deserialize JSON to a type
            var FilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "SaveFile.json");
            Hud.MapConsole.Children.Clear();            
            GameLoop.GameDataManager = JsonConvert.DeserializeObject<GameDataManager>(File.ReadAllText(FilePath));
            RefreshConsolesAfterLoading();
        }

        private static void RefreshConsolesAfterLoading()
        {
            MapGenerator.LoadMap();
            Hud.MapConsole.Children.Add(GameLoop.GameDataManager.Player);
            for (int i = 0; i < GameLoop.GameDataManager.Stairs.Count; i++)
            {
                Hud.MapConsole.Children.Add(GameLoop.GameDataManager.Stairs[i]);
            }
            if (GameLoop.GameDataManager.Enemies != null)
            {
                for (int i = 0; i < GameLoop.GameDataManager.Enemies.Count; i++)
                {
                    Hud.MapConsole.Children.Add(GameLoop.GameDataManager.Enemies[i]);
                }
            }
        }

        public static void NewGameOverWriteJson()
        {
            throw new NotImplementedException();
        }
    }
}