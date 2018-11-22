using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class dzialaj : MonoBehaviour
{
    public Transform enemyPrefab;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5f;
    private float countdown = 2f;
    private int WaveIndex = 0;
    public Text wavecountdowntext;


    private void Update()
    {
        if (countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;

        wavecountdowntext.text = Mathf.Floor(countdown).ToString();

       

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