using UnityEngine;
using System.Collections;

public class SingletonUtils<T> where T : MonoBehaviour
{
    private static T instance;
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<T>();
            }
            return instance;
        }
    }

    public static T InstanceCreateObject
    {
        get
        {
            if (instance == null)
            {
                instance = GameObject.FindObjectOfType<T>();
                if (instance == null)
                {
                    GameObject newInstance = new GameObject(typeof(T).Name);
                    instance = newInstance.AddComponent<T>();
                }
            }
            return instance;
        }
    }
}
