using System.Collections;
using UnityEngine;

public class AIAttack : BaseAttack, IAttackable
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float maxLaunchAngle = 45f;
    [SerializeField]
    private float maxErrorMagnitude = 0.1f;
    [SerializeField]
    private float maxDistanceForError = 100f;

    private bool IsReadyToAttack()
    {
        return target != null;
    }

    public void Attack()
    {
        if(target == null) 
            target = GameObject.FindGameObjectWithTag("Player").transform;

        if (IsReadyToAttack())
            StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        yield return new WaitForSeconds(1.5f);

        RotateTower();
        
        yield return new WaitForSeconds(1.5f);

        FireAtTarget();
    }

    private void RotateTower(){
        Vector3 targetPosition = target.position + CalculateAimErrorOffset();

        Vector3 horizontalDirection = new Vector3(targetPosition.x - tower.position.x, 0, targetPosition.z - tower.position.z);
        tower.LookAt(tower.position + horizontalDirection);
    }

    void FireAtTarget(){
        Vector3 targetPosition = target.position + CalculateAimErrorOffset();
        float targetAngle;
        
        // Calcular el ángulo y la velocidad del lanzamiento necesario
        float missileVelocity = CalculateLaunchVelocity(targetPosition, out targetAngle);
        
        if (missileVelocity > 0 && targetAngle != float.NaN){
            cannon.localEulerAngles = new Vector3(-targetAngle, 0, 0);
            FireProjectile(missileVelocity);
            Debug.Log("Fired at angle: " + targetAngle + " with velocity: " + missileVelocity);
        }
        else
        {
            Debug.Log("Target out of range");
        }
    }

    private Vector3 CalculateAimErrorOffset(){
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        float errorRatio = Mathf.Clamp(distanceToTarget / maxDistanceForError, 0f, 1f);
        float errorMagnitude = errorRatio * maxErrorMagnitude;

        return (UnityEngine.Random.insideUnitSphere * errorMagnitude);
    }

    float CalculateLaunchVelocity(Vector3 targetPosition, out float launchAngle){
        float g = Physics.gravity.magnitude;
        float y = targetPosition.y - spawnProjectilePoint.transform.position.y; // Diferencia de altura
        float x = Mathf.Sqrt(Mathf.Pow(targetPosition.x - spawnProjectilePoint.transform.position.x, 2) + Mathf.Pow(targetPosition.z - spawnProjectilePoint.transform.position.z, 2)); // Distancia horizontal

        float angleRadians = Mathf.Deg2Rad * maxLaunchAngle; // Convertir ángulo a radianes

        // Fórmula para calcular la velocidad inicial necesaria para un lanzamiento parabólico
        float v = Mathf.Sqrt(g * x * x / (2 * Mathf.Cos(angleRadians) * Mathf.Cos(angleRadians) * (x * Mathf.Tan(angleRadians) - y)));
        
        if (!float.IsNaN(v) && !float.IsInfinity(v)){
            launchAngle = maxLaunchAngle;
            return v;
        }else{
            launchAngle = 0;
            return 0; // No es posible alcanzar el objetivo
        }
    }

    private void FireProjectile(float velocity){
        GameObject projectile = ProjectilePool.Instance.GetObject();
        projectile.transform.position = spawnProjectilePoint.position;

        Rigidbody missileRb = projectile.GetComponent<Rigidbody>();
        missileRb.velocity = cannon.forward * velocity;
    }
}
