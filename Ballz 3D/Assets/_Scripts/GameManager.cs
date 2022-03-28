using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GameState
{
    Shooting,
    Aiming,
}
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    GameState _currentState = GameState.Aiming;
    public int level { get; private set; }

    void Awake()
    {
        if(Instance != null)
        {
            Destroy(this);
            return;
        }

        Instance = this;
    }

    public void SwitchState(GameState newState)
    {
        _currentState = newState;

        switch(_currentState)
        {
            case GameState.Aiming:
                break;
            case GameState.Shooting:
                break;
        }
    }



    public void nextLevel()
    {
        level += 1;
    }
}
