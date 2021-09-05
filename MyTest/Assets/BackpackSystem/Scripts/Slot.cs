using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Slot : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    private ItemUI m_itemUI = null;

    /// <summary>
    /// Get the ItemUI in the current slot
    /// </summary>
    public ItemUI ItemUI => m_itemUI = (m_itemUI ?? GetComponentInChildren<ItemUI>()) ??
        ResourcesLoader.Load(ResourcesLoader.PREFAB_UI_Item, transform).GetComponentInChildren<ItemUI>();

    public Item.ItemType ItemType => m_itemUI == null ? (Item.ItemType)(-1) : ItemUI.Item.Type;
    public int ItemID => m_itemUI == null ? (-1) : ItemUI.Item.ID;




    /// <summary>
    /// Whether the current slot is fill
    /// </summary>
    public bool IsFilled => ItemUI.Amount >= ItemUI.Item.Capacity;

    public void OnPointerEnter(PointerEventData eventData)
    {
        m_itemUI?.ShowTooltip();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        m_itemUI?.HideTooltip();
    }

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
