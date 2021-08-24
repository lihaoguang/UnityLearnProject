using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private ItemUI m_itemUI = null;

    /// <summary>
    /// Get the ItemUI in the current slot
    /// </summary>
    public ItemUI ItemUI => m_itemUI = (m_itemUI ?? GetComponentInChildren<ItemUI>()) ??
        ResourcesLoader.Load(ResourcesLoader.PREFAB_UI_Item, transform).GetComponentInChildren<ItemUI>();

    public Item.ItemType ItemType => m_itemUI == null ? (Item.ItemType)(-1) : ItemUI.Item.Type;


    /// <summary>
    /// Whether the current slot is fill
    /// </summary>
    public bool IsFilled => ItemUI.Amount >= ItemUI.Item.Capacity;

    /// <summary>
    /// Update itemUI information for existing items/Generated if no itemUI exists
    /// </summary>
    /// <param name="item"></param>
    public void StoreItem(Item item)
    {
        //uint addCount = addAmount - JudgeBeyondCapacityCount(addAmount);
        ItemUI.AddItem(item);
    }
    // Determine or compare the sum of the added number and current number with the maximum capacity Match.Clamp()！！
    private uint JudgeBeyondCapacityCount(uint addAmount)
    {
        uint count = ItemUI.Amount + addAmount;
        uint outnumber = (uint)(count - ItemUI.Item.Capacity);
        return (uint)Mathf.Clamp(outnumber, 0, uint.MaxValue);
    }
}
