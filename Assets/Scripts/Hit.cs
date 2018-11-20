
using UnityEngine;

public class Hit : MonoBehaviour {

    private Transform target;
    public float speed = 70f;
    public GameObject BulletImpact;
    public void seek(Transform _target)
    {
        target = _target;
    }
	
	// Update is called once per frame
	void Update () {
		
        if(target==null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThsFrame = speed * Time.deltaTime;

        if(dir.magnitude <= distanceThsFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThsFrame, Space.World);

	}
    void HitTarget()
    {
        GameObject effect = (GameObject) Instantiate(BulletImpact, transform.position, transform.rotation);
        Destroy(effect,2f);

        Destroy(target.gameObject);
        Destroy(gameObject);
    }
}
