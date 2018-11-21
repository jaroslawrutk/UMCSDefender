
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    public Color hoverColor;
    private Renderer rend;
    public Color startColor;
    public Vector3 possitionoffset;
    public Vector3 rotationoffset;

    BuildManager buildManager;

    private GameObject turret;



    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    
    private void OnMouseDown()
    {
        if (buildManager.GetTurretToBuild() == null)
            return;

        if(turret!=null)
        {
            Debug.Log("CANT BUILD HERE!!!");
            return;
        }

        GameObject turretToBUild = buildManager.GetTurretToBuild();
        turret=(GameObject)Instantiate(turretToBUild, transform.position + possitionoffset , Quaternion.Euler(rotationoffset.x, 0f, 0f));
    }
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;


        if (buildManager.GetTurretToBuild() == null)
            return;

        rend.material.color = hoverColor;
    }


    private void OnMouseExit()
    {

        rend.material.color = startColor;
    }





}
