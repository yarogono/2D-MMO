using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

internal class Pool
{
    private GameObject _prefab;
    private IObjectPool<GameObject> _pool;

    private Transform _root;
    private Transform Root
    {
        get
        {
            if (_root == null)
            {
                GameObject gameObject = new GameObject() { name = $"@{_prefab.name}Pool" };
                _root = gameObject.transform;
            }

            return _root;
        }
    }

    public Pool(GameObject prefab)
    {
        _prefab = prefab;
        _pool = new ObjectPool<GameObject>(OnCreate, OnGet, OnRelease, OnDestroy);
    }

    public void Push(GameObject gameObject)
    {

    }

    public GameObject Pop()
    {
        return _pool.Get();
    }

    #region Funcs
    private GameObject OnCreate()
    {
        GameObject gameObject = GameObject.Instantiate(_prefab);
        gameObject.transform.SetParent(Root);
        gameObject.name = _prefab.name;
        return gameObject;
    }

    private void OnGet(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }

    private void OnRelease(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy(GameObject gameObject)
    {
        GameObject.Destroy(gameObject);
    }
    #endregion
}

public class PoolManager
{
    private Dictionary<string, Pool> _pools = new Dictionary<string, Pool>();

    public GameObject Pop(GameObject prefab)
    {
        if (_pools.ContainsKey(prefab.name) == false)
            CreatePool(prefab);

        return _pools[prefab.name].Pop();
    }

    public bool Push(GameObject gameObject)
    {
        if (_pools.ContainsKey(gameObject.name) == false)
        {
            return false;
        }

        _pools[gameObject.name].Push(gameObject);
        return true;
    }

    public void Clear()
    {
        _pools.Clear();
    }

    private void CreatePool(GameObject original)
    {
        Pool pool = new Pool(original);
        _pools.Add(original.name, pool);
    }

}
