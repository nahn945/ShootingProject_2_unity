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

        while (spawnIndex < stageData.spawns.Count 
            && timer >= stageData.spawns[spawnIndex].spawnTime)
        {
            

            if (enemies.Count == 0)
            {
                Enqueue();
            }

            AddEnemy();
            spawnIndex++;
        }
    }

    void Enqueue()
    {
        GameObject e = Instantiate(enemyPrefab);
        e.SetActive(false);
        EnemyManager manager = e.GetComponent<EnemyManager>();
        e.transform.parent = transform;
        enemies.Enqueue(manager);
    }

    void AddEnemy()
    {
        EnemyManager e = enemies.Dequeue();
        EnemyData data = stageData.spawns[spawnIndex];

        e.transform.position = new Vector2(data.x, data.y);
        e.SetData(data);
        e.SetMovePattern(ConvertMoveIndex(data.moveIndex));
        e.SetRetreatPattern(ConvertMoveIndex(data.retreatIndex));
        e.Init(this);
        e.gameObject.SetActive(true);
    }

    public void EnequeueSelf(EnemyManager manager)
    {
        enemies.Enqueue(manager);
    }

    public void Init(StageData inputData)
    {
        stageData = inputData;
    }

    IEnemyMove ConvertMoveIndex(int index)
    {
        IEnemyMove pattern;
        switch(index)
        {
            case 0:
                pattern = new MoveStraight();
                break;
            case 1:
                pattern = new MoveDamping();
                break;
            case 2:
                pattern = new MoveCurve();
                break;
            case 3:
                pattern = new MoveTurning();
                break;
            case 4:
                pattern = new MoveOscilate();
                break;
            default:
                pattern = new MoveStraight();
                break;
        }

        return pattern;
    }
}
