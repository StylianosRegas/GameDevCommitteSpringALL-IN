
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

    public void Dash()
    {
        int dashDist = 4;

        if (player.isFlipped)
        {
            player.transform.position = new Vector3(player.transform.position.x - dashDist, player.transform.position.y, 0);
        }

        else
        {
            player.transform.position = new Vector3(player.transform.position.x + dashDist, player.transform.position.y, 0);
        }

    }

    public void SpeedBoost()
    {
      
        float duration = 5f;

        float speedMulti = 2f;
        player._stats.MaxSpeed = player._stats.MaxSpeed * speedMulti;
        StartCoroutine(SpeedDuration(duration, speedMulti));
       



    }

    public IEnumerator SpeedDuration(float time, float speedMulti)
    {
        
        yield return new WaitForSeconds(time);
        player._stats.MaxSpeed = player._stats.MaxSpeed / speedMulti;
        


    }

    
}
