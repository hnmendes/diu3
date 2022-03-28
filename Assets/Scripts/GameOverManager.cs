using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    public Button GameOverExit;
    public Button GameOverTryAgain;

    public static GameOverManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;        
    }

    void Start()
    {
        gameObject.SetActive(false);
        GameOverExit.onClick.AddListener(ExitGame);
        GameOverTryAgain.onClick.AddListener(TryAgain);
    }

    public void ShowGameOver()
    {
        MenuManager.Instance.SetGameOver(true);
        MenuManager.Instance.SetIsStarted(false);
        LifeManager.Instance.RestartLifeNumber();
        gameObject.SetActive(true);
        MenuManager.Instance.PauseGame(false);
    }

    private void ExitGame()
    {
        MenuManager.Instance.SetIsStarted(false);
        LifeManager.Instance.RestartLifeNumber();
        MenuManager.Instance.SetGameOver(false);
        Application.Quit();
    }

    private void TryAgain()
    {
        MenuManager.Instance.SetGameOver(false);
        MenuManager.Instance.SetTryAgain(true);
        LifeManager.Instance.RestartLifeNumber();        
        SceneManager.LoadScene("Level1", LoadSceneMode.Single);
        MenuManager.Instance.UnpauseGame();
    }
}
