using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private List<Slot> slotList;
    private void Start()
    {
        Init();
    }
    protected virtual void Init()
    {
        slotList = new List<Slot>(GetComponentsInChildren<Slot>());
    }

    public bool StoreItem(int id)
    {
        return StoreItem(InventoryManager.Instance.GetItemById(id));
    }

    public bool StoreItem(Item item)
    {
        if (item == null)
        {
            Debug.LogWarning("item ID to be sotred does not exist");
            return false;
        }
        if (item.Capacity == 1)
        {
            if (FindEmptySlot(out Slot slot))
            {
                slot.StoreItem(item);
            }
            else
            {
                Debug.Log("there is no empty slot");
                return false;
            }
        }
        else if (item.Capacity > 1 && FindSameTypeAndValidSlot(item, out Slot slot))
        {
            slot.StoreItem(item);
        }
        else if (FindEmptySlot(out slot))
        {
            slot.StoreItem(item);
        }
        else
        {
            Debug.LogWarning("there are no empty slot");
            return false;
        }
        return true;
    }

    /// <summary>
    /// find for empty slot
    /// </summary>
    /// <returns></returns>
    private bool FindEmptySlot(out Slot slot)
    {
        slot = slotList.Find(s => s.transform.childCount == 0);
        return slot == null ? false : true;
    }

    private bool FindSameTypeAndValidSlot(Item item, out Slot slot)
    {//怎加条件 slot 是否满
        slot = slotList.Find(s => s.transform.childCount >= 1 && s.ItemType == item.Type && !s.IsFilled);
        return slot == null ? false : true;
    }
}
