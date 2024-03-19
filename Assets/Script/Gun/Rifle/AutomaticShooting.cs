using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class AutomaticShooting : Shooting
{
    public GameObject muzzlePrefab;
    public GameObject muzzlePosition;

    public int rpm;
    public AudioSource shootSound;
    private float lastShot;
    private float interval;
    public GunAmmo gunAmmo;
    public UnityEvent onShoot;
    private void Start()
    {
        interval = 60f / rpm;
        onShoot.AddListener(FindAnyObjectByType<GunRaycaster>().PerformRaycasting);
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
        shootSound.Play();
        Instantiate(muzzlePrefab, muzzlePosition.transform.position, muzzlePosition.transform.rotation);
        gunAmmo.SingleFireAmmoCounter();
        onShoot.Invoke();
    }
}
