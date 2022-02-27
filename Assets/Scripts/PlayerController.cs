using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private float horizontalInput, verticalInput, steeringAngle;
    public WheelCollider rearDriverWheel, rearPassengerWheel, frontDriverWheel, frontPassengerWheel;
    public Transform rearDriverT, rearPassengerT, frontDriverT, frontPassengerT;
    public float maxSteerAngle = 30;
    public float motorForce = 50;

    void Update () { }

    public void GetInput () {
        horizontalInput = Input.GetAxis ("Horizontal");
        verticalInput = Input.GetAxis ("Vertical");
    }

    public void Steer () {
        steeringAngle = maxSteerAngle * horizontalInput;
        frontDriverWheel.steerAngle = steeringAngle;
        frontPassengerWheel.steerAngle = steeringAngle;
    }

    private void Accelerate () {
        frontDriverWheel.motorTorque = verticalInput * motorForce;
        frontPassengerWheel.motorTorque = verticalInput * motorForce;
    }

    private void UpdateWheelsPosition () {
        UpdateWheelPosition (frontDriverWheel, frontDriverT);
        UpdateWheelPosition (frontPassengerWheel, frontPassengerT);
        UpdateWheelPosition (rearDriverWheel, rearDriverT);
        UpdateWheelPosition (rearPassengerWheel, rearPassengerT);
    }

    private void UpdateWheelPosition (WheelCollider collider, Transform transform) {
        Vector3 pos = transform.position;
        Quaternion quat = transform.rotation;
        collider.GetWorldPose (out pos, out quat);
        transform.position = pos;
        transform.rotation = quat * Quaternion.Euler (0, -90, 0);
    }

    private void FixedUpdate () {
        GetInput ();
        Steer ();
        Accelerate ();
        UpdateWheelsPosition ();
    }

}