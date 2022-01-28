using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Manager : MonoBehaviour
{
    public static HUD m_hud;
    public static Counter m_counter;

    //Camera Data
    Camera m_camera;
    float m_minFOV = 0;
    float m_maxFOV = 90;


    // Start is called before the first frame update
    void Awake()
    {
        m_hud = gameObject.AddComponent<HUD>();
        m_counter = gameObject.AddComponent<Counter>();

        m_camera = Camera.main;
        m_camera.fieldOfView = m_maxFOV;

    }

    // Update is called once per frame
    void Update()
    {
        if (m_counter.IsCounting())
        {
            float distance = m_counter.GetDistanceThrough();
            float fov = (1 - distance) * (m_maxFOV - m_minFOV);
            //m_camera.fieldOfView = fov;

            StartCoroutine(m_hud.FlashImage(0.1f));
        }
    }
}
