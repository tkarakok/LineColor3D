using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{
    public delegate void StateActions();
    public event StateActions MainMenuEvent;
    public event StateActions InGameEvent;
    public event StateActions PauseEvent;
    public event StateActions GameOverEvent;
    public event StateActions EndGameEvent;
    public event StateActions ShopEvent;


    private void Awake()
    {
        // subscribes 
    }

    private void Update()
    {
        switch (StateManager.Instance.state)
        {
            case State.MainMenu:
                MainMenuEvent();
                break;
            case State.InGame:
                InGameEvent();
                break;
            case State.Pause:
                PauseEvent();
                break;
            case State.Shop:
                ShopEvent();
                break;
            case State.GameOver:
                GameOverEvent();
                break;
            case State.EndGame:
                EndGameEvent();
                break;
            default:
                break;
        }
    }
}
