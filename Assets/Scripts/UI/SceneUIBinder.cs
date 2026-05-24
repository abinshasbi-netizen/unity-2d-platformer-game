using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SceneUIBinder : MonoBehaviour
{
    [SerializeField] private Image healthbar;
    [SerializeField] private TextMeshProUGUI stars;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject pausePanel;



    void Start()
    {
        GameManager.Instance.BindUI(
            healthbar,
            stars,
            winPanel,
            gameOverPanel,
            pausePanel
        );
    }
}

