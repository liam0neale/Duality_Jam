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
                }
                else
                {
                    SwitchedOff();
                }
            }

            switchState = value;
            UpdateModel();
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

    private void Start()
    {
        UpdateModel();
    }

    protected void UpdateModel()
    {
        m_leverMoveTransform.localRotation = Quaternion.Euler(m_leverMoveTransform.localRotation.x, m_leverMoveTransform.localRotation.y, SwitchState ? -60 : 60);
    }
}
