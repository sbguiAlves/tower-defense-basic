using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    private Enemy enemy;
    private int waypointIndex = 0;
    private Transform target;

    void Start()
    {
        enemy = GetComponent<Enemy>();
        target = Waypoints.waypoints[0];   
    }

    void Update()
    {
        Vector3 next = target.position - transform.position;
        transform.Translate(next.normalized * enemy.speed *Time.deltaTime, Space.World);

        if(Vector3.Distance(transform.position, target.position) <= 0.4f)
            GetNextWaypoint();

        enemy.speed = Spawner.currentSpeed;
    }

    void GetNextWaypoint()
    {
        if(waypointIndex >= Waypoints.waypoints.Length - 1)
        {
            EndPath();
            return;
        }
        waypointIndex++;
        target = Waypoints.waypoints[waypointIndex];
    }

    void EndPath()
    {
        StatusPlayer.amountFire += 0.1f;
        Spawner.enemiesAlive--;
        Destroy(gameObject);
    }
}
