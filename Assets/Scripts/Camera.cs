using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public Transform ObjectToTrack;
    public Vector3 delta;

    
    void FixedUpdate()
    {
        transform.LookAt(ObjectToTrack);

        var trackedRigidbody = ObjectToTrack.GetComponent<Rigidbody>();
        var Speed = trackedRigidbody.velocity.magnitude;

        var TargetPosition = ObjectToTrack.position + delta * (Speed / 40f + 1f);
        transform.position = Vector3.Lerp(transform.position, TargetPosition, Time.smoothDeltaTime*5f);
    }
}
