using UnityEngine;

public class StarCollection : MonoBehaviour
{
    [SerializeField] private bool isWinStar;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        Destroy(gameObject);

        GameManager.Instance.UpdateStarsTaken();

        if (isWinStar) {

            GameManager.Instance.WinLevel();
            AudioManager.instance.StopBackgroundMusic();
            AudioManager.instance.PlayWinLevel();

            return;
        
        }
        

        AudioManager.instance.PlaystarCollect();



    }


}
