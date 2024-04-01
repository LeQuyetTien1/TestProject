using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Health health;
    public Image healthValue;

    public void ChangeHealthBar(int healthPointValue, int maxHealthPoint)
    {
        healthValue.fillAmount=(float) healthPointValue/maxHealthPoint;
    }
}
