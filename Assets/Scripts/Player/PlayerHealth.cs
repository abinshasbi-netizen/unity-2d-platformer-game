using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int current_health;
    private int max_health=100;
    private bool isdead = false;

    [SerializeField] private Animator Animator;
    void Start()
    {
        current_health = max_health;
    }

    public void TakeDamage(int damage) { 

        current_health-= damage;
        current_health=Mathf.Max(current_health, 0);
        GameManager.Instance.UpdateHealthUI(current_health,max_health);
    
    }
    void Update()
    {
        if (current_health <= 0) { 

            GameManager.Instance.GameOver();
            AudioManager.instance.PlayGameOver();
            isdead = true;

            Animator.SetBool("isDead", isdead);
            
        
        }
    }
}
