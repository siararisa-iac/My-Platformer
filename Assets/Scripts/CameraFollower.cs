using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    public Transform target;
    public Vector2 offset;

    // Update is called once per frame
    private void Update()
    {
        transform.position = new Vector3(target.position.x + offset.x,
                                        target.position.y + offset.y, -10);
    }
}
