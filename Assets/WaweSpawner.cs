using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaweSpawner : MonoBehaviour {

    public Transform enemyPrefab;
    public Transform spawnPoint;

    public float timeBetweenWaves = 5f; //затримка між хвилями
    private float countdown = 2f;

    public Text waveCountdownText; //Таймер відліку 

    private int waveIndex = 1;

    void Update()
    {
        if(countdown <= 0f)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }

        countdown -= Time.deltaTime;

        waveCountdownText.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave ()
    {
        waveIndex++;

        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(0.5f);//Затримка між викликом кожного ворога
        }
    }

    void SpawnEnemy ()//створення ворогів
    {
        Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation );
    }
}
