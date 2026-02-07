using System;
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
    //public PlayerManager Player;
    //public CardAbilites Ability;

    public IEnumerator AbilityCooldown()
    {

        Debug.Log("Ability used!");

        yield return new WaitForSeconds(cooldown);

        hasCooldown = false;
        Debug.Log("Cooldown finished");

    }
}
