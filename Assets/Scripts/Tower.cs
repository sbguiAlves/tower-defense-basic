using UnityEngine;

public class Tower : MonoBehaviour
{
    private Enemy targetEnemy;
    private Transform target;
    private float fireCountdown = 0f;
    private Quaternion newRotation;

    [Header("Torre - Geral")]
    public float turnSpeed = 10f;
    public float range = 17f;
    public float fireRate = 1f; 
    public GameObject bulletPrefab;
    public Transform partToRotate;
    public Transform firePoint;

    [Header("Torre - Tiro Único e Explosivo")]
    public bool isShoot = false;

    [Header("Torre de Gelo")]
    public bool useIce = false;
    public float percentSlow = 0.5f;
    public GameObject slowEffectParticle;

    void Start()
    {
        newRotation = partToRotate.rotation;
        InvokeRepeating("UpdateTarget",0f,0.5f);
    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if(distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if(nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
            target = null;
    }

    void Update()
    {
        if(target == null)
            return;

        if(useIce)
            SlowEffect();
        else
        {
            LockOnTarget();
            if(fireCountdown <= 0f)
            {
                if(isShoot)
                    Shoot();
                fireCountdown = 1f / fireRate;
            }
            fireCountdown -= Time.deltaTime;
        }
       
    }

    void LockOnTarget()
    {
        Vector3 dir = target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation,lookRotation,Time.deltaTime * turnSpeed).eulerAngles; //conversão
        partToRotate.rotation = Quaternion.Euler(0f,rotation.y, 0f);
    }

    void Shoot()
    {
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab,firePoint.position,firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if(bullet !=null)
            bullet.Seek(target);
    }

    void SlowEffect()
    {
        newRotation *= Quaternion.Euler(Vector3.up);
        partToRotate.transform.rotation = Quaternion.Lerp(partToRotate.rotation,newRotation,Time.deltaTime * turnSpeed);
        
        targetEnemy.Slow(percentSlow,targetEnemy.speed);
    }


    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }    
}
