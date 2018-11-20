
using UnityEngine;

public class Enemy : MonoBehaviour {

    public float speed = 10f;
    private Transform Target;
    private int wavepointIndex = 0;
    private void Start()
    {
        Target = Waypoints.points[0];
    }
    private void Update()
    {
        Vector3 direction = Target.position - transform.position;
        transform.Translate(direction.normalized *speed * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, Target.position) <= 2.0f)
            GetNextWaypoint();
    }
    void GetNextWaypoint ()
    {
        if(wavepointIndex>=Waypoints.points.Length-1)
        {
            Destroy(gameObject);
            return;
        }

        wavepointIndex++;
        Target = Waypoints.points[wavepointIndex];
    }
}
