using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityCombat : MonoBehaviour
{
    EntityStats thisStat;

    public float attackSpeed = 1f;
    public float attackDelay = 0.6f;
    float attackCooldown = 0;

    public event System.Action OnAttack;

    private void Start()
    {
        thisStat = GetComponent<EntityStats>();
    }

    private void Update()
    {
        attackCooldown -= Time.deltaTime;
    }

    public void AttackTarget(EntityStats targetStats)
    {
        if (attackCooldown <= 0)
        {
            StartCoroutine(DealDamage(targetStats, attackDelay));

            if (OnAttack != null)
                OnAttack();

            attackCooldown = 1f / attackSpeed;
        }
    }

    IEnumerator DealDamage(EntityStats stats, float animDelay)
    {
        yield return new WaitForSeconds(animDelay);
        stats.ReceiveDamage(thisStat.damage.GetValue());
    }
}
