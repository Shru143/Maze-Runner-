# Maze Runner

Maze Runner is an exciting maze-solving game built using [Unity Engine](https://unity.com/). The player navigates through a series of complex mazes while avoiding traps and solving puzzles to reach the goal.

## Table of Contents
- [Features](#features)
- [Gameplay](#gameplay)
- [Scripts](#scripts)

## Features
- **Dynamic Mazes**: Randomly generated mazes, ensuring that each playthrough is unique.
- **Time-based Challenges**: Players must complete the maze within a time limit for extra rewards.
- **Power-ups and Traps**: Collect power-ups to assist in navigating the maze while avoiding hidden traps.
- **Multilevel Gameplay**: Progress through multiple maze levels, each increasing in difficulty.
- **Smooth Player Movement**: Intuitive and responsive controls for a seamless gameplay experience.

## Gameplay
The objective of Maze Runner is to find your way through intricate mazes while collecting coins, avoiding obstacles, and beating the clock. Each level offers different challenges such as faster enemies, hidden traps, or dead ends. You control the player to find the exit and complete the level.

## Script

### Playe Movement

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    [RequireComponent(typeof(CharacterController))]
    [AddComponentMenu("Control Script/FPSController")]

    public class PlayerMovement : MonoBehaviour {

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

    }}
