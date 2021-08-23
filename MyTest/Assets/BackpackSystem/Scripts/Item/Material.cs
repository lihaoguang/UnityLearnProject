using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace InventorySystem
{

    /// <summary>
    /// 材料类
    /// </summary>
    public class Material : Item
    {
        /// <summary>
        /// 材料类构造函数
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="itemType"></param>
        /// <param name="quality"></param>
        /// <param name="des"></param>
        /// <param name="capacity"></param>
        /// <param name="buyPrice"></param>
        /// <param name="sellPrice"></param>
        public Material(int id, string name, ItemType itemType, ItemQuality quality, string des, int capacity, int buyPrice, int sellPrice, string sprite)
              : base(id, name, itemType, quality, des, capacity, buyPrice, sellPrice, sprite)
        {


        }
    }
}