using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashImage
{
    GameObject m_flashOBJ;
    Image m_flashIMG;
    float m_flashSpeed = 0.01f;
    public FlashImage()
    {
        m_flashOBJ = GameObject.Instantiate(Resources.Load("FlashImage") as GameObject, Vector3.zero, Quaternion.identity);
        m_flashIMG = m_flashOBJ.GetComponent<Image>();
        m_flashOBJ.transform.SetParent(GameObject.Find("Canvas").transform);
        m_flashOBJ.GetComponent<RectTransform>().pivot = new Vector2(0.0f, 1.0f);
        m_flashOBJ.GetComponent<RectTransform>().anchorMin = new Vector2(0.0f, 1.0f);
        m_flashOBJ.GetComponent<RectTransform>().anchorMax = new Vector2(0.0f, 1.0f);
        m_flashOBJ.GetComponent<RectTransform>().anchoredPosition = new Vector2(0, 0);
        m_flashOBJ.GetComponent<RectTransform>().sizeDelta = new Vector2(Screen.width, Screen.height);
        m_flashIMG.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
    }

    public IEnumerator Flash(float _waitTime)
    {
        while (true)
        {
            Color col = m_flashIMG.color;
            if (col.a <= 0.0f || col.a >= 1.0f)
                m_flashSpeed *= -1.0f;

            col.a += m_flashSpeed * Time.deltaTime;
            m_flashIMG.color = col;

            yield return new WaitForSeconds(_waitTime);
        }

    }
}
