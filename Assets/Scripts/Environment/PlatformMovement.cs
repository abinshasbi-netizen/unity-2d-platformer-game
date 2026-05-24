using UnityEngine;

public class PlatformMovement : MonoBehaviour
{

    [SerializeField] private Vector3 moveDirection = Vector3.up;
    [SerializeField] private float speed;
    [SerializeField] private float movedistance;
    private Vector3 startposition;

   
    void Start()
    {
        startposition = transform.position;
        
    }


    void Update()
    {
        float offset = Mathf.Sin(Time.time * speed) * movedistance;

        Vector3 newposition = startposition + moveDirection.normalized * offset;

        transform.position = newposition;
     

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
