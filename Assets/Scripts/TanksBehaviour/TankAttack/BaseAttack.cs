using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAttack : MonoBehaviour
{
    [SerializeField]
    protected Transform tower;
    [SerializeField]
    protected Transform cannon;
    [SerializeField]
    protected Transform spawnProjectilePoint;
    [SerializeField]
    protected TrajectoryLine trajectoryLine;

    protected float minShotForce = 200f;
    protected float maxShotForce = 400f;
    protected float currentShotForce;

    protected int maxProjectileAmount = 5;
    protected int projectileAmount = 0;

    [Header("DEBUG SETTINGS")]
    [SerializeField, Min(1)]
    protected float projectileMass = 30;

    void Awake()
    {
        currentShotForce = 350f;
    }
}
