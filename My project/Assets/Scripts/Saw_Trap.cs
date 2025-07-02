using UnityEngine;

public class Saw_Trap : MonoBehaviour
{
    [Header("Saw Trap Settings")]
    [SerializeField] private float Speed;
    [SerializeField] private float movementDistance;
    private float damage = 0.1f;
    private bool isMovingLeft;
    private float leftEdge;
    private float rightEdge;
    private CountdownScript countdownScript;
    [SerializeField]private AudioClip sawSound;

    private void Awake()
    {
        // Calculate the left and right edges based on the movement distance
        leftEdge = transform.position.x - movementDistance;
        rightEdge = transform.position.x + movementDistance;
        countdownScript = FindObjectOfType<CountdownScript>();
        isMovingLeft = true;
    }
    private void Update()
    {
        if (countdownScript.gameStarted == false)
        {
            return; // Exit if the game has not started
        }
        // Move the saw trap back and forth
        if (isMovingLeft)
        {
            transform.position = new Vector3(
                transform.position.x - (Speed * Time.deltaTime),
                transform.position.y,
                transform.position.z
            );
            if (transform.position.x <= leftEdge)
            {
                isMovingLeft = false;
            }
        }
        else
        {
            transform.position = new Vector3(
                transform.position.x + (Speed * Time.deltaTime),
                transform.position.y,
                transform.position.z
            );
            if (transform.position.x >= rightEdge)
            {
                isMovingLeft = true;
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Health playerHealth = other.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                SoundManager.instance.PlaySound(sawSound);
            }
        }
    }
}
