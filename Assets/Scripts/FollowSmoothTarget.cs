using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowSmoothTarget : MonoBehaviour {

    [SerializeField]
    private Transform target;
    [SerializeField]
    private float smoothTime = 0.3f;
    private Vector2 velocity = Vector2.zero;
    private Vector2 newPosition = Vector2.zero;
    private Vector3 newTransformPosition = Vector3.zero;

    private void Update()
    {
        newPosition = Vector2.SmoothDamp(transform.position, target.position, ref velocity, smoothTime);
        newTransformPosition = newPosition;
        newTransformPosition.z = transform.position.z;
        transform.position = newTransformPosition;
    }

}
