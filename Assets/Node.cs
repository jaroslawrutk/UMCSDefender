
using UnityEngine;

public class Node : MonoBehaviour {

    public Color hoverColor;
    private Renderer rend;
    public Color startColor;
    public Vector3 possitionoffset;
    public Vector3 rotationoffset;

    private GameObject turret;



    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseEnter()
    {
        rend.material.color = hoverColor;
    }

    private void OnMouseDown()
    {
        if(turret!=null)
        {
            Debug.Log("CANT BUILD HERE!!!");
            return;
        }

        GameObject turretToBUild = BuildManager.instance.GetTurretToBuild();
        turret=(GameObject)Instantiate(turretToBUild, transform.position + possitionoffset , Quaternion.Euler(rotationoffset.x, 0f, 0f));
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }





}
