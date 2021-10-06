using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingPlayerState : IPlayerState
{
    private float floatStartTime;
    private float initialHeight;
    private const float floatDistScaler = 0.5f;

    public void Enter(Player player)
    {
        //player.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpStrength, ForceMode.Impulse);
        Debug.Log("Entering Floating State");
        initialHeight = player.transform.position.y;
        player.GetComponent<Rigidbody>().useGravity = false;
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        floatStartTime = Time.time;
        player._currentState = this;
    }

    public void Execute(Player player)
    {
        player.transform.position = new Vector3(
            player.transform.position.x,
            initialHeight + Mathf.Sin(Time.time - floatStartTime)* floatDistScaler,
            player.transform.position.z);

        if (Input.GetKeyDown("s"))
        {
            player.GetComponent<Rigidbody>().useGravity = true;            
            DivingPlayerState divingPlayerState = new DivingPlayerState();
            divingPlayerState.Enter(player);
        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            player.GetComponent<Rigidbody>().useGravity = true;
            FallingPlayerState fallingPlayerState = new FallingPlayerState();
            fallingPlayerState.Enter(player);
        }
        else if (Input.GetKeyDown("r"))
        {
            ReduceToAtomsPlayerState reduceToAtomsPlayerState = new ReduceToAtomsPlayerState();
            reduceToAtomsPlayerState.Enter(player);
        }
    }
}
