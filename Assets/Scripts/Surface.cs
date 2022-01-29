using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Surface : MonoBehaviour
{
   [Serializable]
    public enum SurfaceTypes
    {
        stNORMAL = 0,
        stSLIPPERY = 1,
        stSTICKY = 2
    }
    [SerializeField] public SurfaceTypes m_surfaceTypes;

	private void Awake()
	{
        PhysicMaterial material = new PhysicMaterial();
        switch(m_surfaceTypes)
        {
            case SurfaceTypes.stSLIPPERY:
            {
                material.dynamicFriction = 0.1f;
                material.frictionCombine = PhysicMaterialCombine.Minimum;
                gameObject.GetComponent<Collider>().material = material;
            }
            break;
		}
		
	}

}
