using System;
using UnityEngine;
using UnityEngine.UI;

[Serializable]
public class MenuManager : MonoBehaviour
{
    private const string IS_STARTED_KEY = "IsStarted";
    private const string TRY_AGAIN_KEY = "TryAgain";
    private const string GAME_OVER_KEY = "GameOver";

    public GameObject Menu;
    public GameObject Canvas;
    
    private GameObject ScorePanel;
    private GameObject LifePanel;        
    
    public Button PlayBtn;
    public Button AboutBtn;
    public Button ExitBtn;

    private bool IsShowing;

    public static MenuManager Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }

    private void Start()
    {
        ScorePanel = GameObject.FindGameObjectWithTag("ScorePanel");
        LifePanel = GameObject.FindGameObjectWithTag("LifePanel");

        if(GetIsStarted() == 0 && GetTryAgain() == 0)
        {            
            PauseGame();
            ShowMenu();
        }
        else
        {
            HideMenu();
        }

        PlayBtn.onClick.AddListener(Play);
        AboutBtn.onClick.AddListener(About);
        ExitBtn.onClick.AddListener(Quit);
    }

    private void Update()
    {

    }

    public void PauseGame(bool setPlayText = true)
    {
        if (GetIsStarted() == 1 && setPlayText)
            GameObject.Find("Play").GetComponentInChildren<Text>().text = "Resume";

        Time.timeScale = 0;
        ToggleGamePanels();
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
        ToggleGamePanels();
    }

    public void HideMenu()
    {
        IsShowing = false;

        Menu.SetActive(IsShowing);
    }

    public void ShowMenu()
    {
        IsShowing = true;

        Menu.SetActive(IsShowing);        
    }

    private void ToggleGamePanels()
    {
        ScorePanel.SetActive(!IsShowing);
        LifePanel.SetActive(!IsShowing);
    }

    public int GetIsStarted()
    {
        var isStarted = PlayerPrefs.GetInt(IS_STARTED_KEY, 0);

        return isStarted;
    }

    public void SetIsStarted(bool value)
    {
        PlayerPrefs.SetInt(IS_STARTED_KEY, value ? 1 : 0);
    }

    private int GetTryAgain()
    {
        var tryAgain = PlayerPrefs.GetInt(TRY_AGAIN_KEY, 0);

        return tryAgain;
    }

    public void SetTryAgain(bool value)
    {
        PlayerPrefs.SetInt(TRY_AGAIN_KEY, value ? 1 : 0);
    }

    public int GetGameOver()
    {
        var gameOver = PlayerPrefs.GetInt(GAME_OVER_KEY, 0);

        return gameOver;
    }

    public void SetGameOver(bool value)
    {
        PlayerPrefs.SetInt(GAME_OVER_KEY, value ? 1 : 0);
    }    

    private void Play()
    {
        SetIsStarted(true);
        HideMenu();
        UnpauseGame();
    }

    private void About()
    {
        AboutManager.Instance.ShowAbout();
    }

    private void Quit()
    {
        SetIsStarted(false);
        Application.Quit();
    }
}
