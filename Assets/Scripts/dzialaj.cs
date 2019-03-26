using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using TMPro;
public class dzialaj : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;
    public Transform End;
    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    private int WaveIndex = 0;
    public Text wavecountdowntext;
    public TextMeshProUGUI moneytext;
    private Transform Target;
    HouseScript house;

    private void Start()
    {
        Target = Waypoints.points[0];
        house = (HouseScript)Target.GetComponent<HouseScript>();
    }
    private void Update()
    {
        if (countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
        moneytext.text = Money.money.ToString();

        wavecountdowntext.text = Mathf.Floor(countdown).ToString();
       // Debug.Log("Cel " + HouseTarget.houseTarget);
        if (Target != End)
        {
            if (house.hitPoint <= 0)
            {
                    house.gameObject.SetActive(false);
                    
                    if (HouseTarget.houseTarget < Waypoints.points.Length - 1)
                    {
                        HouseTarget.houseTarget++;
                        Target = Waypoints.points[HouseTarget.houseTarget];
                    }
                    else
                        Target = End;

                house = (HouseScript)Target.GetComponent<HouseScript>();

            }
        }
    }
    IEnumerator SpawnWave()
    {

        WaveIndex++;
        for (int i = 0; i < WaveIndex; i++)
        {

            SpwanEnemy();
            yield return new WaitForSeconds(0.5f);
            Debug.Log("NADCHODZA ALGOSY");
        }

    }
    void SpwanEnemy()
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);
    }


}