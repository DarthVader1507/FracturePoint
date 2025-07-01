using UnityEngine;
using UnityEngine.SceneManagement;
public class Door : MonoBehaviour
{
    [SerializeField] private Transform previous_room;
    [SerializeField] private Transform next_room;
    private BoxCollider2D boxCollider;
    private GameObject player;
    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            previous_room.gameObject.SetActive(false);
            next_room.gameObject.SetActive(true);
        }
    }
    private void Update()
    {
        if (player != null && player.transform.position.x > transform.position.x)
        {
            previous_room.gameObject.SetActive(false);
            next_room.gameObject.SetActive(true);
        }
    }
    // Call this to activate the trap (block the door)
    public void ActivateTrap()
    {
        if (boxCollider != null)
        {
            boxCollider.isTrigger = false; // Door blocks player
        }
    }

    // Call this to deactivate the trap (allow passage)
    public void DeactivateTrap()
    {
        if (boxCollider != null)
            boxCollider.isTrigger = true; // Door lets player through
    }
}