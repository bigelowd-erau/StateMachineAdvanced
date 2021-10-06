using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReduceToAtomsPlayerState : IPlayerState
{
    // Start is called before the first frame update
    public void Enter(Player player)
    {
        Debug.Log("Entering Standing State");
        player._currentState = this;
    }

    public void Execute(Player player)
    {
        player.GetComponent<Rigidbody>().transform.localScale *= 0.99f;
    }
}
