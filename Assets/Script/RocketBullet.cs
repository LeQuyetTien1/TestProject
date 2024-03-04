using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBullet : MonoBehaviour
{
    public float flyingSpeed;
    public Rigidbody rigidbody;
    void Start()
    {
        
    }

    void Update()
    {
        rigidbody.velocity = transform.right * flyingSpeed;
    }
}
