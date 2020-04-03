using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameSaveFile
{
    public int health;
    public float[] playerPosition, cameraPosition;
    public float[] playerRotation, cameraRotation;
    
   public GameSaveFile(Player p, TPCamera c)
    {
        health = p.health;
        ConvertPosition(p.transform.position, c.transform.position);
        ConvertRotation(p.transform.rotation, c.transform.rotation);
    }

    void ConvertPosition(Vector3 player, Vector3 camera)
    {
        playerPosition = new float[3];
        playerPosition[0] = player.x;
        playerPosition[1] = player.y;
        playerPosition[2] = player.z;

        cameraPosition = new float[3];
        cameraPosition[0] = camera.x;
        cameraPosition[1] = camera.y;
        cameraPosition[2] = camera.z;
    }

    void ConvertRotation(Quaternion player, Quaternion camera)
    {
        playerRotation = new float[3];
        playerRotation[0] = player.x;
        playerRotation[1] = player.y;
        playerRotation[2] = player.z;

        cameraRotation = new float[3];
        cameraRotation[0] = camera.x;
        cameraRotation[1] = camera.y;
        cameraRotation[2] = camera.z;
    }
}
