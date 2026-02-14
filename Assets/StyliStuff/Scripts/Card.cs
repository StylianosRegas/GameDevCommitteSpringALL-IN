using System;
using System.Collections;
using UnityEngine.Events;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEngine;

public class Card : MonoBehaviour
{
    public int CardType = 1;
    public float cooldown = 10;
    public bool hasCooldown = false;
    public String name = "default card";
    public String description = "yada yada";
    public UnityEvent ability;
    //public PlayerManager Player;
   

    public IEnumerator AbilityCooldown()
    {

        Debug.Log("Cooldown start!");

        yield return new WaitForSeconds(cooldown);

        hasCooldown = false;
        Debug.Log("Cooldown finished");

    }
    public void useAbility()
    {
        ability.Invoke();
    }


}
