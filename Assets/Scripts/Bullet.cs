using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Transform target;

    public int damage = 5;
    public float speed = 40f;

    public GameObject impactEffect;
    public float explosionRadius = 0f;

    public void Seek(Transform _target)
    {
        target = _target;
    }

    void Update()
    {
        if(target == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 direction = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if(direction.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }
        transform.Translate(direction.normalized * distanceThisFrame,Space.World);
        transform.LookAt(target);
    }

    void HitTarget()
    {
        GameObject effectIns = (GameObject)Instantiate(impactEffect,transform.position,transform.rotation);
        Destroy(effectIns, 5f);

        if(explosionRadius > 0f)
            Explode();
        else
            Damage(target);

        Destroy(gameObject);
    }

    void Explode()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, explosionRadius);
		foreach (Collider collider in colliders)
		{
			if (collider.tag == "Enemy")
			{
				Damage(collider.transform);
			}
		}
    }

    void Damage(Transform target)
    {
        Enemy e = target.GetComponent<Enemy>();

        if(e != null)
            e.TakeDamage(damage);
    }

    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }  
}