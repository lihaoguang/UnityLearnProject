using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : Item
{
    /// <summary>
    /// 攻击力
    /// </summary>
    public int Damage { get; set; }
    /// <summary>
    /// 武器类型
    /// </summary>
    public WeaponType wpType;

    /// <summary>
    /// 武器类构造函数
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="itemType"></param>
    /// <param name="quality"></param>
    /// <param name="des"></param>
    /// <param name="capacity"></param>
    /// <param name="buyPrice"></param>
    /// <param name="sellPrice"></param>
    /// <param name="damage"></param>
    /// <param name="weaponType"></param>
    public Weapon(int id, string name, ItemType itemType, ItemQuality quality, string des, int capacity, int buyPrice,int sellPrice, string sprite
        ,int damage, WeaponType weaponType)
     : base(id, name, itemType, quality, des, capacity, buyPrice, sellPrice,sprite)
    {
        this.Damage = damage;
        this.wpType = weaponType;
    }
    public enum WeaponType
    {
        OffHand,
        MainHand

    }
}
