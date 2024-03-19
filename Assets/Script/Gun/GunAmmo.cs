using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GunAmmo : MonoBehaviour
{
    public int magSize;
    public Shooting gun;
    private int _loadedAmmo;
    public UnityEvent loadedAmmoChanged;
    public AudioSource reloadSound;
    public int loadedAmmo
    {
        get => _loadedAmmo;
        set
        {
            _loadedAmmo = value;
            loadedAmmoChanged.Invoke();
            if (_loadedAmmo <= 0) LockShooting();
            else UnlockShooting();
        }
    }
    private void LockShooting() => gun.enabled = false;
    private void UnlockShooting() => gun.enabled = true;
    public void SingleFireAmmoCounter()
    {
        loadedAmmo--;
    }
    private void RefillAmmo() => loadedAmmo = magSize;
    private void Reload()
    {
        LockShooting();
        RefillAmmo();
        reloadSound.Play();
    }
    void Start()
    {
        RefillAmmo();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();
        }
    }
}
