using UnityEngine;

public class Player : MonoBehaviour
{
    public int health;
    public TPCamera cam;

    private void Update()
    {
        //if (Input.GetKeyDown(KeyCode.K))
        //{
        //    SaveLoad.SaveGame(this, cam);
        //}
        //if (Input.GetKeyDown(KeyCode.L))
        //{
        //    GameSaveFile gsFile = SaveLoad.LoadGame();
        //    health = gsFile.health;            
        //    ConvertPosition(gsFile.playerPosition, gsFile.cameraPosition);
        //    ConvertRotation(gsFile.playerRotation, gsFile.cameraRotation);
        //}
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    health++;
        //}

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameStateManager.instance.isPaused = !GameStateManager.instance.isPaused;
            GameStateManager.instance.PauseGame();
        }
    }

    public void ConvertPosition(float[] pos)
    {
        Vector3 position;
        position.x = pos[0];
        position.y = pos[1];
        position.z = pos[2];
        transform.position = position;
    }

    public void ConvertRotation(float[] rot)
    {
        Vector3 playerRot;
        playerRot.x = rot[0];
        playerRot.y = rot[1];
        playerRot.z = rot[2];
        transform.eulerAngles = playerRot;
    }

}
