using UnityEngine;

public class Tank : MonoBehaviour, ITank, IDamagable
{
    [SerializeField] private IMovable moveBehaviour;
    [SerializeField] private IAttackable attackBehaviour;

    private int maxHealth = 5;
    private int currentHealth;

    public int GetHealth()
    {
        return currentHealth;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public void InitializeTank(IMovable movable, IAttackable attackable)
    {
        moveBehaviour = movable;
        attackBehaviour = attackable;
        currentHealth = maxHealth;
    }

    public void Attack()
    {
        attackBehaviour.Attack();
    }

    public void Move()
    {
        moveBehaviour.Move();
    }

    public void TakeDamage(int damageTaken)
    {
        currentHealth = currentHealth - damageTaken == 0 ? 0 : currentHealth - damageTaken;
    }

    public bool IsDead()
    {
        return currentHealth <= 0;
    }

    public bool HasArrivedToDestination()
    {
        return moveBehaviour.IsAgentDestinationReached();
    }
}