using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            StateManager.Instance.state = State.GameOver;
        }
        else if (other.CompareTag("Finish"))
        {
            StateManager.Instance.state = State.EndGame;
            PlayerPrefs.SetInt("Level", LevelManager.Instance.CurrentLevel + 1);
        }
        else if (other.CompareTag("Coin"))
        {
            GameManager.Instance.CurrentCoin++;
        }
    }
}
