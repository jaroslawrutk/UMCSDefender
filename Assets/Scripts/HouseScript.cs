using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HouseScript : MonoBehaviour {



    public Text text;
    public Text text1;
    public Image HP;
    public float health = 200;
    public float currentHealth;
    // Use this for initialization
    void Start () {
        currentHealth = health;
        text.text = health.ToString();
        text1.text = currentHealth.ToString();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
