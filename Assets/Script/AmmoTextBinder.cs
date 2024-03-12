using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AmmoTextBinder : MonoBehaviour
{
    public TMP_Text loadedAmmoText;
    public GunAmmo gunAmmo;
    private void Start()
    {
        gunAmmo.loadedAmmoChanged.AddListener(UpdateAmmo);
        UpdateAmmo();
    }
    private void UpdateAmmo()
    {
        loadedAmmoText.text = "Ammo: " + gunAmmo.loadedAmmo.ToString();
    }
}
