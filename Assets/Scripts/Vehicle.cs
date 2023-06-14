using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    protected float speed = 25f;
    protected float rotateSpeed = 45f;
    public float horizontalInput = 0f;
    public float verticalInput = 0f;
    protected float boundaries;

    protected Rigidbody vehicleRB;
    protected GameObject focalPoint;
    protected Vector3 offset = Vector3.zero;

    // Start is called before the first frame update
    void Awake()
    {
        vehicleRB = GetComponent<Rigidbody>();
        boundaries = GameObject.Find("Main Gameplay Manager").GetComponent<MainGameplayManager>().boundaries;
        focalPoint = GameObject.Find("Focal Point");
    }

    // Update is called once per frame
    void Update()
    {
        CheckDirectionalInput();
        ConstrainPlayerPosition();
    }

    private void LateUpdate()
    {
        focalPoint.transform.position = transform.position + offset;
        focalPoint.transform.rotation = transform.rotation;
    }

    private void FixedUpdate()
    {
        MoveVehicle();
        RotateVehicle();
    }

    //Check directional input set in Project Settings -> Input Manager, like key arrow, WASD, joystick Axis, etc
    void CheckDirectionalInput()
    {
        if (Input.GetAxis("Horizontal") != 0 && Input.GetAxis("Vertical") != 0)
        {
            float directionLength = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).magnitude;
            horizontalInput = Input.GetAxis("Horizontal") / directionLength;
            verticalInput = Input.GetAxis("Vertical") / directionLength;
        }
        else
        {
            horizontalInput = Input.GetAxis("Horizontal");
            verticalInput = Input.GetAxis("Vertical");
        }

    }

    //Prevent the Player from leaving the top or bottom of the screen by teleport them to the other sides
    void ConstrainPlayerPosition()
    {
        if (transform.position.z < -boundaries)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, boundaries);
        }
        else if (transform.position.z > boundaries)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -boundaries);
        }
        else if (transform.position.x < -boundaries)
        {
            transform.position = new Vector3(boundaries, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > boundaries)
        {
            transform.position = new Vector3(-boundaries, transform.position.y, transform.position.z);
        }
    }

    //Moves the Player based on CheckDirectionalInput()
    protected virtual void MoveVehicle() //POLYMORPHISM
    {
        vehicleRB.AddForce(transform.forward * speed * verticalInput);
    }

    protected virtual void RotateVehicle() //POLYMORPHISM
    {
        transform.Rotate(Vector3.up * rotateSpeed * horizontalInput * Time.deltaTime);
    }

}
