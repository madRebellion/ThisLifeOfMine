using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    EntityStats myStats;

    public float distance;

    private void Start()
    {
        myStats = GetComponent<EntityStats>();
    }

    private void Update()
    {
        distance = DistanceFromPlayer();
    }

    public void Interact()
    {
        EntityCombat p = PlayerManager.instance.player.GetComponent<EntityCombat>();
        p.AttackTarget(myStats);
    }
    
    float DistanceFromPlayer()
    {
        float distanceFromPlayer = Vector3.Distance(PlayerManager.instance.player.transform.position, transform.position);
        return distanceFromPlayer;
    }
}
