using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingPlayerState : IPlayerState
{
    private const float jumpStrength = 7f;

    public void Enter(Player player)
    {
        player.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);
        Debug.Log("Entering Jumping State");
        player._currentState = this;
    }

    public void Execute(Player player)
    {
        //if object nolonger in contact with the floor
        if (!Physics.Raycast(player.transform.position, Vector3.down, player.transform.localScale.x * 0.52f))
        {
            FallingPlayerState fallingPlayerState = new FallingPlayerState();
            fallingPlayerState.Enter(player);
        }
    }
}
