using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieAttack : MonoBehaviour
{
    public Animator anim;
    public Health playerHealth;
    public int damage;

    public void StartAttack() => anim.SetBool("IsAttacking", true);
    public void StopAttack() => anim.SetBool("IsAttacking", false);
    public void OnAttack(int index)
    {
        Debug.Log("Attacking Player");
        playerHealth.TakeDamage(damage);
        if (index == 1)
        {
            Player.Instance.playerUI.ShowLeftScratch();
        }
        else
        {
            Player.Instance.playerUI.ShowRightScratch();
        }
    }
}
