using System;

public interface IGameManager
{
    public event Action OnPlayerMovementEnded;
    public event Action OnEnemyMovementEnded;
    public event Action OnPlayerAttackEnded;
    public event Action OnEnemyAttackEnded;
    public ITank GetPlayerTank();
    public ITank GetEnemyTank();
    public void PlayerMove();
    public void IsPlayerMovementEnded();
    public void EnemyMove();
    public void IsEnemyMovementEnded();
    public void PlayerAttack();
    public void EnemyAttack();
    public bool IsPlayerDead();
    public bool IsEnemyDead();
}
