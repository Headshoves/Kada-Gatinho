using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoSingleton<T>
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (!_instance)
            {
                var objs = FindObjectsOfType(typeof(T)) as T[];

                if (objs.Length > 0)
                    _instance = objs[0];
                else
                {
                    GameObject obj = new GameObject();
                    obj.name = typeof(T).Name;
                    _instance = obj.AddComponent<T>();
                }
            }

            return _instance;
        }
    }

    protected virtual void Awake()
    {
        if (_instance != null)
        {
            var objs = FindObjectsOfType(typeof(T)) as T[];

            foreach (var item in objs)
            {
                if (item != _instance)
                {
                    Destroy(item);
                }
            }

            return;
        }

        _instance = this as T;
        DontDestroyOnLoad(this.gameObject);
    }
}
