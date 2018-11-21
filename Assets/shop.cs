
using UnityEngine;

public class shop : MonoBehaviour {

    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }



    public void purchaseStandardTurret()
    {
        buildManager.setTurretToBuild(buildManager.standartTurretPrefab);

    }
    public void purchaseSecondTurret()
    {
        buildManager.setTurretToBuild(buildManager.secondTurretPrefab);

    }

}
