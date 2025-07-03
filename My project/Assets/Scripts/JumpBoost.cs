using UnityEngine;
using UnityEngine.UI;
public class JumpBoost : MonoBehaviour
{
    [SerializeField] private AudioClip collectSound;
    private UIManager uiManager;

    private void Awake()
    {
        uiManager = FindObjectOfType<UIManager>();
        if (uiManager == null)
        {
            Debug.LogError("UIManager not found in the scene.");
        }
    }
    public void AddBoost()
    {
        PlayerMovement.jumpBoost += 1;
        uiManager.UpdateJumpBoostText();
    }

    public void RemoveBoost()
    {
        if (PlayerMovement.jumpBoost > 0)
        {
            PlayerMovement.jumpBoost -= 1;
            uiManager.UpdateJumpBoostText();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            AddBoost();
            gameObject.SetActive(false);
            SoundManager.instance.PlaySound(collectSound);
        }
    }
}