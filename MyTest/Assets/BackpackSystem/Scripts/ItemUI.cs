using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public Item Item { get; private set; }

    public uint Amount { get; private set; }

    private Image m_iconImage;
    private Image IconImage => m_iconImage ?? (m_iconImage = GetComponent<Image>());

    private Text m_itemInfoText;
    private Text ItemInfoText => m_itemInfoText ?? (m_itemInfoText = transform.Find("info").GetComponent<Text>());
    //Add add function and delete function.


    public void AddItem(Item item, uint amount = 1)
    {
        Amount += amount;
        ItemInfoText.enabled = item.Capacity > 1;
        if (ItemInfoText.enabled)
        ItemInfoText.text = Amount.ToString();
        if (Item != null) return;
        Item = item;
        IconImage.sprite = ResourcesLoader.Load<Sprite>(Item.Sprite);
    }

    public void ShowTooltip()
    {
        InventoryManager.Instance.ShowTooltip(Item.TooltipsText);
    }

    public void HideTooltip()
    {
        InventoryManager.Instance.HideTooltip();
    }
}
