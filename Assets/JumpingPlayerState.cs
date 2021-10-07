using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpingPlayerState : IPlayerState
{
    private const float jumpStrength = 7f;
    private float timeSinceStart;

    public void Enter(Player player)
    {
        player.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);
        GameObject.FindGameObjectWithTag("PlayerStateText").GetComponent<Text>().text = "Jumping";
        timeSinceStart = Time.time;
        Debug.Log("Entering Jumping State");
        player._currentState = this;
    }

    public void Execute(Player player)
    {
        //if object nolonger in contact with the floor
        if (!Physics.Raycast(player.transform.position, Vector3.down, player.transform.localScale.x * 0.51f))
        {
            FallingPlayerState fallingPlayerState = new FallingPlayerState();
            fallingPlayerState.Enter(player);
        }
        if (player.GetComponent<Rigidbody>().position.y == 0.5f && Time.time > timeSinceStart + 0.2f)
        {
            StandingPlayerState standingPlayerState = new StandingPlayerState();
            standingPlayerState.Enter(player);
        }
    }
}
