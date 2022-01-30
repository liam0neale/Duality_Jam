using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrokenBlock : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        rb.AddForce(0, Random.Range(-100,100), 150);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
