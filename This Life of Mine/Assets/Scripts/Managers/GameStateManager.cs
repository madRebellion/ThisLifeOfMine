using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    PlayerManager playerManager;

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

    public GameObject pauseMenu, movesMenu, hotBar;

    public PlayerController player;
    public CameraController camera;

    private void Start()
    {
        playerManager = PlayerManager.instance;
        playerManager.controls.SimpleControls.PauseMenu.performed += pause => PauseGame();
    }

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.Return))
        //{
        //    isPaused = !isPaused;
        //    PauseGame();
        //}
    }

    public void PauseGame()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            hotBar.SetActive(false);
            pauseMenu.SetActive(true);
            Time.timeScale = 0f;
            //Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            //player.state = PlayerState.Paused;
        }
        else
        {
            //Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            pauseMenu.SetActive(false);
            Time.timeScale = 1f;
            hotBar.SetActive(true);
            //player.state = PlayerState.Moving;
        }
    }

    public void MovesMenu()
    {
        if (isPaused)
        {
            movesMenu.SetActive(true);
            //Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;

        }
        else
        {
            //Cursor.lockState = CursorLockMode.Locked;
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
        //player.ConvertPosition(gsFile.playerPosition);
        //player.ConvertRotation(gsFile.playerRotation);
        camera.ConvertPosition(gsFile.cameraPosition);
        camera.ConvertRotation(gsFile.cameraRotation);

    }

    //private void OnEnable()
    //{
    //    if (controls == null)
    //        controls = new PlayerControls();

    //    controls.SimpleControls.PauseMenu.performed += _con => PauseGame();
    //    controls.Enable();
    //}
    //private void OnDisable()
    //{
    //    controls.Disable();
    //}
}
