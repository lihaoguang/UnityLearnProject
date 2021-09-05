using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyText : Text
{

    public override void SetVerticesDirty()
    {
        //Debug.Log(m_Text);
        base.SetVerticesDirty();
    } 

    protected override void OnPopulateMesh(VertexHelper toFill)
    {
        m_DisableFontTextureRebuiltCallback = true;

        TextGenerationSettings settings = GetGenerationSettings(rectTransform.rect.size);

        cachedTextGenerator.PopulateWithErrors("LHH", settings, gameObject);

        float unitsPerPixel = 1 / pixelsPerUnit;

        m_DisableFontTextureRebuiltCallback = false;
    }

    private void SetImage()
    { 
    
    }
}
