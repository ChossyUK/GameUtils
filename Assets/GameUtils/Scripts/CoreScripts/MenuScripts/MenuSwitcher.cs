using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuSwitcher : MonoBehaviour
{

    #region Canvas & Selected Items Variables
    // Add or remove canvas & 1st selected item variables below
    [Header("Menu Canvas's")]
    public Canvas mainMenu;
    public Canvas pauseMenu;
    public Canvas optionsMenu;
    public Canvas optionsGame;
    public Canvas gameOver;
    public Canvas gameWon;

    [Header("Menu's 1st Selected Items")]
    public GameObject mainMenuButton;
    public GameObject pauseMenuButton;
    public GameObject optionsMainButton;
    public GameObject optionsGameButton;
    public GameObject gameOverMenu;
    public GameObject gameWonMenu;

    [Header("Auto Select Button")]
    public bool use1stSelectedItem = false;
    #endregion

    #region Menu Methods
    // Add or remove open/close menu methods below
    public void OpenMainMenu()
    {
        mainMenu.gameObject.SetActive(true);
        if(use1stSelectedItem)
        {
            SetFirstItem(mainMenuButton);
        }
    }

    public void CloseMainMenu()
    {
        mainMenu.gameObject.SetActive(false);
    }

    public void OpenPauseMenu()
    {
        pauseMenu.gameObject.SetActive(true);
        if (use1stSelectedItem)
        {
            SetFirstItem(pauseMenuButton);
        }
    }

    public void ClosePauseMenu()
    {
        pauseMenu.gameObject.SetActive(false);
    }

    public void OpenOptionsMenu()
    {
        optionsMenu.gameObject.SetActive(true);
        if (use1stSelectedItem)
        {
            SetFirstItem(optionsMainButton);
        }
    }

    public void CloseOptionsMenu()
    {
        optionsMenu.gameObject.SetActive(false);
    }

    public void OpenOptionsGame()
    {
        optionsGame.gameObject.SetActive(true);
        if (use1stSelectedItem)
        {
            SetFirstItem(optionsGameButton);
        }
    }

    public void CloseOptionsGame()
    {
        optionsGame.gameObject.SetActive(false);
    }

    public void OpenGameOverMenu()
    {
        gameOver.gameObject.SetActive(true);
        if (use1stSelectedItem)
        {
            SetFirstItem(gameOverMenu);
        }
    }

    public void CloseGameOverMenu()
    {
        gameOver.gameObject.SetActive(false);
    }

    public void OpenGameWonMenu()
    {
        gameWon.gameObject.SetActive(true);
        if (use1stSelectedItem)
        {
            SetFirstItem(gameWonMenu);
        }
    }

    public void CloseGameWonMenu()
    {
        gameWon.gameObject.SetActive(false);
    }

    // Method to set the 1st selected item
    public void SetFirstItem(GameObject selectedItem)
    {
        EventSystem.current.SetSelectedGameObject(null);                // Null the events system
        EventSystem.current.SetSelectedGameObject(selectedItem);        // Set the first selected menu item
    }
    #endregion

}
