using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] GameObject _menuPanel;
    [SerializeField] GameObject _gamePanel;
    [SerializeField] GameObject _gameOverPanel;
    [SerializeField] GameObject _levelCompletePanel;
    [SerializeField] GameObject _settingsPanel;



    [SerializeField] Slider _progressBar;
    [SerializeField] Text _levelText;


    void Start()
    {
        _progressBar.value = 0;
        _gamePanel.SetActive(false);
        _gameOverPanel.SetActive(false);
        _levelCompletePanel.SetActive(false);
        _levelText.text = "LEVEL: " + (ChunkManager._instance.GetLevel()+1);
        _settingsPanel.SetActive(false);
        GameManager.onGameStateChanged += GameStateChangedCallBack;

    }

    void OnDestroy()
    {
        GameManager.onGameStateChanged -= GameStateChangedCallBack;
    }

    // Update is called once per frame
    void Update()
    {
        Update_ProgressBar();
    }

    public void PlayButtonPressed()
    {
        GameManager.instance.SetGameState(GameManager.GameState.GAME);
        _menuPanel.SetActive(false);
        _gamePanel.SetActive(true);
    }

    public void ReplayButtonPressed()
    {
        SceneManager.LoadScene(0);
    }
    private void GameStateChangedCallBack(GameManager.GameState gameState)
    {
        if(gameState == GameManager.GameState.GAMEOVER)
            ShowGameOverPanle();
        else if(gameState == GameManager.GameState.LEVELCOMPLETE)
            ShowLevelCompletePanle();
    }

    public void ShowLevelCompletePanle()
    {
        _gamePanel.SetActive(false);
        _levelCompletePanel.SetActive(true);
    }

    public void ShowGameOverPanle()
    {
        _gamePanel.SetActive(false);
        _gameOverPanel.SetActive(true);
    }

    public void Update_ProgressBar()
    {
        if(!GameManager.instance.IsGameState()) {return;}

        float progress = PlayerController._instance.transform.position.z/ChunkManager._instance.GetFinishZ();
        _progressBar.value =  progress;
    }

    public void ShowSettingsPanel()
    {
        _settingsPanel.SetActive(true);

    }

    public void HideSettingsPanel()
    {
        _settingsPanel.SetActive(false);
    }
}
