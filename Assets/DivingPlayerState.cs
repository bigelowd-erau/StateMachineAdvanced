using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DivingPlayerState : IPlayerState
{
    private const float diveStrength = 7f;

    public void Enter(Player player)
    {

        //player.GetComponent<Rigidbody>().velocity = new Vector3(0f, jumpStrength, 0f);// .AddForce(0f, 1000f, 0f);
        player.GetComponent<Rigidbody>().AddForce(Vector3.down * diveStrength, ForceMode.Impulse);
        Debug.Log("Entering jumping State");
        //timeSinceJumpStart = Time.time;
        player._currentState = this;
    }

    public void Execute(Player player)
    {

        if (Physics.Raycast(player.transform.position, Vector3.down, player.transform.localScale.x * 0.52f))
        {
            StandingPlayerState standingPlayerState = new StandingPlayerState();
            standingPlayerState.Enter(player);
           
        }
    }
}
