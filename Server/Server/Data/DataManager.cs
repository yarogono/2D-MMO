﻿namespace Server.Data
{
    public class DataManager
    {
        public static Dictionary<long, Data.Test> TestDict { get; private set; } = new();

        public static void LoadData()
        {
            TestDict = LoadJson<Data.TestData, long, Test>("TestData").MakeDict();
        }

        private static Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
        {
            if (File.Exists($"{path}.json") == false)
            {
                throw new Exception($"DataManager : {path}.json not exist");
            }

            string text = File.ReadAllText($"{path}.json");
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Loader>(text);
        }
    }
}
