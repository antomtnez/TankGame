using UnityEngine;

public class PlayerAttack : BaseAttack, IAttackable
{
    [SerializeField]
    private int cannonRotationSpeed = 1;
    [SerializeField]
    private float shotChargeRate = 100f; // Velocidad a la que aumenta la fuerza del disparo

    private float inputHorizontalRotation, inputVerticalRotation;
    private bool isChargingShot = false;
    private bool canMove = true;

    public void Attack()
    {
        if(!trajectoryLine.gameObject.activeSelf)
            trajectoryLine.gameObject.SetActive(true);
            
        ShowTrajectory();

        if (canMove)
            MoveCannon();

        ChargeShot();

        if (ShouldFire())
            FireCannon();
    }

    private void MoveCannon()
    {
        inputHorizontalRotation = Input.GetAxis("Horizontal");
        inputVerticalRotation = Input.GetAxis("Vertical");

        tower.rotation = Quaternion.Euler(
                tower.rotation.eulerAngles.x,
                tower.rotation.eulerAngles.y + (inputHorizontalRotation * cannonRotationSpeed),
                tower.rotation.eulerAngles.z
            );

        cannon.rotation = Quaternion.Euler(
                cannon.rotation.eulerAngles.x + (inputVerticalRotation * cannonRotationSpeed),
                cannon.rotation.eulerAngles.y,
                cannon.rotation.eulerAngles.z
            );
    }

    private void ChargeShot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartChargingShot();
        }

        if (Input.GetKey(KeyCode.Space) && currentShotForce < maxShotForce)
        {
            currentShotForce += shotChargeRate * Time.deltaTime;
        }
    }

    private bool ShouldFire()
    {
        return (Input.GetKeyUp(KeyCode.Space) || currentShotForce >= maxShotForce) && isChargingShot;
    }

    private void FireCannon()
    {
        GameObject projectile = ProjectilePool.Instance.GetObject();
        SetupProjectile(projectile);
        LaunchProjectile(projectile);

        ResetCannonState();
    }

    private void ShowTrajectory()
    {
        trajectoryLine.ShowTrajectoryLine(spawnProjectilePoint.position, spawnProjectilePoint.forward * currentShotForce / projectileMass);
    }

    private void StartChargingShot()
    {
        canMove = false;
        isChargingShot = true;
        currentShotForce = minShotForce;
    }

    private void SetupProjectile(GameObject projectile)
    {
        projectile.transform.position = spawnProjectilePoint.position;
        projectile.transform.rotation = spawnProjectilePoint.rotation;
    }

    private void LaunchProjectile(GameObject projectile)
    {
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        rb.mass = projectileMass;
        rb.AddForce(spawnProjectilePoint.forward * currentShotForce, ForceMode.Impulse);
    }

    private void ResetCannonState()
    {
        isChargingShot = false;
        canMove = true;
        trajectoryLine.gameObject.SetActive(false);
    }
}
