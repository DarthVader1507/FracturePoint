using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private bool grounded=false;
    private CountdownScript countdownScript;
    [Header("Jump Settings")]
    [SerializeField] private AudioClip jumpSound; // Sound to play when jumping
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        countdownScript = FindObjectOfType<CountdownScript>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (!countdownScript.gameStarted)
            return; // Prevent movement before countdown
        float moveInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * 10f, rb.linearVelocity.y);
        if (Input.GetKey(KeyCode.UpArrow) && grounded)
        {
            Jump();
            SoundManager.instance.PlaySound(jumpSound); // Play jump sound
        }
        if (moveInput > 0f)
        {
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (moveInput < 0f)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
        }
        //Set animation parameter
        anim.SetBool("Run", moveInput != 0);
        anim.SetBool("Grounded", grounded);
    }
    private void Jump(){
        rb.AddForce(new Vector2(0f, 7f), ForceMode2D.Impulse);
        anim.SetTrigger("Jump");
        grounded =false;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            grounded = true;
        }
    }
}