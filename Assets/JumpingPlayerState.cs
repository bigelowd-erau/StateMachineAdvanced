using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingPlayerState : IPlayerState
{
    private float timeSinceJumpStart;
    //private const float jumpDelay = 0.5f;
    private bool canJump = false;
    private const float jumpStrength = 7f;

    public void Enter(Player player)
    {

        //player.GetComponent<Rigidbody>().velocity = new Vector3(0f, jumpStrength, 0f);// .AddForce(0f, 1000f, 0f);
        player.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);
        Debug.Log("Entering jumping State");
        //timeSinceJumpStart = Time.time;
        player._currentState = this;
    }

    public void Execute(Player player)
    {

        if (Physics.Raycast(player.transform.position, Vector3.down, player.transform.localScale.x * 0.52f))
        {
            if (canJump)
            {
                StandingPlayerState standingPlayerState = new StandingPlayerState();
                standingPlayerState.Enter(player);
            }
        }
        else
        {
            canJump = true;
        }
        if (Input.GetKeyDown("s"))
        {
            DivingPlayerState divingPlayerState = new DivingPlayerState();
            divingPlayerState.Enter(player);
        }
    }
}
