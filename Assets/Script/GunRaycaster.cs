using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunRaycaster : MonoBehaviour
{
    public GameObject hitMarkerPrefab;
    public Camera aimingCamera;
    public LayerMask layerMark;
    public int damage;

    public void PerformRaycasting()
    {
        Ray aimingRay = new Ray(aimingCamera.transform.position, aimingCamera.transform.forward);
        if (Physics.Raycast(aimingRay, out RaycastHit hitInfor, 1000f, layerMark))
        {
            Quaternion effectRotation = Quaternion.LookRotation(hitInfor.normal);
            Instantiate(hitMarkerPrefab, hitInfor.point, effectRotation);
            DeliverDamage(hitInfor);
        }
    }
    private void DeliverDamage(RaycastHit hitInfo)
    {
        Health health=hitInfo.collider.GetComponent<Health>();
        if(health != null )
        {
            health.TakeDamage(damage);
        }
    }
}
