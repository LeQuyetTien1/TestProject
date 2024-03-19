using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRaycaster : MonoBehaviour
{
    /*public GameObject hitMarkerPrefab;*/
    public Camera aimingCamera;
    public LayerMask layerMark;
    public int damage;

    public void PerformRaycasting()
    {
        Ray aimingRay = new Ray(aimingCamera.transform.position, aimingCamera.transform.forward);
        if (Physics.Raycast(aimingRay, out RaycastHit hitInfor, 1000f, layerMark))
        {
            ShowHitEffect(hitInfor);
            DeliverDamage(hitInfor);
        }
    }
    private void DeliverDamage(RaycastHit hitInfo)
    {
        Health health=hitInfo.collider.GetComponentInParent<Health>();
        if(health != null )
        {
            health.TakeDamage(damage);
        }
    }
    private void ShowHitEffect(RaycastHit hitInfo)
    {
        HitSurface hitSurface = hitInfo.collider.GetComponent<HitSurface>();
        if (hitSurface != null)
        {
            GameObject effectPrefab = HitEffectManager.Instance.GetEffectPrefab(hitSurface.surfaceType);
            if (effectPrefab != null)
            {
                Quaternion effectRotation = Quaternion.LookRotation(hitInfo.normal);
                Instantiate(effectPrefab, hitInfo.point, effectRotation);
            }
        }
    }
}
