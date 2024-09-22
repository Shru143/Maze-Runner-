using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPSController")]
public class PlayerMovement : MonoBehaviour
{
    public float speed = 6.0f;
    public float jumpSpeed = 5.0f;
    private bool playerGrounded;
    private float _ySpeed;
    private CharacterController playControl;
    public float gravity = -9.8f;


    // Start is called before the first frame update
    void Start()
    {
        playControl = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        float _deltaX = Input.GetAxis("Horizontal") * speed;
        float _deltaZ = Input.GetAxis("Vertical") * speed;
        Vector3 movement = new Vector3(_deltaX, 0, _deltaZ);
        movement = Vector3.ClampMagnitude(movement, speed);
        _ySpeed += gravity * Time.deltaTime;
        playerGrounded = playControl.isGrounded;
        if (playerGrounded)
        {
            _ySpeed = -0.5f;

            if (Input.GetButtonDown("Jump"))
            {
                _ySpeed = jumpSpeed;
            }
        }
        //movement.y = gravity;
        movement *= Time.deltaTime;
        movement = transform.TransformDirection(movement);
        movement.y = _ySpeed * Time.deltaTime;
        playControl.Move(movement);
        //transform.Translate(_deltaX*Time.deltaTime, 0, _deltaZ*Time.deltaTime);

    }
}