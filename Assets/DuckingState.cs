using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckingPlayerState : IPlayerState
{
    public void Enter(Player player)
    {
        player.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
        Debug.Log("Entering Ducking State");
        player._currentState = this;
    }

    public void Execute(Player player)
    {

        if (Input.GetKeyUp("s"))
        {
            player.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            StandingPlayerState standingPlayerState = new StandingPlayerState();
            standingPlayerState.Enter(player);
        } 
        else if(Input.GetKeyDown("w"))
        {
            player.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            SuperJumpPlayerState superJumpPlayerState = new SuperJumpPlayerState();
            superJumpPlayerState.Enter(player);
        }
    }
}
