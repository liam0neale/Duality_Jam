using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HUD 
{
    //Camera Data
    Camera m_camera;
    float m_minFOV = 0; 
    float m_maxFOV = 90;
    // Start is called before the first frame update
    void Awake()
    {
        m_camera = Camera.main;
        if (m_camera == null)
            Debug.LogError("HUD::Awake() -> no camera found");

        m_camera.fieldOfView = m_maxFOV;
    }

    // Update is called once per frame
    void Update()
    {
        if(MissionData.counter.IsCounting())
        {
            float distance = MissionData.counter.GetDistanceThrough();
            float fov = distance * (m_maxFOV - m_minFOV);
            m_camera.fieldOfView = fov;
        }
    }
}
