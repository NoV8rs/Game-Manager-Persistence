using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    // Gameplay UI for the player, showing the player's health, money, experience, and level.
    public GameObject gamePlayUI;
    public PlayerController playerController;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI moneyText;
    public TextMeshProUGUI experienceText;
    public TextMeshProUGUI levelText;
    
    // Main Menu UI for the player, showing the main menu GameObjects.
    public GameObject mainMenu;

    private void Update()
    {
        if (playerController != null)
        {
            healthText.text = "Player Health: " + playerController.health;
            moneyText.text = "Player Money: " + playerController.money;
            experienceText.text = "Player XP: " + playerController.experience;
            levelText.text = "Player Level: " + playerController.level;
        }
    }

    public void UIChange()
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            mainMenu.SetActive(true);
            gamePlayUI.SetActive(false);
        }
        else
        {
            mainMenu.SetActive(false);
            gamePlayUI.SetActive(true);
        }
    }
}
