using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Singleton<T> : MonoBehaviour where T : Component
{
    public static T Instance { get; private set; }

    public virtual void Awake()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        else Instance = this as T;
    }
}

public abstract class SingletonPersitant<T> : MonoBehaviour where T : Component
{
    public static T Instance { get; private set; }

    public virtual void Awake()
    {
        if (Instance != null && Instance != this) Destroy(gameObject);
        else
        {
            Instance = this as T;
            DontDestroyOnLoad(gameObject);
        }
    }
}
