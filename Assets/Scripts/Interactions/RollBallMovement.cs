using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class RollBallMovement : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float velocity;


    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb.linearVelocityX = velocity;
    }
}
