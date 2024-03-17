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
    public int damage;
    
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
            AddForceToObject(affectedObject);
            DeliverDamage(affectedObject);
        }
    }
    private void DeliverDamage(Collider victim)
    {
        Health victimHealth= victim.GetComponent<Health>();
        if(victimHealth != null )
        {
            victimHealth.TakeDamage(damage);
        }
    }
    private void AddForceToObject(Collider victim)
    {
        Rigidbody rigidbody = victim.GetComponent<Rigidbody>();
        if (rigidbody != null)
        {
            rigidbody.AddExplosionForce(explosionForce, transform.position, explosionRadius, 1, ForceMode.Impulse);
        }
    }
}
