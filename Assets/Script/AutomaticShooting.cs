using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticShooting : MonoBehaviour
{
    public int rpm;
    public AudioSource shootSound;
    private float lastShot;
    private float interval;
    private void Start()
    {
        interval = 60 / rpm;
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            UpdateFiring();
        }
    }
    private void UpdateFiring()
    {
        if (Time.time - lastShot >= interval)
        {
            Shoot();
            lastShot = Time.time;
        }
    }
    private void Shoot()
    {
        Debug.Log("Shoot");
        shootSound.Play();
    }
}
