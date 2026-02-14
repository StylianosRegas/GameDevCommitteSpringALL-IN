using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HeartCards : MonoBehaviour
{
    public Health playerHealth;
    public void Regen(Health playerHealth)
    {
        playerHealth.Regen();
    }

    public void Sheild(Health playerHealth)
    {
        playerHealth.Sheild();
    }
}
