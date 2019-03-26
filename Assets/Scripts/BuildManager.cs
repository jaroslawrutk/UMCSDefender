
using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;
    private int currentMoney;
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
        currentMoney = Money.money;
        currentMoney -= 400;
        if (currentMoney < 0)
            Debug.Log("YUO DONT HAVE ENOUG MONEY");
        else {
            Money.money -= 400;
            turretToBuild = turret;
        }
        
    }
    public void SetTurretNull()
    {
        turretToBuild = null;
    }








}
