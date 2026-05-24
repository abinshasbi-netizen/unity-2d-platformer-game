using UnityEngine;

public class PauseOptions : MonoBehaviour
{
    public void Pause()
    {
        GameManager.Instance.PauseGame();
    }

    public void Resume()
    {
        GameManager.Instance.ResumeGame();
    }

    public void Restart()
    {
        GameManager.Instance.RestartLevel();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

}
