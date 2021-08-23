using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUI : MonoBehaviour
{
    public Item Item { get; set; }

    public uint Amount { get;private set; }

    private Image m_iconImage;
    private Image IconImage => m_iconImage ?? (m_iconImage = GetComponent<Image>());

    private Text m_itemInfoText;
    private Text ItemInfoText => m_itemInfoText ?? (m_itemInfoText = transform.Find("info").GetComponent<Text>());
    //Add add function and delete function.
   

    public void AddItem(Item item,uint amount = 1)
    {
        //if (!IconImage.sprite)
        //    IconImage.sprite = item.Sprite
        Amount += amount;
        ItemInfoText.text = Amount.ToString();
    }
}
