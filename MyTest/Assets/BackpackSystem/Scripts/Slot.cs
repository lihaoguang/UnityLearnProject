﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slot : MonoBehaviour
{
    private ItemUI m_itemUI = null;

    /// <summary>
    /// Get the ItemUI in the current slot
    /// </summary>
    public ItemUI ItemUI => m_itemUI = (m_itemUI ?? GetComponentInChildren<ItemUI>())?? ResourcesLoader.Load<GameObject,ItemUI>(ResourcesLoader.PREFAB_UI+"Item", transform);

    public Item.ItemType ItemType => ItemUI.Item.Type;

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

    }
}
