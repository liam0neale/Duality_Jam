using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public struct CameraConfig
    {
        public bool lookAtPlayer;
        public bool moveable;
        public Vector3 offset;

        public CameraConfig(bool _lookAtPlayer, bool _move, Vector3 _offset)
        {
            lookAtPlayer = _lookAtPlayer;
            moveable = _move;
            offset = _offset;
		}

	}

    CameraConfig m_config;
    GameObject m_player;
    Camera cam;
    Vector3 m_startPos;
    // Start is called before the first frame update
    void Awake()
    {
        m_player = GameObject.FindGameObjectWithTag("Player");
        if (m_player == null)
            Debug.LogError("CameraController::Awake() -> cant find player");

        m_config = new CameraConfig(false, false, Vector3.zero);
        cam = gameObject.GetComponent<Camera>();
        m_startPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(m_config.lookAtPlayer)
            gameObject.transform.LookAt(m_player.transform, Vector3.up);
        if(m_config.moveable)
        {
            gameObject.transform.position = m_startPos + m_player.transform.position;
		}
    }

    public void SetCameraLookAtPLayer(bool _canRotate)
    {
        m_config.lookAtPlayer = _canRotate;
    }
    public void SetCameraMoveable(bool _canMove)
    {
        m_config.moveable = _canMove;
	}
}
