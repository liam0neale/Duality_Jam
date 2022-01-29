using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public static FlashImage ImageToFlash;
    IEnumerator thread = null;
    void Awake()
    {
        if(ImageToFlash == null)
            ImageToFlash = new FlashImage();
    }

	private void Update()
	{
	}
}
