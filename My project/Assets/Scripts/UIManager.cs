using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text jumpBoostText;
    private void Start()
    {
        // Initialize UI elements or settings if needed
        UpdateJumpBoostText();
    }
    public void UpdateJumpBoostText()
    {
        // Assuming you have a method to get the current jump boost value
        jumpBoostText.text = PlayerMovement.jumpBoost.ToString();
    }
}
