using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Shoot();
    }

    public void Move()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.position += Vector3.up;
        }
    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Jump");
        }
    }

    public void Shoot()
    {
        Debug.Log("Shoot");
    }
}
