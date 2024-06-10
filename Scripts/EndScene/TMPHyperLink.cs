using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class TMProHyperLink : MonoBehaviour, IPointerClickHandler
{
    TextMeshProUGUI m_TextMeshPro;
    Camera m_Camera;
    Canvas m_Canvas;

    void Start()
    {
        m_Camera = Camera.main;

        m_Canvas = gameObject.GetComponentInParent<Canvas>();
        if (m_Canvas.renderMode == RenderMode.ScreenSpaceOverlay)
            m_Camera = null;
        else
            m_Camera = m_Canvas.worldCamera;

        m_TextMeshPro = gameObject.GetComponent<TextMeshProUGUI>();
        m_TextMeshPro.ForceMeshUpdate();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        int linkIndex = TMP_TextUtilities.FindIntersectingLink(m_TextMeshPro, Input.mousePosition, m_Camera);

        if (linkIndex != -1)
        {
            TMP_LinkInfo linkInfo = m_TextMeshPro.textInfo.linkInfo[linkIndex];
            Application.OpenURL("https://papago.naver.com/?sk=auto&tk=ko&st=%E8%84%B1%E5%87%BA%E3%81%AE%E3%81%9F%E3%82%81%E3%81%AB%0A%E6%82%AA%E9%AD%94%E3%81%AE%E5%8A%9B%E3%82%92%E5%80%9F%E3%82%8A%E3%81%9F%E7%A7%81%E3%81%AF%0A%E3%81%84%E3%82%8D%E3%82%93%E3%81%AA%E6%AC%B2%E6%9C%9B%E3%81%AB%E5%8C%85%E3%81%BE%E3%82%8C%0A%E7%BD%AA%E3%82%92%E7%8A%AF%E3%81%97%E3%81%A6%E3%81%97%E3%81%BE%E3%81%86");
        }
    }
}
