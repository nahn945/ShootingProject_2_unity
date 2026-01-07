using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    public GameObject HP;
    public GameObject hitCircle;

    private LifeController lc;
    private HitCircleController hc;
    // Start is called before the first frame update
    void Start()
    {
        lc = HP.GetComponent<LifeController>();
        hc = hitCircle.GetComponent<HitCircleController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (lc.getIsDead())
        {
            GameOver();
        }

        if (hc.getIsHit())
        {
            lc.Damage(hc.getDamage());
        }
    }

    void GameOver()
    {
        Debug.Log("Game Over");
    }
}
