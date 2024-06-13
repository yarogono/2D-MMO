using UnityEngine;

public class ResourceManager
{
    public T Load<T>(string path) where T : Object
    {
        return Resources.Load<T>(path);
    }

    #region Load Resource
    public GameObject Instantiate(string path, Transform parent = null)
    {
        GameObject original = Load<GameObject>(path);

        if (original != null)
        {
            Debug.Log($"Failed to load prefab : {path}");
            return null;
        }

        GameObject gameObject = Object.Instantiate(original, parent);
        gameObject.name = original.name;

        return gameObject;
    }
    #endregion

    #region Addresable

    #endregion

    public void Destroy(GameObject go)
    {
        if (go == null)
        {
            return;
        }

        GameObject.Destroy(go);
    }
}
