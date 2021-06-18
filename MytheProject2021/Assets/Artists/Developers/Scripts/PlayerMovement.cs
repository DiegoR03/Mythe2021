using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    CharacterController characterController;

    [SerializeField] float walkSpeed;
    [SerializeField] float runSpeed;
    [SerializeField] float turnSpeed;

    bool isRunning;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        isRunning = Input.GetKey(KeyCode.LeftShift);

        Move();
    }

    void Move()
    {
        float horizontal = Input.GetAxis("Horizontal") * GetCurrentSpeed() * Time.deltaTime;
        float vertical = Input.GetAxis("Vertical") * GetCurrentSpeed() * Time.deltaTime;

        Vector3 moveVector = new Vector3(horizontal, 0f, vertical);

        characterController.Move(moveVector);

        if(moveVector != Vector3.zero)
        {
            Rotate(moveVector);
        }
    }

    void Rotate(Vector3 moveVector)
    {
        Quaternion targetRotation = Quaternion.LookRotation(moveVector, Vector3.up);

        Quaternion newRotation = Quaternion.Lerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);

        transform.rotation = newRotation;
        
    }

    float GetCurrentSpeed()
    {
        return isRunning ? runSpeed : walkSpeed;
        
    }
}
