using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed;
    [SerializeField] private float gravity;
    private Vector3 velocity;

    private CharacterController cc;

    private void Awake()
    {
        cc = GetComponent<CharacterController>();
    }

    private void Update()
    {
        if (cc.isGrounded && velocity.y < 0) velocity.y = 0;

        float h_input = Input.GetAxisRaw("Horizontal");
        float v_input = Input.GetAxisRaw("Vertical");

        velocity = new Vector3(h_input, 0, v_input) * movementSpeed;
        if (velocity != Vector3.zero) transform.forward = velocity.normalized;

        if (!cc.isGrounded)
        {
            velocity.y -= gravity;
        }

        cc.Move(velocity * Time.deltaTime);
    }
}
