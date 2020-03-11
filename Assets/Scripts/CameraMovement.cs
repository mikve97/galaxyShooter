using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    // inspector variables
    [SerializeField]
    private Transform playerTransform;
    [SerializeField]
    private Vector3 offsetPosition;


    [SerializeField]
    private float smoothness = 1f;
    [SerializeField]
    private float rotationSmoothness = .1f;

    private Vector3 velocity = Vector3.zero;

    // privates
    private Transform _mainCam = null;

    // Use this for initialization
    void FixedUpdate()
    {
            _mainCam = Camera.main.transform;
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        UpdateCamera();
    }
    // Update camera position and rotation
    private void UpdateCamera()
    {
        Vector3 newPos = playerTransform.TransformDirection(offsetPosition);

        // camera rig position
        transform.position = Vector3.SmoothDamp(transform.position, newPos, ref velocity, smoothness);
        //transform.position = playerTransform.position + -(playerTransform.forward * offsetPosition.z) + (playerTransform.up * offsetPosition.y);

        Quaternion targetRot = Quaternion.LookRotation(-transform.position.normalized, playerTransform.up);
        //transform.rotation = targetRot;
        transform.rotation = Quaternion.Lerp(transform.rotation, 0, Time.fixedDeltaTime * rotationSmoothness);


        Debug.Log(playerTransform.up);
        // point camera at player using players up direction
        _mainCam.LookAt(playerTransform, playerTransform.up);
    }
}
