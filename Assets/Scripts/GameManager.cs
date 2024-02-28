using System;
using UnityEngine;

public class GameManager : MonoBehaviour, IGameManager
{
    private GameObject playerTankGameObject, enemyTankGameObject;

    private ITank playerTankComponent;
    private ITank enemyTankComponent;

    public event Action OnPlayerMovementEnded;
    public event Action OnEnemyMovementEnded;
    public event Action OnPlayerAttackEnded;
    public event Action OnEnemyAttackEnded;
    public event Action OnNewTurnMouseButtonClicked;

    public ITank GetPlayerTank()
    {
        return playerTankComponent;
    }

    public ITank GetEnemyTank()
    {
        return enemyTankComponent;
    }

    void Awake()
    {
        playerTankGameObject = GameObject.FindGameObjectWithTag("Player");
        playerTankComponent = playerTankGameObject.GetComponent<Tank>();
        playerTankComponent.InitializeTank(
            playerTankGameObject.GetComponent<IMovable>(),
            playerTankGameObject.GetComponent<IAttackable>()
        );

        enemyTankGameObject = GameObject.FindGameObjectWithTag("Enemy");
        enemyTankComponent = enemyTankGameObject.GetComponent<Tank>();
        enemyTankComponent.InitializeTank(
            enemyTankGameObject.GetComponent<IMovable>(),
            enemyTankGameObject.GetComponent<IAttackable>()
        );
    }

    public void IsPlayerMovementEnded()
    {
        if(playerTankComponent.HasArrivedToDestination()) OnPlayerMovementEnded();
    }

    
    public void IsEnemyMovementEnded()
    {
        if(enemyTankComponent.HasArrivedToDestination()) OnEnemyMovementEnded();
    }

    public void PlayerMove()
    {
        playerTankComponent.Move();
    }

    public void EnemyMove()
    {
        enemyTankComponent.Move();
    }

    public void PlayerAttack()
    {
        if(!ProjectilePool.Instance.projectileActive)
        {
            playerTankComponent.Attack();
        }
    }

    public void EnemyAttack()
    {
        if(!ProjectilePool.Instance.projectileActive)
        {
            enemyTankComponent.Attack();
        }
    }

    public bool IsEnemyDead()
    {
        return playerTankComponent.IsDead();
    }

    public bool IsPlayerDead()
    {
        return enemyTankComponent.IsDead();
    }
}
