using UnityEngine;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour
{
    
    [System.Serializable]
    public class Wave 
    { 
        public GameObject enemyPrefab;
        public float waveNumber;
        public float spawnInterval;
        public int enemiesPerWave;
        public int spawnedEnemyCount;
        public float spawnTimer;

    }

    public List<Wave> waves;
    public int waveNumber;
    public Transform minPos;
    public Transform maxPos;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.Instance.gameObject.activeSelf) {
            waves[waveNumber].spawnTimer += Time.deltaTime;
            if (waves[waveNumber].spawnTimer >= waves[waveNumber].spawnInterval)
        {
            waves[waveNumber].spawnTimer = 0;
            spawnEnemy();
        }

            if (waves[waveNumber].spawnedEnemyCount >= waves[waveNumber].enemiesPerWave) {
            waves[waveNumber].spawnedEnemyCount = 0;
            waveNumber++;

        }
        
            if (waveNumber >= waves.Count) {
            waveNumber = 0;
        }

        }

        
    }

    void spawnEnemy ()
    {
        Instantiate(waves[waveNumber].enemyPrefab, RandomSpawnPoint(), transform.rotation);
        waves[waveNumber].spawnedEnemyCount++;
    }

    private Vector2 RandomSpawnPoint()
    {
        Vector2 spawnPoint;
        spawnPoint.x = Random.Range(minPos.position.x,maxPos.position.x);
        spawnPoint.y = Random.Range(minPos.position.y,maxPos.position.y);


        return spawnPoint;

    }




}
