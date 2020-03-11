using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FauxGravityAttractor : MonoBehaviour
{
    public float gravity = -10f;
    public void Attract(Transform body)
    {
        Vector3 gravityUp = (body.position - transform.position).normalized;
        //Direction of the body, this should be equal to gravityUp;
        Vector3 bodyUp = body.up;

        body.GetComponent<Rigidbody>().AddForce(gravityUp * gravity);

        //Rotatiion, this returns the rotational difference between the parameters
        Quaternion targetRotation = Quaternion.FromToRotation(bodyUp, gravityUp) * body.rotation;

        //Smooth rotation
        body.rotation = Quaternion.Slerp(body.rotation, targetRotation, 50 * Time.fixedDeltaTime);
    }

}
