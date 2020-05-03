using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    #region Singleton
    public static PlayerManager instance;
    private void Awake()
    {
        if (instance != null)
            return;
        instance = this;
    }
    #endregion

    public Player player;

    private void FixedUpdate()
    {
        if (HUDManager.instance.isInteracting)
        {
            if (player.lookTarget != null)
            {
                player.LookAtTarget(player.lookTarget);
            }

            player.StopAnimating();
        }
    }      
}
