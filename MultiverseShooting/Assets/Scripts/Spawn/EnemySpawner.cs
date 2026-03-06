using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    Queue<EnemyManager> enemies = new Queue<EnemyManager>();
    int poolSize = 20;

    StageData stageData;
    float timer = 0f;
    int spawnIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        EnemyManager manager = enemyPrefab.GetComponent<EnemyManager>();
        manager.Init(this);

        for (int i = 0; i < poolSize; i++)
        {
            Enqueue();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (stageData == null) return;

        timer += Time.deltaTime;

        while (spawnIndex < stageData.spawns.Count && timer >= stageData.spawns[spawnIndex].spawnTime)
        {
            EnemyData data = stageData.spawns[spawnIndex];

            if (enemies.Count == 0)
            {
                Enqueue();
            }

            EnemyManager e = enemies.Dequeue();
            e.transform.position = new Vector2(data.x, data.y);
            e.gameObject.SetActive(true);
            spawnIndex++;
        }
    }

    void Enqueue()
    {
        GameObject e = Instantiate(enemyPrefab);
        e.SetActive(false);
        EnemyManager manager = e.AddComponent<EnemyManager>();
        e.transform.parent = transform;
        enemies.Enqueue(manager);
    }

    public void EnequeueSelf(EnemyManager manager)
    {
        enemies.Enqueue(manager);
    }

    public void Init(StageData inputData)
    {
        stageData = inputData;
    }
}
