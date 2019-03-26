
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Waypoints : MonoBehaviour {

    public static Transform[] points;
    
    private void Awake()
    {
        points = new Transform[transform.childCount];
        
        for (int i = 0; i < points.Length; i++)
            points[i] = transform.GetChild(i);

        Debug.Log("Ilosc domkow to " + transform.childCount);
    }
    public void Update()
    {
        
    }
}
