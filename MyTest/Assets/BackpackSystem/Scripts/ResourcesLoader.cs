using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesLoader
{
    public const string PREFAB_UI_Item = "Prefabs/UI/Item";
    /// <summary>
    /// TODO add Func<T>  How do get TResult from the loaded resources.
    /// heavy load??
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="path"></param>
    /// <param name="parentTF"></param>
    /// <returns></returns>
    public static Transform Load(string path, Transform parentTF)
    {
        Transform result = Load<Transform>(path);
        return Object.Instantiate(result, parentTF);
    }

    public static T Load<T>(string path) where T : UnityEngine.Object
    {
        return Resources.Load<T>(path);
    }

}
