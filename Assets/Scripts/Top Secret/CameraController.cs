using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public struct CameraConfig
    {
        public bool lookAtPlayer;
        public bool moveable;
        public CameraConfig(bool _lookAtPlayer, bool _move)
        {
            lookAtPlayer = _lookAtPlayer;
            moveable = _move;
		}

	}

    CameraConfig m_config;
    GameObject m_player;
    Camera cam;
    // Start is called before the first frame update
    void Awake()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");
        if (m_player == null)
            Debug.LogError("CameraController::Awake() -> cant find player");

        m_config = new CameraConfig(true, false);
        cam = gameObject.GetComponent<Camera>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(m_config.lookAtPlayer)
            gameObject.transform.LookAt(m_player.transform, Vector3.up);
    }
}
