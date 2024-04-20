using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int maxEnemySpawnOneTime = 3;

    private void Start()
    {
        SpawnEnemy();
    }

    private void SpawnEnemy()
    {
        if (PlayerController.EnemyCounter < PlayerController.maxEnemiesOnMap)
        {
            float randomX = Random.Range(-1f, 1f);
            float randomY = Random.Range(-1f, 1f);
            Vector3 spawnPosition = new Vector3(randomX, randomY, 0f);
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity).transform.localScale = new Vector3((Enemy.scale) / 5, (Enemy.scale) / 5, 1f); ;
            PlayerController.EnemyCounter++;
        }
    }

    public void EnemyDefeated()
    {
        PlayerController.EnemyCounter--;
        PlayerController.enemyKilled++;
        StartCoroutine(RespawnCoroutine());
    }

    private IEnumerator RespawnCoroutine()
    {
        Debug.Log(PlayerController.maxEnemiesOnMap - PlayerController.EnemyCounter);

        for (int i = 0; i <= PlayerController.maxEnemiesOnMap - PlayerController.EnemyCounter; i++)
        {
            SpawnEnemy();
        }

        if (PlayerController.enemyKilled % 5 == 0)
        {
            PlayerController.maxEnemiesOnMap++;
        }
        
        yield return null;
    }
}