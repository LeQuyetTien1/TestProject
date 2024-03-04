using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketController : MonoBehaviour
{
    public GameObject rocket;
    public GameObject flyRocket;
    private float time = 0;
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
