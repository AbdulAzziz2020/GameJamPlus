using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : Singleton<ObjectPooling>
{
    #region Singleton

    public override void Awake()
    {
        base.Awake();
    }

    #endregion

    public void InitPool<T>(int size, T prefab, List<T> list, Transform parent) where T : Component
    {
        for (int i = 0; i < size; i++)
        {
            T obj = Instantiate(prefab, parent);
            obj.gameObject.SetActive(false);
            list.Add(obj);
        }
    }

    public T GetObjectInPool<T>(List<T> list) where T : Component
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (!list[i].gameObject.activeInHierarchy) return list[i];
        }

        return null;
    }

    public void SetActiveGameObject<T>(List<T> list, Transform origin) where  T : Component
    {
        T obj = GetObjectInPool<T>(list);
        if (obj != null)
        {
            transform.position = origin.position;
            obj.gameObject.SetActive(true);
        }
    }
}
