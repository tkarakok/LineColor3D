using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : Singleton<UIManager>
{
    public GameObject mainMenuPanel, inGamePanel, gameOverPanel, endGamePanel, shopPanel;
    public Text levelText, mainMenuCoinText, gameOverCoinText, endGameEarnedCoinText, endGameTotalCoinText, shopCoinText, gameOverCompleteText;
    public Slider levelProgressBar;
   
    
    private void Start()
    {
        levelText.text = "LEVEL " + (LevelManager.Instance.CurrentLevel + 1).ToString();
    }

    #region Change Slider Parent
    public void ChangeSliderParent(Transform pointSlider)
    {
        levelProgressBar.transform.SetParent(null);
        levelProgressBar.transform.SetParent(pointSlider);
        levelProgressBar.transform.position = pointSlider.GetChild(0).transform.position;
    }
    #endregion

    #region Button Functions
    public void StartButton()
    {
        StateManager.Instance.state = State.InGame;
        
    }
    public void RestartButton()
    {
        LevelManager.Instance.ChangeLevel("LEVEL " + LevelManager.Instance.CurrentLevel);
    }
    public void NextLevelButton()
    {
        LevelManager.Instance.ChangeLevel("LEVEL " + LevelManager.Instance.CurrentLevel);
    }
    #endregion

    #region Panel Change Functions
    // Main Menu Panel
    public void ChangeMainMenuToInGame()
    {
        ChangeSliderParent(inGamePanel.transform);
        mainMenuPanel.SetActive(false);
        inGamePanel.SetActive(true);
    }
    public void ChangeMainMenuToShop()
    {
        mainMenuPanel.SetActive(false);
        shopPanel.SetActive(true);
    }
    // In Game Panel
    public void ChangeInGameToGameOver()
    {
        ChangeSliderParent(gameOverPanel.transform);
        inGamePanel.SetActive(false);
        gameOverPanel.SetActive(true);
    }
    public void ChangeInGameToEndGame()
    {
        ChangeSliderParent(endGamePanel.transform);
        inGamePanel.SetActive(false);
        endGamePanel.SetActive(true);
    }

    #endregion

    #region UI UPDATE 
    public void MainMenuUIUpdate()
    {
        mainMenuCoinText.text = GameManager.Instance.TotalCoin.ToString();
    } 

    public void GameOverUIUpdate()
    {
        gameOverCoinText.text = GameManager.Instance.TotalCoin.ToString();
        gameOverCompleteText.text = "%" +PathFollower.Instance.GetRoadCompletedPercentile().ToString() + " COMPLETED !";
    }

    public void EndGameUIUpdate()
    {
        endGameTotalCoinText.text = GameManager.Instance.TotalCoin.ToString();
        endGameEarnedCoinText.text = GameManager.Instance.CurrentCoin.ToString();
    }

    public void ShopUIUpdate()
    {
        shopCoinText.text = GameManager.Instance.TotalCoin.ToString();
    }
    #endregion



}
