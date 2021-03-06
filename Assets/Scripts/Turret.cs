﻿
using UnityEngine;

public class Turret : MonoBehaviour {

    private Transform target;

    [Header("Atrribute")]

    public float range = 15f;
    
    public float fireRate = 1f;
    private float fireCountdown = 0f;

    [Header("Unity Setup Fields")]
    public Transform rotate;
    public float turnSpeed = 10f;

    public GameObject bulletPrefab;
    public Transform firepoint;


    // Use this for initialization
    void Start () {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        float shortestDistance = Mathf.Infinity;
        GameObject nearesteEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearesteEnemy = enemy;
            }
        }
        if (nearesteEnemy != null && shortestDistance <= range)
        {
            target = nearesteEnemy.transform;
        }
        else
            target = null;
    }
	
	// Update is called once per frame
	void Update () {
        if (target == null)
            return;

        Vector3 dir = target.position - transform.position;

        Quaternion lookrotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(rotate.rotation, lookrotation, Time.deltaTime*turnSpeed).eulerAngles;
        rotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);

        if(fireCountdown<=0f)
        {
            Shoot();
            fireCountdown = 1f / fireRate;
        }

        fireCountdown -= Time.deltaTime;

    }

    void Shoot()
    {
        GameObject bulletGo = (GameObject)Instantiate(bulletPrefab, firepoint.position, firepoint.rotation);
        Hit bullet = bulletGo.GetComponent < Hit > ();
        if(bullet!=null)
        {
            bullet.seek(target);
        }

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
