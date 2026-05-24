using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    private Vector2 moveInput;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private float speed;
    [SerializeField] private float jumpforce;

    private bool grounded;

    [SerializeField] private Animator animator;
    [SerializeField] private SpriteRenderer spriterenderer;

    private int jumpcounter;
    private bool isRunningSound;



    private void Awake()
    {
        

        rb = GetComponent<Rigidbody2D>();
    }

    



    void Start()
    {
        jumpcounter = 0;
    }

    public void OnMove(InputValue value) {

        moveInput=value.Get<Vector2>();
        
    }
    public void OnJump(InputValue value) {

        if (!value.isPressed) return;
        if (jumpcounter>=1) return;


        rb.linearVelocity = new Vector2(rb.linearVelocity.x, 0f);
        rb.AddForce(Vector2.up * jumpforce, ForceMode2D.Impulse);
        jumpcounter++;
        animator.SetTrigger("Jump");
        AudioManager.instance.PlayJump();
    }
    void Update()
    {
        grounded = GroundCheck.GroundChecked();

        animator.SetBool("isGrounded", grounded);
        animator.SetBool("isRunning", Mathf.Abs(moveInput.x) > 0.1f);

        if (moveInput.x > 0)
            spriterenderer.flipX = false;
        else if (moveInput.x < 0)
            spriterenderer.flipX = true;
        animator.SetBool("isAir", grounded != true && rb.linearVelocityY < 0);

        if (grounded) {

            jumpcounter = 0;
        
        }
        if (transform.position.y < -6f) {

            GameManager.Instance.GameOver();
            AudioManager.instance.PlayGameOver();
        
        }

        if (grounded && Mathf.Abs(moveInput.x) > 0.1f)
        {
            if (!isRunningSound)
            {
                AudioManager.instance.StartRun();
                isRunningSound = true;
            }
        }
        else
        {
            if (isRunningSound)
            {
                AudioManager.instance.StopRun();
                isRunningSound = false;
            }
        }





    }
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(

            moveInput.x*speed*Time.fixedDeltaTime,
            rb.linearVelocityY
            
            );

       

    }
}
