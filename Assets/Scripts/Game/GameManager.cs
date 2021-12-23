using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
    private int _currentCoin;
    private int _totalCoin;

    public int CurrentCoin { get => _currentCoin; set => _currentCoin = value; }
    public int TotalCoin { get => _totalCoin; set => _totalCoin = value; }
}
