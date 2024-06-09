using System.Collections.Generic;
using UnityEngine;

public class DataManager
{
    public interface ILoader<Key, Value>
    {
        Dictionary<Key, Value> MakeDict();
    }


    public void Init()
    {

    }

    private Loader LoadJson<Loader, Key, Value>(string path) where Loader : ILoader<Key, Value>
    {
        TextAsset textAsset = Managers.Resource.Load<TextAsset>($"Data/{path}");
        return JsonUtility.FromJson<Loader>(textAsset.text);
    }
}
