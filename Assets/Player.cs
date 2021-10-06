using UnityEngine;

public class Player : MonoBehaviour
{
    public IPlayerState _currentState;

    void Awake()
    {
        _currentState = new StandingPlayerState();   
    }

    void Update()
    {
        _currentState.Execute(this);
    }
}
