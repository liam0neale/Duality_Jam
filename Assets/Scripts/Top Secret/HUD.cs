using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    FlashImage m_imageToFlash;

    void Awake()
    {
        m_imageToFlash = new FlashImage();
    }

	private void Update()
	{
		if(Manager.m_counter.IsCounting())
        {
            StartCoroutine(m_imageToFlash.Flash(0.1f));
		}
	}
}
