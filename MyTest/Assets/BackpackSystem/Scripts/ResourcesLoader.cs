using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesLoader
{
    public const string PREFAB_UI = "Prefabs/UI/";
    /// <summary>
    /// TODO add Func<T>  How do get TResult from the loaded resources.
    /// heavy load??
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <typeparam name="TResult"></typeparam>
    /// <param name="path"></param>
    /// <param name="parentTF"></param>
    /// <returns></returns>
    public static TResult Load<T, TResult>(string path, Transform parentTF) where T : UnityEngine.Object where TResult : MonoBehaviour
    {
        T loadObjcet = Resources.Load<T>(path);
        if (loadObjcet.GetType().Equals(typeof(GameObject)))
            return Object.Instantiate(loadObjcet as GameObject, parentTF).GetComponentInChildren<TResult>();
        return loadObjcet as TResult;
    }
}
