using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 装备类
/// </summary>
public class Equipment : Item
{
    /// <summary>
    /// 力量
    /// </summary>
    public int Strength { get; set; }
    /// <summary>
    /// 智力
    /// </summary>
    public int Intellect { get; set; }
    /// <summary>
    /// 敏捷
    /// </summary>
    public int Agility { get; set; }
    /// <summary>
    /// 体力
    /// </summary>
    public int Stamina { get; set; }
    /// <summary>
    /// 装备类型
    /// </summary>
    public EquipmentType EquipType { get; set; }

    /// <summary>
    /// 装备类构造函数
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="itemType"></param>
    /// <param name="quality"></param>
    /// <param name="des"></param>
    /// <param name="capacity"></param>
    /// <param name="buyPrice"></param>
    /// <param name="sellPrice"></param>
    /// <param name="strength"></param>
    /// <param name="intellect"></param>
    /// <param name="agility"></param>
    /// <param name="stamina"></param>
    /// <param name="equipType"></param>
    public Equipment(int id, string name, ItemType itemType, ItemQuality quality, string des, int capacity, int buyPrice,int sellPrice, string sprite
        ,int strength,int intellect,int agility,int stamina,EquipmentType equipType)
         : base(id, name, itemType, quality, des, capacity, buyPrice, sellPrice,sprite)
    {
        this.Strength = strength;
        this.Intellect = intellect;
        this.Agility = agility;
        this.Stamina = stamina;
        this.EquipType = equipType;
    }

   /// <summary>
   /// 装备类型
   /// </summary>
    public enum EquipmentType
    {
        /// <summary>
        /// 头部
        /// </summary>
        Head,
        /// <summary>
        /// 脖子
        /// </summary>
        Neck,
        /// <summary>
        /// 肩膀
        /// </summary>
        Shoulder,
        /// <summary>
        /// 胸
        /// </summary>
        Chest,
        /// <summary>
        /// 腰带
        /// </summary>
        Belt,
        /// <summary>
        /// 护腕
        /// </summary>
        Bracer,
        /// <summary>
        /// 戒指
        /// </summary>
        Ring,
        /// <summary>
        /// 腿
        /// </summary>
        Leg,
        /// <summary>
        /// 靴子
        /// </summary>
        Boots,
        /// <summary>
        /// 饰品
        /// </summary>
        Trinket,
        /// <summary>
        /// 副手
        /// </summary>
        OffHand
    }
}
