using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBarScript : MonoBehaviour {

    public Image currentHealthbar;
    public Text ratioText;

    private float maxhitPoint = 150;
    private float hitPoint = 150;
    private float ratio;
    // Use this for initialization
    void Start () {
        UpdateHealthBar();
	}
	
	// Update is called once per frame
	void UpdateHealthBar() {
        ratio = hitPoint / maxhitPoint;
        currentHealthbar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        ratioText.text = (ratio * 100).ToString()+'%';
	}
    private void TakeDamage(float damage)
    {
        hitPoint -= damage;
        Debug.Log("House was Destroyed");
    }
}
