
using UnityEngine;

public class shop : MonoBehaviour {

    BuildManager buildManager;
    GameObject turret;
    private void Start()
    {
        buildManager = BuildManager.instance;
    }
    private void Update()
    {
        if (turret != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit = new RaycastHit();
            Vector3 pointing = hit.point;
            pointing.z = 0.2f;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                turret.transform.position = pointing;
            }
        }
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
