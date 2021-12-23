using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateManager : Singleton<StateManager> 
{
    public State state;

    void Start()
    {
        state = State.MainMenu;
    }
}
