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
    private List<Health> oldVictims = new List<Health>();
    
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
        oldVictims.Clear();
        Collider[] affectedObjects = Physics.OverlapSphere(transform.position, explosionRadius);
        foreach(var affectedObject in affectedObjects)
        {
            AddForceToObject(affectedObject);
            DeliverDamage(affectedObject);
        }
    }
    private void DeliverDamage(Collider victim)
    {
        Health health= victim.GetComponentInParent<Health>();
        if(health != null && !oldVictims.Contains(health))
        {
            health.TakeDamage(damage);
            oldVictims.Add(health);
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
