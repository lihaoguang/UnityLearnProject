using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorPalette : MonoBehaviour
{
    //模型读写 纹理读写 添加meshCollider
    Ray ray;
    RaycastHit hit;
    Texture2D texture;
    public Color selectColor;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray,out hit,1000))
            {
                if (hit.collider.tag.Contains("ColorPalette"))
                {
                    Vector2 uv = hit.textureCoord;
                    if (!texture)
                        texture = (Texture2D)hit.transform.gameObject.GetComponent<MeshRenderer>().material.mainTexture;
                    selectColor = texture.GetPixelBilinear(uv.x, uv.y);
                }
            }
        } 
    }
}
