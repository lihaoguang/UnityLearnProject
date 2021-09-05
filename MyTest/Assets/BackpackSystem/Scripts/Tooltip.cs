using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tooltip : MonoBehaviour
{
    public float topBottomSpacing = 20;

    private RectTransform _containerRectTransform = null;
    private RectTransform ContainerRectTransform => _containerRectTransform ?? (_containerRectTransform = transform.parent.GetComponent<RectTransform>());

    private RectTransform _tooltipTextRectTransform = null;
    private RectTransform TooltipTextRectTransform => _tooltipTextRectTransform ?? (_tooltipTextRectTransform = gameObject.GetComponent<RectTransform>());

    private Text _tooltip = null;
    private Text TooltipText => _tooltip ?? (_tooltip = GetComponent<Text>());

    private CanvasGroup _canvasGroup = null;
    private CanvasGroup TooltipCanvasGroup
    {
        get
        {
            if (_canvasGroup == null)
                _canvasGroup = ContainerRectTransform.GetComponent<CanvasGroup>();
            if (_canvasGroup == null)
                _canvasGroup = ContainerRectTransform.gameObject.AddComponent<CanvasGroup>();
            return _canvasGroup;
        }
    }

    private float _targetAlpha = 0;
    private float _smoothing = 5;
    public void Show(string content)
    {
        _targetAlpha = 1;
        TooltipText.text = content;
        Invoke("SetTooltip", 0.02f);
    }

    public void Hide()
    {
        _targetAlpha = 0;
    }

    private void Update()
    {
        if (!Mathf.Approximately(TooltipCanvasGroup.alpha, _targetAlpha))
        {
            TooltipCanvasGroup.alpha = Mathf.Lerp(TooltipCanvasGroup.alpha, _targetAlpha, _smoothing * Time.deltaTime);
            if (Mathf.Abs(TooltipCanvasGroup.alpha - _targetAlpha) <= 0.05f)
                TooltipCanvasGroup.alpha = _targetAlpha;
        }
    }

    [ContextMenu("SetTooltioSize")]
    private void SetTooltip()
    {
        //Vector2 selfSize = new Vector2(TooltipTextRectTransform.rect.x, TooltipTextRectTransform.rect.y);
        //float selfHeight = Mathf.Abs(selfSize.y * 2) + topBottomSpacing;
        //(transform.parent as RectTransform).sizeDelta = new Vector2(100, selfHeight);
        //ContainerRectTransform.sizeDelta = new Vector2(ContainerRectTransform.sizeDelta.x, selfHeight);
        ContainerRectTransform.sizeDelta = TooltipTextRectTransform.sizeDelta + Vector2.one * topBottomSpacing;
        ContainerRectTransform.position = Input.mousePosition;
    }
}

