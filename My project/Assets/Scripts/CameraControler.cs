using UnityEngine;

public class CameraControler : MonoBehaviour
{
    //Follow player
    [SerializeField]private float speed;
    [SerializeField]private Transform player;
    [SerializeField]private float aheadDistance;
    [SerializeField]private AudioClip music;
    private float lookAhead;
    private bool isPlaying=false;
    private CountdownScript countdownScript;
    [SerializeField]private GameObject deathPanel;
    private Health healthScript;
    private void Start()
    {
        countdownScript = FindObjectOfType<CountdownScript>();
        healthScript = FindObjectOfType<Health>();
    }
    private void FixedUpdate()
    {
        transform.position = new Vector3(player.position.x + lookAhead, transform.position.y, transform.position.z);
        lookAhead = Mathf.Lerp(lookAhead, (aheadDistance * player.localScale.x), speed * Time.deltaTime);
        Vector3 viewPos = Camera.main.WorldToViewportPoint(player.position);
        if (viewPos.y < 0f && !isPlaying && !(healthScript.isDead))
        {
            SoundManager.instance.PlaySound(music);
            isPlaying = true;
            countdownScript.gameStarted = false;
            Time.timeScale = 0f;
            deathPanel.SetActive(true);
            healthScript.isDead = true;
        }
    }
}
