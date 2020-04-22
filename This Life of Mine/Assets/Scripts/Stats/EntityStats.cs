using UnityEngine;

public class EntityStats : MonoBehaviour
{
    public Stat damage, armour, maxHealth;

    public int currentHealth { get; private set; }

    private void Awake() => currentHealth = maxHealth.GetValue();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            ReceiveDamage(10);
        }
    }

    public void ReceiveDamage(int _damageAmount)
    {
        _damageAmount -= armour.GetValue();
        _damageAmount = Mathf.Clamp(_damageAmount, 1, int.MaxValue);
        currentHealth -= _damageAmount;

        if (currentHealth <= 0)
        {
            Death();            
        }
    }

    public virtual void Death()
    {
        Debug.Log("Died.");
    }
}
