
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if(instance!=null)
            Debug.LogError("MORE THA ONE MANAGER");

        instance = this;
    }

    public GameObject standartTurretPrefab;

    public GameObject secondTurretPrefab;

    private GameObject turretToBuild;

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
    public void setTurretToBuild(GameObject turret)
    {

        turretToBuild = turret;
    }








}
