using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    // Player HUD = Gameplay UI
    public TextMeshProUGUI PlayerHealthTextMeshProUGUI;
    public TextMeshProUGUI PlayerLevelTextMeshProUGUI;
    public TextMeshProUGUI PlayerPositionTextMeshProUGUI;
    
    //UI Elements
    public GameObject mainMenu;
    public GameObject pauseMenu;
    public GameObject winMenu;
    public GameObject playerHUD;
    
    private PlayerController playerController;
    private GameManager gameManager;
    
    public void Start()
    {
        playerController = GetComponent<PlayerController>();
    }
    
    public void MainMenu()
    {
        mainMenu.SetActive(true);
        pauseMenu.SetActive(false);
        winMenu.SetActive(false);
        playerHUD.SetActive(false);
    }
    
    public void PauseGame()
    {
        mainMenu.SetActive(false);
        pauseMenu.SetActive(true);
        winMenu.SetActive(false);
        playerHUD.SetActive(false);
    }
    
    public void GameOver()
    {
        mainMenu.SetActive(false);
        pauseMenu.SetActive(false);
        winMenu.SetActive(true);
        playerHUD.SetActive(false);
    }
    
    public void PlayerHUD()
    {
        mainMenu.SetActive(false);
        pauseMenu.SetActive(false);
        winMenu.SetActive(false);
        playerHUD.SetActive(true);
        PlayerHealthTextMeshProUGUI.text = "Health: " + playerController.health;
        PlayerLevelTextMeshProUGUI.text = "Level: " + playerController.level;
        PlayerPositionTextMeshProUGUI.text = "Position: " + playerController.transform.position;
    }
    
    public void QuitGame()
    {
        Application.Quit();
    }
}
