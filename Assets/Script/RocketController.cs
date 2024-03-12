using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    public GameObject rocket;
    public GameObject flyRocket;
    public GunAmmo gunAmmo;
    private float time = 0;
    public AudioSource rocketShootSound;
    void Update()
    {
        ShootRocket();
        Reload();
    }
    public void ShootRocket()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rocket.SetActive(false);
            time = 0;
            BulletSpawn();
            gunAmmo.SingleFireAmmoCounter();
            rocketShootSound.Play();
        }
    }
    public void Reload()
    {
        if (time < 1)
        {
            time += Time.deltaTime;
        }
        else
        {
            rocket.SetActive(true);
        }
    }
    public void BulletSpawn()
    {
        Instantiate(flyRocket, rocket.transform.position, rocket.transform.rotation);
    }
}
