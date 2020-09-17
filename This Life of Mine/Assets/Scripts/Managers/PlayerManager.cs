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
    public PlayerControls controls;
        
    private void FixedUpdate()
    {
        //if (HUDManager.instance.isInteracting)
        //{
        //    if (player.lookTarget != null)
        //    {
        //        player.LookAtTarget(player.lookTarget);
        //    }

        //    player.StopAnimating();
        //}
    }

    //Load order = Awake -> OnEnable -> Start
    private void OnEnable()
    {
        if (controls == null)
            controls = new PlayerControls();

        controls.Enable();
    }
    private void OnDisable()
    {
        controls.Disable();
    }
}
