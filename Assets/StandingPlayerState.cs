using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StandingPlayerState : IPlayerState
{
    public void Enter(Player player)
    {
        GameObject.FindGameObjectWithTag("PlayerStateText").GetComponent<Text>().text = "Standing";
        Debug.Log("Entering Standing State");
        player._currentState = this;
    }

    public void Execute(Player player)
    {
        if (Input.GetKeyDown("w"))
        {
            JumpingPlayerState jumpingPlayerState = new JumpingPlayerState();
            jumpingPlayerState.Enter(player);
        } 
        else if (Input.GetKey("s"))
        {
            DuckingPlayerState duckingPlayerState = new DuckingPlayerState();
            duckingPlayerState.Enter(player);
        }
    }
}
