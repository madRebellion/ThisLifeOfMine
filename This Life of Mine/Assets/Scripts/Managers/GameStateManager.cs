using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    #region Singleton
    public static GameStateManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }

        instance = this;
    }
    #endregion

    public bool isPaused = false;

    public GameObject pauseMenu, movesMenu;

    public Player player;
    public CameraController camera;

    public void PauseGame()
    {
        if (isPaused)
        {
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    public void MovesMenu()
    {
        if (isPaused)
        {
            movesMenu.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            movesMenu.SetActive(false);
        }
    }

    public void Save()
    {
        SaveLoad.SaveGame(player, camera);
    }

    public void Load()
    {
        GameSaveFile gsFile = SaveLoad.LoadGame();
        //player.health = gsFile.health;
        player.ConvertPosition(gsFile.playerPosition);
        player.ConvertRotation(gsFile.playerRotation);
        camera.ConvertPosition(gsFile.cameraPosition);
        camera.ConvertRotation(gsFile.cameraRotation);

    }
}
