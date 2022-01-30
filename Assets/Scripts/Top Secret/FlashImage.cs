using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FlashImage
{
    GameObject m_flashOBJ;
    Image m_flashIMG;
    float m_flashSpeed = 50.0f;
    bool m_isFlashing = false;

    private float m_maxAlpha = 0.6f;
    private float m_minAlpha = 0.0f;

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
        m_flashIMG.color = new Color(1.0f, 1.0f, 1.0f, 0.0f);
    }

    bool IsFlashing() { return m_isFlashing; }

    public IEnumerator Flash(float _waitTime)
    {
        m_isFlashing = true;
        while (m_isFlashing)
        {
            float alpha = m_flashIMG.color.a;
            if (alpha < m_minAlpha)
            {
                alpha = m_minAlpha;
                m_flashSpeed *= -1.0f;
            }
            else if(alpha >= m_maxAlpha)
            {
                alpha = m_maxAlpha;
                m_flashSpeed *= -1.0f;
            }

            alpha += m_flashSpeed * Time.deltaTime;
            m_flashIMG.color = new Color(0.0f, 0.0f, 0.0f, alpha);
           
            yield return new WaitForSeconds(_waitTime);
        }

    }
    public void StopFlash()
    {
        m_isFlashing = false;
        m_flashIMG.color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
	}

}
