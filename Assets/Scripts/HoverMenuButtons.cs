using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverMenuButtons : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    TMP_Text text;
    public Texture2D mouseHoverTexture;

    public void OnPointerEnter(PointerEventData eventData)
    {
        text = gameObject.GetComponentInChildren<TMP_Text>();
        text.outlineWidth = 0.4f;
        text.outlineColor = Color.black;
        Vector2 cursorHotspot = new Vector2(mouseHoverTexture.width / 2, mouseHoverTexture.height / 2);
        Cursor.SetCursor(mouseHoverTexture, cursorHotspot, CursorMode.Auto);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        text = gameObject.GetComponentInChildren<TMP_Text>();
        text.outlineWidth = 0;
        Cursor.SetCursor(null, Vector2.zero, CursorMode.Auto);
    }
}
