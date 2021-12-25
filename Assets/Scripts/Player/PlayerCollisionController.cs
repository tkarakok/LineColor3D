using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    public int collectCoin;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            StateManager.Instance.state = State.GameOver;
        }
        else if (other.CompareTag("Finish"))
        {
            StateManager.Instance.state = State.EndGame;
            GameManager.Instance.CurrentCoin = collectCoin;
            PlayerPrefs.SetInt("Coin", (GameManager.Instance.TotalCoin + GameManager.Instance.CurrentCoin));
            PlayerPrefs.SetInt("Level", LevelManager.Instance.CurrentLevel + 1);
        }
        else if (other.CompareTag("Coin"))
        {
            GameManager.Instance.CurrentCoin++;
        }
    }
}
