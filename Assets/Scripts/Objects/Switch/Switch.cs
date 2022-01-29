using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    [SerializeField] private Transform m_leverMoveTransform = default;

    public bool SwitchState
    {
        get
        {
            return switchState;
        }
        set
        {
            if (value != switchState)
            {
                if (value)
                {
                    SwitchedOn();
                    UpdateModel();
                }
                else
                {
                    SwitchedOff();
                    UpdateModel();
                }
            }
            switchState = value;
        }
    }

    bool switchState = false;

    public void FlipState()
    {
        SwitchState = !switchState;
    }

    protected virtual void SwitchedOn()
    {

    }

    protected virtual void SwitchedOff()
    {

    }

    private void Awake()
    {
        UpdateModel();
    }

    private void UpdateModel()
    {
        m_leverMoveTransform.localRotation = Quaternion.Euler(m_leverMoveTransform.localRotation.x, m_leverMoveTransform.localRotation.y, SwitchState ? -60 : 60);
    }
}
