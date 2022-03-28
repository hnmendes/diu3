using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource Music1;
    public AudioSource Music2;

    public static MusicManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }

    public void StartMusic1()
    {
        Music1.Play();
    }

    public void StartMusic2()
    {
        Music2.Play();
    }

    public void StopMusic1()
    {
        Music1.Stop();
    }

    public void StopMusic2()
    {
        Music2.Stop();
    }
}
