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
        bulletController.SetPattern(0f, 8.0f, 0.5f, new PatternCross(bulletPrefab, 10, 2.0f, false, 20f));
    }

    
}
