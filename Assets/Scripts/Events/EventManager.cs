using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : Singleton<EventManager>
{
    public delegate void StateActions();
    public event StateActions MainMenuEvent;
    public event StateActions InGameEvent;
    public event StateActions GameOverEvent;
    public event StateActions EndGameEvent;
    public event StateActions ShopEvent;


    private void Awake()
    {
        // subscribes 

        #region MainMenu Event Subscribe
        MainMenuEvent += UIManager.Instance.MainMenuUIUpdate;
        #endregion

        #region InGame Event Subscribe
        InGameEvent += UIManager.Instance.ChangeMainMenuToInGame;
        #endregion

        #region GameOver Event Subscribe
        GameOverEvent += UIManager.Instance.GameOverUIUpdate;
        GameOverEvent += UIManager.Instance.ChangeInGameToGameOver;
        #endregion

        #region EndGame Event Subscribe
        EndGameEvent += UIManager.Instance.EndGameUIUpdate;
        EndGameEvent += UIManager.Instance.ChangeInGameToEndGame;
        #endregion

        #region Shop Event Subscribe
        MainMenuEvent += UIManager.Instance.ShopUIUpdate;
        ShopEvent += UIManager.Instance.ChangeMainMenuToShop;
        #endregion
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
