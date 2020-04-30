using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : EntityStats
{
    public override void Death()
    {
        base.Death();

        // Death animation;

        // Drop loot here

        Destroy(gameObject);
    }
}
