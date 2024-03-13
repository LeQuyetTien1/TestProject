using System.Collections;
using System.Collections.Generic;
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
    public GameObject hitMarkerPrefab;
    public Camera aimingCamera;
    public LayerMask layerMark;
    public GunAmmo gunAmmo;
    private void Start()
    {
        interval = 60f / rpm;
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
        PerformRaycasting();
        Instantiate(muzzlePrefab, muzzlePosition.transform.position, muzzlePosition.transform.rotation);
    }
    private void PerformRaycasting()
    {
        Ray aimingRay = new Ray(aimingCamera.transform.position, aimingCamera.transform.forward);
        if(Physics.Raycast(aimingRay, out RaycastHit hitInfor, 1000f, layerMark))
        {
            gunAmmo.SingleFireAmmoCounter();
            Quaternion effectRotation = Quaternion.LookRotation(hitInfor.normal);
            Instantiate(hitMarkerPrefab, hitInfor.point, effectRotation);
        }
    }
}
