using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SuperJumpPlayerState : IPlayerState
{
    private const float jumpStrength = 14f;

    public void Enter(Player player)
    {
        player.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);
        GameObject.FindGameObjectWithTag("PlayerStateText").GetComponent<Text>().text = "Super Jumping";
        Debug.Log("Entering Super Jump State");
        player._currentState = this;
    }

    public void Execute(Player player)
    {
        //if object nolonger in contact with the floor
        if (!Physics.Raycast(player.transform.position, Vector3.down, player.transform.localScale.x * 3f))
        {
            FallingPlayerState fallingPlayerState = new FallingPlayerState();
            fallingPlayerState.Enter(player);
        }
    }
}
