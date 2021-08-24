using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using LitJson;
using System;

/// <summary>
/// 物品管理器
/// </summary>
public class InventoryManager : MonoBehaviour
{
    #region 单例模式
    private static InventoryManager _instance;
    public static InventoryManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = GameObject.FindObjectOfType<InventoryManager>();
                if (_instance == null)
                    _instance = new GameObject("InventoryManager").AddComponent<InventoryManager>();
            }
            return _instance;
        }
    }
    #endregion

    /// <summary>
    /// 物品信息集合
    /// </summary>
    private List<Item> itemList;
    /// <summary>
    /// 解析物品Json文件
    /// </summary>

    private void Start()
    {
        ParseItemJson();
    }
    private void ParseItemJson()
    {
        itemList = new List<Item>();
        string itemJson = LoadJsonText("Items.json");
        Debug.Log(itemJson.Length);
        JsonData jsonData = JsonMapper.ToObject(itemJson);
        Debug.Log(jsonData.Count);

        // Debug.Log(jsonData["type"]);
        foreach (JsonData jsonItem in jsonData)
        {
            int id = int.Parse(jsonItem["id"].ToString());
            string name = jsonItem["name"].ToString();
            Item.ItemType type = (Item.ItemType)Enum.Parse(typeof(Item.ItemType), jsonItem["type"].ToString());
            Item.ItemQuality quality = (Item.ItemQuality)Enum.Parse(typeof(Item.ItemQuality), jsonItem["quality"].ToString());
            string description = jsonItem["description"].ToString();
            int capacity = int.Parse(jsonItem["capacity"].ToString());
            int buyPrice = int.Parse(jsonItem["buyPrice"].ToString());
            int sellPrice = int.Parse(jsonItem["sellPrice"].ToString());
            string sprite = jsonItem["sprite"].ToString();
            Debug.Log(sprite);
            Item itemTemp = null;
            switch (type)
            {
                case Item.ItemType.Consumable:
                    int hp = int.Parse(jsonItem["hp"].ToString());
                    int mp = int.Parse(jsonItem["mp"].ToString());
                    itemTemp = new Consumable(id, name, type, quality, description, capacity, buyPrice, sellPrice, hp, mp, sprite);
                    break;
                case Item.ItemType.Equipment:
                    int strength = int.Parse(jsonItem["strength"].ToString());
                    int intellect = int.Parse(jsonItem["intellect"].ToString());
                    int agility = int.Parse(jsonItem["agility"].ToString());
                    int stamina = int.Parse(jsonItem["stamina"].ToString());
                    Equipment.EquipmentType equipType = (Equipment.EquipmentType)Enum.Parse(typeof(Equipment.EquipmentType), jsonItem["equipType"].ToString());
                    itemTemp = new Equipment(id, name, type, quality, description, capacity, buyPrice, sellPrice, sprite, strength, intellect, agility, stamina, equipType);
                    break;
                case Item.ItemType.Weapon:
                    int damage = int.Parse(jsonItem["damage"].ToString());
                    Weapon.WeaponType weaponType = (Weapon.WeaponType)Enum.Parse(typeof(Weapon.WeaponType), jsonItem["weaponType"].ToString());
                    itemTemp = new Weapon(id, name, type, quality, description, capacity, buyPrice, sellPrice, sprite, damage, weaponType);
                    break;
                case Item.ItemType.Material:
                    itemTemp = new InventorySystem.Material(id, name, type, quality, description, capacity, buyPrice, sellPrice, sprite);
                    break;
                default:
                    break;
            }
            itemList.Add(itemTemp);
            //  Debug.Log(id + name + type + quality + description + capacity +"-"+ buyPrice + "-" + sellPrice + "-" + hp + "-" + mp + "-" + sprite);

        }
    }

    public Item GetItemById(int id)
    {
        return itemList.Find(i => i.ID == id);
    }


    /// <summary>
    /// 加载StreamingAssets
    /// </summary>
    /// <param name="fileName"></param>
    /// <returns></returns>
    public string LoadJsonText(string fileName)
    {
        string url;
        string result = null;
        // string url = "file://" + Application.streamingAssetsPath + "/" + fileNmae;
#if UNITY_EDITOR || UNITY_STANDALONE  //dataPath直接定位到Assets文件夹
        //  url = "file://" + Application.dataPath + "/StreamingAssets/Json/" + fileName;
        url = Application.dataPath + "/StreamingAssets/Json/" + fileName;
        //否在如果在IOS下 #elif = else if()
#elif UNITY_IPHONE
        url = "file://" + Application.dataPath + "/Raw/Json/"+ fileName;
        //否则在Android下
#elif UNITY_ANDROID
        url = "jar:file://" + Application.dataPath + "!/assets/Json/"+ fileName;
#endif
        Debug.Log(url);
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            UnityWebRequestAsyncOperation unityWebRequestAsyncOperation = www.SendWebRequest();
            //while (true)
            //{
            //    if (www.isNetworkError)
            //    {
            //        Debug.Log(www.error);
            //        return null;
            //    }
            //    else
            //    {
            //        result = www.downloadHandler.text;
            //        return result;
            //    }
            //}
            while (true)
            {
                if (unityWebRequestAsyncOperation.isDone)
                {
                    Debug.Log(unityWebRequestAsyncOperation.progress);
                    return unityWebRequestAsyncOperation.webRequest.downloadHandler.text;
                }
            }
        }
    }
}
