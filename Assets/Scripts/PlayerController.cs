using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private float horizontalInput, verticalInput;
    public float boost = 12000f;
    private float currentSteering, currentBreaks;
    private bool isBreaking;
    public AudioSource nitroSoundSource;
    public AudioClip nitroSoundClip;

    [Header("SETTINGS")]
    [SerializeField] private float motorForce;
    [SerializeField] private float breakForce;
    [SerializeField] private float maxSteering;

   
    [Header("WHEELS COLLIDERS")]
    [SerializeField] private WheelCollider frontLeftCollider;
    [SerializeField] private WheelCollider frontRightCollider;
    [SerializeField] private WheelCollider rearLeftCollider;
    [SerializeField] private WheelCollider rearRightCollider;

    [Header("WHEELS")]
    [SerializeField] private Transform frontLeftTransform;
    [SerializeField] private Transform frontRightTransform;
    [SerializeField] private Transform rearLeftTransform;
    [SerializeField] private Transform rearRightTransform;

    private void FixedUpdate() {
        GetInput();
        HandleMotor();
        Steering();
        UpdateWheels();
    }

    //CAR MOVEMENT
    private void GetInput() {
        // Steering Input
        horizontalInput = Input.GetAxis("Horizontal");

        // Acceleration Input
        verticalInput = Input.GetAxis("Vertical");

        // Breaking Input
        isBreaking = Input.GetKey(KeyCode.LeftShift);
    }

    private void HandleMotor() {
        frontLeftCollider.motorTorque = verticalInput * motorForce;
        frontRightCollider.motorTorque = verticalInput * motorForce;
        currentBreaks = isBreaking ? breakForce : 0f;
        Breaking();
    }

    private void Breaking() {
        frontRightCollider.brakeTorque = currentBreaks;
        frontLeftCollider.brakeTorque = currentBreaks;
        rearLeftCollider.brakeTorque = currentBreaks;
        rearRightCollider.brakeTorque = currentBreaks;
    }

    private void Steering() {
        currentSteering = maxSteering * horizontalInput;
        frontLeftCollider.steerAngle = currentSteering;
        frontRightCollider.steerAngle = currentSteering;
    }

    private void UpdateWheels() {
        UpdateSingleWheel(frontLeftCollider, frontLeftTransform);
        UpdateSingleWheel(frontRightCollider, frontRightTransform);
        UpdateSingleWheel(rearRightCollider, rearRightTransform);
        UpdateSingleWheel(rearLeftCollider, rearLeftTransform);
    }

    private void UpdateSingleWheel(WheelCollider wheelCollider, Transform wheelTransform) {
        Vector3 pos;
        Quaternion rot; 
        wheelCollider.GetWorldPose(out pos, out rot);
        wheelTransform.rotation = rot;
        wheelTransform.position = pos;
    }
    
    //BOOST PADS

    void OnTriggerEnter(Collider boostHit)
    {
        if(boostHit.gameObject.tag == "Boost")
        {
            BoosterCar();
            nitroFireSound();
        }
    }

    void BoosterCar()
    {
        Rigidbody carRigidbody = GetComponent<Rigidbody>();
        if (carRigidbody != null)
        {   
             Debug.Log("SPEED!!!!");
            carRigidbody.AddForce(transform.forward * boost, ForceMode.Impulse);
        }
    }

    void nitroFireSound()
    {
        if (nitroSoundSource != null && nitroSoundClip != null)
        {
            nitroSoundSource.clip = nitroSoundClip;
            nitroSoundSource.Play();
        }
    }
}
