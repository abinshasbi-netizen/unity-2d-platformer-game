using UnityEngine;
using System.Collections;

public class Damage : MonoBehaviour
{

    [SerializeField] private int damage;


    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private float hitBlinkDuration = 0.1f;
    [SerializeField] private Color hitColor = Color.red;

    private Color originalColor;

    private void Awake()
    {
        originalColor = spriteRenderer.color;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag("Player")) return;

        collision.GetComponent<PlayerHealth>().TakeDamage(damage);

        AudioManager.instance.PlayFireWoosh();

        
        StartCoroutine(HitBlink());


    }

    private IEnumerator HitBlink()
    {
        spriteRenderer.color = hitColor;
        yield return new WaitForSeconds(hitBlinkDuration);
        spriteRenderer.color = originalColor;
    }


}
