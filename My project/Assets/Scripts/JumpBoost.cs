using UnityEngine;
using UnityEngine.UI;
public class JumpBoost : MonoBehaviour
{
    [SerializeField] private Text jumpBoostText;
    [SerializeField] private AudioClip collectSound;

    public void AddBoost()
    {
        PlayerMovement.jumpBoost += 1;
        jumpBoostText.text = PlayerMovement.jumpBoost.ToString();
    }

    public void RemoveBoost()
    {
        if (PlayerMovement.jumpBoost > 0)
        {
            PlayerMovement.jumpBoost -= 1;
            jumpBoostText.text = PlayerMovement.jumpBoost.ToString();
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