using Unity.VisualScripting;
using UnityEngine;

public class FireballMovement1 : MonoBehaviour
{
    [SerializeField] private Vector3 moveDirection = Vector3.right;
    [SerializeField] private float speed;
    [SerializeField] private float movedistance;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Vector3 startposition;

    private float lastY;
    void Start()
    {
        startposition = transform.position;
        lastY = startposition.y;
    }

    
    void Update()
    {
        float offset= Mathf.Sin(Time.time *speed)*movedistance;

       Vector3 newposition= startposition+ moveDirection.normalized*offset;

        transform.position = newposition;

        float deltay = transform.position.y - lastY;

        if (deltay > 0.001f)
        {

            spriteRenderer.flipX = false;
        }
        else if (deltay < -0.001f)
        {

            spriteRenderer.flipX = true;

        }

        lastY = newposition.y;


    }
}
