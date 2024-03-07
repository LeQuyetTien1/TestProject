using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAmmo : MonoBehaviour
{
    public int magSize;
    public RocketController gun;
    private int _loadedAmmo;
    public int loadedAmmo
    {
        get => _loadedAmmo;
        set
        {
            _loadedAmmo = value;
            if (_loadedAmmo <= 0) LockShooting();
            else UnlockShooting();
        }
    }
    private void LockShooting() => gun.enabled = false;
    private void UnlockShooting() => gun.enabled = true;
    public void SingleFireAmmoCounter()
    {
        loadedAmmo--;
        Debug.Log($"ammo: {loadedAmmo}");
    }
    private void RefillAmmo() => loadedAmmo = magSize;
    private void Reload()
    {
        LockShooting();
        RefillAmmo();
        Debug.Log($"ammo: {loadedAmmo}");
    }
    void Start()
    {
        RefillAmmo();
        Debug.Log($"ammo: {loadedAmmo}");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }
}
