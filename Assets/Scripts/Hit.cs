
using UnityEngine;

public class Hit : MonoBehaviour {

    private Transform target;
    public float speed = 200f;
    private float atackValue = 30f;
    public GameObject BulletImpact;
    private BarbarianController barba;

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
        target.SendMessage("TakeDamage", atackValue);
        //if (target != null)
        //{
        //    barba = target.GetComponent<BarbarianController>();
        //    barba.TakeDamage(atackValue);
        //    Debug.Log("HP " + barba.maxhitPoint);
        //}

        //target.gameObject.SendMessage("TakeDamage", Time.deltaTime * atackValue);

        Destroy(gameObject);
    }
}
