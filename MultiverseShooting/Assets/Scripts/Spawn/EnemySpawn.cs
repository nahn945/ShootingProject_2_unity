using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject jsonLoader;
    public GameObject poolObject;

    int index = 0;
    JsonDataLoad dataLoad;
    EnemyData enemyData;
    EnemyPool enemyPool;

    float spawnTimer = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        dataLoad = jsonLoader.GetComponent<JsonDataLoad>();
        enemyPool = poolObject.GetComponent<EnemyPool>();

        LoadJson();
    }

    private void FixedUpdate()
    {
        if (enemyData != null && spawnTimer > enemyData.spawnTime)
        {
            Debug.Log("Trued");
            Spawn();
            LoadJson();
        }

        spawnTimer += Time.fixedDeltaTime;
    }

    void LoadJson()
    {
        enemyData = dataLoad.GetEnemyData(index);
        if (enemyData != null )
        {
            index++;
        }
        else
        {
            Debug.Log("null");
        }
    }

    void Spawn()
    {
        Debug.Log("spawned");
        
        if (!enemyPool.GetEnemy().TryGetComponent<EnemyManager>(out var enemyManager))
        {
            Debug.LogWarning("Pool less");
            return;
        }

        enemyManager.Initiallize(enemyData);
        enemyManager.gameObject.SetActive(true);
    }
}
