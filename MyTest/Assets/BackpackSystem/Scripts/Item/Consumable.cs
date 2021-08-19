using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 消耗品类
/// </summary>
public class Consumable : Item
{
    /// <summary>
    /// 增加的血量
    /// </summary>
    public int HP { get; set; }
    /// <summary>
    /// 增加的法量
    /// </summary>
    public int MP { get; set; }

    /// <summary>
    /// 消耗品类构造函数
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="itemType"></param>
    /// <param name="quality"></param>
    /// <param name="des"></param>
    /// <param name="capacity"></param>
    /// <param name="buyPrice"></param>
    /// <param name="sellPrice"></param>
    /// <param name="hp"></param>
    /// <param name="mp"></param>
    public Consumable(int id, string name, ItemType itemType, ItemQuality quality, string des, int capacity, int buyPrice, int sellPrice,int hp,int mp, string sprite)
        :base(id,name,itemType,quality,des,capacity,buyPrice,sellPrice,sprite)
    {
        this.HP = hp;
        this.MP = mp;
    }
}
