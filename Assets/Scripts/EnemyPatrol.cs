using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [Header("Waypoints")]
    public Transform[] waypoints;

    [Header("Movement")]
    public float speed = 3f;

    private int currentWaypointIndex = 0;

    void Update()
    {
        // Check if waypoints exist
        if (waypoints.Length == 0)
            return;

        // Move towards current waypoint
        Transform target = waypoints[currentWaypointIndex];

        transform.position = Vector3.MoveTowards(
            transform.position,
            target.position,
            speed * Time.deltaTime
        );

        // Rotate towards movement direction
        Vector3 direction = target.position - transform.position;

        if (direction != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(direction);
        }

        // Check if reached waypoint
        if (Vector3.Distance(transform.position, target.position) < 0.2f)
        {
            currentWaypointIndex++;

            // Loop back to first waypoint
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        // Destroy player on collision
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
        }
    }
}