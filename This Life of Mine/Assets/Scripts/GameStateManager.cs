using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public static GameStateManager instance;
    private void Awake()
    {
        if (instance != null)
        {
            return;
        }

        instance = this;
    }

    public bool isPaused = false;

    public GameObject pauseMenu;

    public Player player;
    new public TPCamera camera;

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

    public void Save()
    {
        SaveLoad.SaveGame(player, camera);
    }

    public void Load()
    {
        GameSaveFile gsFile = SaveLoad.LoadGame();
        player.health = gsFile.health;
        player.ConvertPosition(gsFile.playerPosition);
        player.ConvertRotation(gsFile.playerRotation);
        camera.ConvertPosition(gsFile.cameraPosition);
        camera.ConvertRotation(gsFile.cameraRotation);

    }
}
