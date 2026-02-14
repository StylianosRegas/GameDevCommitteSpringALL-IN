
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using TarodevController;

public class ClubAbility : MonoBehaviour
{
    public PlayerController player;
    public void doubleJump()
    {
        player.ExecuteJump();
    }
}
