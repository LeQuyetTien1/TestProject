using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBullet : MonoBehaviour
{
    public float flyingSpeed;
    public new Rigidbody rigidbody;
    public GameObject explosion;
    public float explosionRadius;
    public float explosionForce;
    
    void Update()
    {
        rigidbody.velocity = transform.right * flyingSpeed;
    }
    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
        Instantiate(explosion, transform.position, transform.rotation);
        BlowObjects();
    }
    private void BlowObjects()
    {
        Collider[] affectedObjects = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(var affectedObject in affectedObjects)
        {
            Rigidbody rigidbody = affectedObject.GetComponent<Rigidbody>();
            if(rigidbody != null)
            {
                rigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius, 1, ForceMode.Impulse);
            }
        }
    }
}
