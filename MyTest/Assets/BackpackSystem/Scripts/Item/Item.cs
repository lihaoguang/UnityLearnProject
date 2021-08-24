using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 物品基类
/// </summary>
public class Item
{
    /// <summary>
    /// 物品ID
    /// </summary>
    public int ID { get; set; }
    /// <summary>
    /// 物品名
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// 物品类型
    /// </summary>
    public ItemType Type { get; set; }
   /// <summary>
   /// 物品品质
   /// </summary>
    public ItemQuality Quality { get; set; }
    /// <summary>
    /// 物品的描述
    /// </summary>
    public string Description { get; set; }
    /// <summary>
    /// 物品占据的容量
    /// </summary>
    public int Capacity { get; set; }
    /// <summary>
    /// 物品的购买价格
    /// </summary>
    public int BuyPrice { get; set; }
    /// <summary>
    /// 物品的出售价格
    /// </summary>
    public int SellPrice { get; set; }
    /// <summary>
    /// 物品Icon的路径
    /// </summary>
    public string Sprite { get; set; }

    /// <summary>
    /// Item构造函数
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="itemType"></param>
    /// <param name="quality"></param>
    /// <param name="des"></param>
    /// <param name="capacity"></param>
    /// <param name="buyPrice"></param>
    /// <param name="sellPrice"></param>
    public Item(int id,string name,ItemType itemType, ItemQuality quality,string des,int capacity,int buyPrice,int sellPrice,string sprite)
    {
        this.ID = id;
        this.Name = name;
        this.Type = itemType;
        this.Quality = quality;
        this.Description = des;
        this.Capacity = capacity;
        this.BuyPrice = buyPrice;
        this.SellPrice = sellPrice;
        this.Sprite = sprite;
    }


    /// <summary>
    /// 物品类型
    /// </summary>
    public enum ItemType
    {
        Consumable,
        Equipment,
        Weapon,
        Material
    }

    /// <summary>
    /// 品质
    /// </summary>
    public enum ItemQuality
    {
        Common,
        Uncommon,
        Rare,
        Epic,
        Legendary,
        Artifact

    }
}
