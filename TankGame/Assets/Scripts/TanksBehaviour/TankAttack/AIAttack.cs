using System.Collections;
using UnityEngine;

public class AIAttack : BaseAttack, IAttackable
{
    [SerializeField]
    private Transform target;
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

        Vector3 aimPoint = target.position + CalculateAimErrorOffset();
        //aimPoint += new Vector3(0f, 1f, 0f);
        cannonTower.LookAt(aimPoint);

        float initialVelocity = CalculateInitialVelocity(aimPoint);
        float desiredForce = Mathf.Clamp(initialVelocity * projectileMass, minShotForce, maxShotForce);
        
        yield return new WaitForSeconds(1.5f);

        FireProjectile(desiredForce);
    }

    private Vector3 CalculateAimErrorOffset()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);
        float errorRatio = Mathf.Clamp(distanceToTarget / maxDistanceForError, 0f, 1f);
        float errorMagnitude = errorRatio * maxErrorMagnitude;

        return (UnityEngine.Random.insideUnitSphere * errorMagnitude);
    }

    private float CalculateInitialVelocity(Vector3 aimPoint)
    {
        float distanceToAimPoint = Vector3.Distance(transform.position, aimPoint);
        float angleInRads = cannonTower.localEulerAngles.x * Mathf.Deg2Rad;

        return Mathf.Sqrt(distanceToAimPoint * Physics.gravity.magnitude / Mathf.Sin(2 * angleInRads));
    }

    private void FireProjectile(float force)
    {
        GameObject projectile = ProjectilePool.Instance.GetObject();
        projectile.transform.position = spawnProjectilePoint.position;

        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.mass = projectileMass;
        rb.AddForce(spawnProjectilePoint.forward * force, ForceMode.Impulse);
    }
}
