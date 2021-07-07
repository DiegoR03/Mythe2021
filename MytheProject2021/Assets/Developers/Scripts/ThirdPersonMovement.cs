using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirdPersonMovement : MonoBehaviour
{
    public AudioSource walking;
    public CharacterController controller;
    public Transform cam;

    public GameObject Idle;
    public GameObject Walking;


    public float speed = 6f;

    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    
    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); //horizontal movement
        float vertical = Input.GetAxisRaw("Vertical");     //vertical movement
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized; //No Y-axis movement & diagonal movement is the same

        if (direction.magnitude >= 0.1f)
        {
            float targetAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y; //makes diagonal angles
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime); //makes movement angles smooth
            transform.rotation = Quaternion.Euler(0f, angle, 0f); //rotation for X, Y and Z

            Vector3 moveDir = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward; //Makes the player move forward in the camera direction
            controller.Move(moveDir.normalized * speed * Time.deltaTime); //Movement in-game
            Idle.SetActive(false);
            Walking.SetActive(true);
        }
        else
        {
            walking.Play();

            Idle.SetActive(true);
            Walking.SetActive(false);
        }

    }
}
 