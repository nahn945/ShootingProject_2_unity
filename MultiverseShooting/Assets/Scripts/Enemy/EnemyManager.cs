using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    EnemySpawner enemySpawner;

    EnemyManager enemyManager;

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ReturnToPool()
    {
        gameObject.SetActive(false);
        enemySpawner.EnequeueSelf(enemyManager);
    }

    public void Init(EnemySpawner spawner)
    {
        enemySpawner = spawner;
        enemyManager = GetComponent<EnemyManager>();
    }

}
