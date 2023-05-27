using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CharacterController : MonoBehaviour
{
    
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float turnSpeed = 360;

    private Vector3 vectorInput;
    private Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        GatherInput();
        Look();
    }

    private void FixedUpdate()
    {
        CharacterMovement();
    }

    private void GatherInput()
    {
        vectorInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
    }

    private void Look ()
    {
        if (vectorInput != Vector3.zero)
        {
            var relative = (transform.position + vectorInput) - transform.position;
            var rot = Quaternion.LookRotation(relative, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, rot, turnSpeed * Time.deltaTime);
        }
    }

    void CharacterMovement()
    {
        rb.MovePosition(transform.position + (transform.forward * vectorInput.magnitude) * moveSpeed *Time.deltaTime);        
    }
}
