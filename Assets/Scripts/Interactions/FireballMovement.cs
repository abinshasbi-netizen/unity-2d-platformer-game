using Unity.VisualScripting;
using UnityEngine;

public class FireballMovement : MonoBehaviour
{
    [SerializeField] private Vector3 moveDirection = Vector3.right;
    [SerializeField] private float speed;
    [SerializeField] private float movedistance;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private Vector3 startposition;

    private float lastX;
    void Start()
    {
        startposition = transform.position;
        lastX = startposition.x;
    }

    
    void Update()
    {
        float offset= Mathf.Sin(Time.time *speed)*movedistance;

       Vector3 newposition= startposition+ moveDirection.normalized*offset;

        transform.position = newposition;

        float deltax = transform.position.x - lastX;

        if (deltax > 0.001f)
        {

            spriteRenderer.flipX = false;
        }
        else if (deltax < -0.001f)
        {

            spriteRenderer.flipX = true;

        }

        lastX = newposition.x;


    }
}
