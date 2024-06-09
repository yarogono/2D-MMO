using UnityEngine;

public class ResourceManager
{
    public T Load<T>(string path) where T : Object
    {
        T t = Resources.Load<T>(path);
        return t;
    }
}
