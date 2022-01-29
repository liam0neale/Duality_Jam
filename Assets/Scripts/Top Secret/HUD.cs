using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public static FlashImage ImageToFlash;

    void Awake()
    {
        if(ImageToFlash == null)
            ImageToFlash = new FlashImage();
    }

	private void Update()
	{
		if(Manager.m_counter.IsCounting() )
        {
            StartCoroutine(ImageToFlash.Flash(0.1f));
		}
	}
}
