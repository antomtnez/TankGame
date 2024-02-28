using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilePool : MonoBehaviour
{
    public static ProjectilePool Instance;

    [SerializeField]
    protected GameObject objectPrefab;
    protected int initialPoolSize = 2;

    public bool projectileActive { get; private set; } = false;
    private Queue<GameObject> pool = new Queue<GameObject>();

    public event Action OnProjectileReturned;

    void Awake()
    {
        Instance = this;
        AddObjectsToPool(initialPoolSize);
    }

    void AddObjectsToPool(int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject newObject = Instantiate(objectPrefab);
            newObject.SetActive(false);
            pool.Enqueue(newObject);
        }
    }

    public GameObject GetObject()
    {
        if (pool.Count == 0)
        {
            AddObjectsToPool(1);
        }

        GameObject go = pool.Dequeue();
        go.SetActive(true);
        projectileActive = true;
        return go;
    }

    public void ReturnObject(GameObject go)
    {
        go.SetActive(false);
        projectileActive = false;
        pool.Enqueue(go);
        OnProjectileReturned();
    }
}