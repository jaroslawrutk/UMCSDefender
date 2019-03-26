
using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections.Generic;
public class Node : MonoBehaviour {

    public Color hoverColor;
    public Color startColor;
    public Vector3 possitionoffset;
    public Vector3 rotationoffset;

    BuildManager buildManager;

    private GameObject turret;



    private void Start()
    {
        //rend = GetComponent<MeshRenderer>();
        //startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    
    private void OnMouseDown()
    {
        if (buildManager.GetTurretToBuild() == null)
            return;
        if (EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("YOU CANT BUILD HERE");
            return;
        }
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit = new RaycastHit();

        GameObject turretToBUild = buildManager.GetTurretToBuild();
        if (Physics.Raycast(ray, out hit))
        {
            turret = (GameObject)Instantiate(turretToBUild, hit.point, Quaternion.Euler(rotationoffset.x, 0f, 0f));
            buildManager.SetTurretNull();
        }
    }
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            Debug.Log("YOU CANT BUILD HERE");
            return;
        }
        if (buildManager.GetTurretToBuild() == null)
            return;
        //rend.material.color = hoverColor;
    }
    private void OnMouseExit()
    {
        //rend.material.color = startColor;
    }





}
