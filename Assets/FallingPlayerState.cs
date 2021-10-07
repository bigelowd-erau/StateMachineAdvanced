using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FallingPlayerState : IPlayerState
{

    public void Enter(Player player)
    {
        GameObject.FindGameObjectWithTag("PlayerStateText").GetComponent<Text>().text = "Falling";
        Debug.Log("Entering Falling State");
        player._currentState = this;
    }

    public void Execute(Player player)
    {
        //if come in contact with floor
        if (Physics.Raycast(player.transform.position, Vector3.down, player.transform.localScale.x * 0.52f))
        {
            StandingPlayerState standingPlayerState = new StandingPlayerState();
            standingPlayerState.Enter(player);
        }
        if (Input.GetKeyDown("s"))
        {
            DivingPlayerState divingPlayerState = new DivingPlayerState();
            divingPlayerState.Enter(player);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            FloatingPlayerState floatingPlayerState = new FloatingPlayerState();
            floatingPlayerState.Enter(player);
        }
    }
}
