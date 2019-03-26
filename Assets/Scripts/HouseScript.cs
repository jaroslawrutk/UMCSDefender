using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HouseScript : MonoBehaviour {

    public Transform target;
    public bool isTakingDamage;
    public Image currentHealthbar;
    public Text ratioText;
    public float range = 15f;
    public float maxhitPoint = 20;
    public float hitPoint = 150;
    private float ratio;
    // Use this for initialization
    void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        
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

    void UpdateHealthBar()
    {
        ratio = hitPoint / maxhitPoint;
        currentHealthbar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        ratioText.text = (ratio * 100).ToString() + '%';
        if (ratio <= 0.5 && ratio >= 0.25)
            currentHealthbar.color = Color.yellow;
        if (ratio < 0.25)
            currentHealthbar.color = Color.red;

    }
    private void TakeDamage(float damage)
    {
        hitPoint -= damage;
        if (hitPoint < 0)
        {
            hitPoint = 0;
            Debug.Log("House was Destroyed");
        }
        UpdateHealthBar();
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
