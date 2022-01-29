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
                material.dynamicFriction = 0.2f;
                material.staticFriction = 0.1f;
                material.frictionCombine = PhysicMaterialCombine.Minimum;
                gameObject.GetComponent<Collider>().material = material;
            }
            break;
            case SurfaceTypes.stSTICKY:
            {
                    material.dynamicFriction = 0.8f;
                    material.staticFriction = 0.8f;
                    material.frictionCombine = PhysicMaterialCombine.Maximum;
                    gameObject.GetComponent<Collider>().material = material;
            }
            break;
            case SurfaceTypes.stNORMAL:
            {
                //gameObject.GetComponent<Collider>().material = null;
            }
            break;
        }
		
	}

	private void OnCollisionEnter(Collision collision)
	{
		if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerController>().m_surfaceType = m_surfaceTypes;

        }
	}

}
