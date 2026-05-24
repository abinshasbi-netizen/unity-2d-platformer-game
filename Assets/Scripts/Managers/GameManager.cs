using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    private Image healthbar;
    private TextMeshProUGUI stars;

    private int starnum;

     private GameObject winPanel;
     private GameObject gameOverPanel;

    private bool isPaused;
    private GameObject pausePanel;



    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        Debug.Log($"OnSceneLoaded fired for scene: {scene.name}");
        Time.timeScale = 1f;

        healthbar = GameObject.Find("HealthBar_Fill")?.GetComponent<Image>();
        stars = GameObject.Find("StarsText")?.GetComponent<TextMeshProUGUI>();

        Canvas canvas = FindObjectOfType<Canvas>(true);

        Button pauseButton = GameObject.Find("PauseButton")?.GetComponent<Button>();

        if (pauseButton != null)
        {
            pauseButton.onClick.RemoveAllListeners();
            pauseButton.onClick.AddListener(TogglePause);
        }
        else
        {
            Debug.LogError("PauseButton not found in scene!");
        }

        if (canvas == null)
        {
            Debug.LogError("Canvas not found in scene!");
            return;
        }

        foreach (Transform t in canvas.GetComponentsInChildren<Transform>(true))
        {
            if (t.name == "PausePanel")
                pausePanel = t.gameObject;

            if (t.name == "WinPanel")
                winPanel = t.gameObject;

            if (t.name == "GameOverPanel")
                gameOverPanel = t.gameObject;
        }

        if (pausePanel == null)
            Debug.LogError("PausePanel not found in scene!");
        else
            pausePanel.SetActive(false);

        if (winPanel != null) winPanel.SetActive(false);
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
    }

    private void Awake()
    {
        
        starnum = 0;

        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        


    }

    void Start()
    {
        AudioManager.instance.PlayBackgroundMusic();
    }

    
    void Update()
    {
        
    }
    public void UpdateHealthUI(int current_health, int max_health)
    {


        float fill = (float)current_health / max_health;


        healthbar.fillAmount = fill;
        if (healthbar.color == Color.green)
        {

            healthbar.color = Color.yellow;

        }
        else {
            healthbar.color = Color.red;

        }
    }
    public void UpdateStarsTaken() {

        starnum++;

        stars.text = $"Stars : {starnum}";
    
    }
    public void GameOver() {

        Time.timeScale = 0f;
        if (gameOverPanel != null)
            gameOverPanel.SetActive(true);
        else
            Debug.LogError("GameOverPanel not found in scene!");


    }
    public void WinLevel()
    {

        Time.timeScale = 0f;
        winPanel.SetActive(true);


    }

    public void LoadNextLevel()
    {
        Time.timeScale = 1f;
        int current = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(current + 1);
    }
    public void BindUI(
    Image hb,
    TextMeshProUGUI st,
    GameObject win,
    GameObject gameOver,
    GameObject pause)
    {
        healthbar = hb;
        stars = st;
        winPanel = win;
        gameOverPanel = gameOver;
        pausePanel = pause;

        if (winPanel != null) winPanel.SetActive(false);
        if (gameOverPanel != null) gameOverPanel.SetActive(false);
        if (pausePanel != null) pausePanel.SetActive(false);
    }


    public void PauseGame()
    {
        if (isPaused) return;

        Time.timeScale = 0f;
        isPaused = true;

        if (pausePanel != null)
            pausePanel.SetActive(true);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        isPaused = false;

        if (pausePanel != null)
            pausePanel.SetActive(false);
    }

    public void RestartLevel()
    {
        Time.timeScale = 1f;
        isPaused = false;

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void TogglePause()
    {
        if (pausePanel == null)
        {
            Debug.LogError("PausePanel is NULL");
            return;
        }

        bool isPaused = pausePanel.activeSelf;
        pausePanel.SetActive(!isPaused);
        Time.timeScale = isPaused ? 1f : 0f;
    }



}
