using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneVehicle : Vehicle //INHERITANCE
{
    protected override void MoveVehicle() //POLYMORPHISM
    {
        vehicleRB.velocity = transform.forward * speed;
    }

    protected override void RotateVehicle() //POLYMORPHISM
    {
        transform.Rotate(Vector3.forward * -rotateSpeed * horizontalInput * Time.deltaTime);
        transform.Rotate(Vector3.right * rotateSpeed * verticalInput * Time.deltaTime);
    }
}
