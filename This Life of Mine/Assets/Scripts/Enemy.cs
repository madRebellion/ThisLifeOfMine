using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Interactable
{
    PlayerManager playerManager;
    EntityStats myStats;

    public float distance;

    private void Start()
    {
        playerManager = PlayerManager.instance;
        myStats = GetComponent<EntityStats>();
    }

    private void Update()
    {
        distance = DistanceFromPlayer();
    }

    public override void Interact()
    {
        base.Interact();

        EntityCombat player = playerManager.player.GetComponent<EntityCombat>();
        player.AttackTarget(myStats);
    }
    
    float DistanceFromPlayer()
    {
        float distanceFromPlayer = Vector3.Distance(playerManager.player.transform.position, transform.position);
        return distanceFromPlayer;
    }
}
