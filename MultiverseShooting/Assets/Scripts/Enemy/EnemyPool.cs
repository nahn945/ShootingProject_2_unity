using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public GameObject enemyPrefab;
    public int queue_size = 20;

    Queue<EnemyManager> e_queue = new Queue<EnemyManager>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < queue_size; i++)
        {
            Enqueue(enemyPrefab);
        }
    }

    void Enqueue(GameObject enemy)
    {
        EnemyManager e = Instantiate(enemy).GetComponent<EnemyManager>();
        e.gameObject.SetActive(false);
        e_queue.Enqueue(e);
    }

    public EnemyManager GetEnemy()
    {
        if (e_queue.Count > 0)
        {
            return e_queue.Dequeue();
        }

        // ë´ÇËÇ»ÇØÇÍÇŒí«â¡ê∂ê¨
        Enqueue(enemyPrefab);
        return e_queue.Dequeue();
    }

    public void ReturnEnemy(EnemyManager enemyManager)
    {
        enemyManager.gameObject.SetActive(false);
        e_queue.Enqueue(enemyManager);
    }
}
