using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class BulletTest : MonoBehaviour
{
    public GameObject bulletPrefab;

    EnemyBulletController bulletController;

    // Start is called before the first frame update
    void Start()
    {
        bulletController = GetComponent<EnemyBulletController>();

        Debug.Assert(
            bulletController != null,
            "EnemyBulletController is NOT attached to this GameObject"
        );
    }


    // Update is called once per frame
    void Update()
    {
        // rotateMaxÇÕ(endTime - startTime) / intervalÇ≈ì±èo(int)
        bulletController.SetRotation(0f, 1.0f, 0.1f, 30f, new PatternCircle(bulletPrefab, 10, 2.0f));
        bulletController.SetRotation(2.0f, 3.0f, 0.1f, -30f, new PatternCircle(bulletPrefab, 10, 2.0f));

        bulletController.SetRotation(5.0f, 8.0f, 0.1f, 5f, new PatternCircle(bulletPrefab, 4, 2.0f));
        bulletController.SetHoming(8.0f, 12.0f, 0.5f, 0f, new PatternSingle(bulletPrefab, 2.0f, 0f));
    }

    
}
