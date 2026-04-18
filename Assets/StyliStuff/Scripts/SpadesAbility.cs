using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TarodevController;

public class SpadesAbility : MonoBehaviour
{
    public PlayerController player;
    public GameObject pokerChip;

    public void PokerChip()
    {
        Instantiate(pokerChip);
    }
}
