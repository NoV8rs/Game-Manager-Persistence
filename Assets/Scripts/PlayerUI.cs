using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public TextMeshProUGUI PlayerHealthTextMeshProUGUI;
    public TextMeshProUGUI PlayerLevelTextMeshProUGUI;
    public TextMeshProUGUI PlayerPositionTextMeshProUGUI;
    
    private PlayerController playerController;
    
    public void Start()
    {
        playerController = GetComponent<PlayerController>();
    }
    
    public void Update()
    {
        PlayerHealthTextMeshProUGUI.text = "Health: " + playerController.health;
        PlayerLevelTextMeshProUGUI.text = "Level: " + playerController.level;
        PlayerPositionTextMeshProUGUI.text = "Position: " + playerController.transform.position;
    }
}
