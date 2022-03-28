using UnityEngine;
using UnityEngine.UI;

public class AboutManager : MonoBehaviour
{
    public Button BackBtn;
    public static AboutManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }

    private void Start()
    {
        gameObject.SetActive(false);
        BackBtn.onClick.AddListener(Back);
    }

    public void ShowAbout()
    {
        gameObject.SetActive(true);
    }

    private void Back()
    {
        gameObject.SetActive(false);
    }
}
