using System;
using Unity.Netcode;
using UnityEngine;

public class EnemySpawner : NetworkBehaviour
{
    public GameObject enemyPrefab;
    public float spawnRate = 1f;
    
    private float _timer;

    private void Awake()
    {
        enabled = false;
    }

    public override void OnNetworkSpawn()
    {
        base.OnNetworkSpawn();
        
        if (IsServer)
        {
            enabled = true;
        }
    }
    void Update()
    {
        _timer += Time.deltaTime;
        if (_timer >= spawnRate)
        {
            _timer = 0f;
            SpawnEnemy();
        }
    }
    
    private void SpawnEnemy()
    {
        Vector3 spawnPosition = new Vector3(UnityEngine.Random.Range(-5f, 5f), UnityEngine.Random.Range(-5f, 5f), 0f);
        NetworkObject enemy = Instantiate(enemyPrefab, spawnPosition, Quaternion.identity).GetComponent<NetworkObject>();
        enemy.Spawn();
    }
}
