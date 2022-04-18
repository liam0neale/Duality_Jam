using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Manager : MonoBehaviour
{
    public static Manager self;
    public static HUD m_hud;
    public static Counter m_counter;
    public static LevelManager m_levelManager;

    [SerializeField] private GameObject m_dimensionUIHolder = default;
    [SerializeField] private Slider m_dimernsionUISlider = default;

    //Camera Data
    Camera m_camera;
    float m_minFOV = 0;
    float m_maxFOV = 90;

    //Corutines
    IEnumerator flashThread = null;

    enum SceneState
    {
        ssMAIN_MENU = 0,
        ssDEATH_MENU = 1,
        ssWIN_MENU = 2,
        ssOPTIONS_MENU = 3,
        ssLEVEL_X = 4 
	} SceneState m_sceneState  = SceneState.ssLEVEL_X;

    // Start is called before the first frame update
    void Awake()
    {
        self = this;
        //constant in all scenes
        DontDestroyOnLoad(gameObject);

        m_hud = gameObject.AddComponent<HUD>();
        m_counter = gameObject.AddComponent<Counter>();
        m_levelManager = FindObjectOfType<LevelManager>();
        m_camera = Camera.main;
        m_camera.fieldOfView = m_maxFOV;
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(m_sceneState)
        {
            case SceneState.ssMAIN_MENU:
            {
                
			}break;
            case SceneState.ssDEATH_MENU:
            {

			}break;
            case SceneState.ssWIN_MENU:
            {

			}break;
            case SceneState.ssOPTIONS_MENU:
            {
                
			}break;
            case SceneState.ssLEVEL_X:
            {
                CalculateCameraFOV();

                if (m_counter.IsCounting())
                {
                    m_dimernsionUISlider.value = 1 - m_counter.GetDistanceThrough();
                }

                if (m_counter.IsTimeOver() && m_counter.IsCounting())
                {
                    DimensionSwitcher.SwitchDimension(false);
                    m_levelManager.ResetLevel(false);
                }
            }
            break;
            default:
            {
                Debug.LogWarning("Manager::Update() -> not SceneState catchs for state = " + m_sceneState.ToString());
			}break;
		}
      
    }

    public void SwitchDimension(bool _isDark)
    {
        m_dimensionUIHolder.SetActive(_isDark);

        if (_isDark)
        {
            m_counter.StartTimer();
            flashThread = HUD.ImageToFlash.Flash(0.5f);
            StartCoroutine(flashThread);
        }
        else
        {
            m_counter.Stop();
            HUD.ImageToFlash.StopFlash();  
        }
    }

    public void CalculateCameraFOV()
    {
        if (m_counter.IsCounting())
        {
            float distance = m_counter.GetDistanceThrough();
            float fov = (1 - distance) * (m_maxFOV - m_minFOV);
            m_camera.fieldOfView = fov;
        }
        else
        {
            m_camera.fieldOfView = m_maxFOV;
        }
    }
}
