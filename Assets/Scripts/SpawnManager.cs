using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject enemySpawn;
    [SerializeField] private GameObject powerupPrefab;
    private float spawnRange = 9;
    private int enemyCount;
    private int waveNumber = 1;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(powerupPrefab,GenerateSpawnPosition(),powerupPrefab.transform.rotation);
        SpawnEnemyWave(1);
    }
    void SpawnEnemyWave(int enemyToSpawn){
        for (int i = 0; i < enemyToSpawn; i++)
        {
            Instantiate(enemySpawn,GenerateSpawnPosition(),enemySpawn.transform.rotation);
        }
    }
    // Update is called once per frame
    void Update()
    {
        enemyCount = FindObjectsOfType<Enemy>().Length; 
        if(enemyCount == 0){
            waveNumber++;
            SpawnEnemyWave(waveNumber);
            Instantiate(powerupPrefab,GenerateSpawnPosition(),powerupPrefab.transform.rotation);
        }
        // Debug.Log(enemyCount);
    }
    Vector3 GenerateSpawnPosition(){
        float spawnPosX = Random.Range(-spawnRange,spawnRange);
        float spawnPosZ = Random.Range(-spawnRange,spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX,0,spawnPosZ);
        return randomPos;
    }
}
