using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class EnemyAttack : MonoBehaviour
{
    public GameObject bullet;
    public int index = 0;

    private Vector3 pos;
    public float intervalSec = 1f;
    private float timer = 0;

    public float baseAngle = 0f;   // ‰~Œ`’e–‹‘S‘Ì‚Ì‰ñ“]Šp
    public float rotateStep = 30f; // ”­Ë‚²‚Æ‚É‚¸‚ç‚·Šp“x

    public float angle = 90f;
    public int count = 3;

    public float speed = 1.0f;

    public bool homing = false;

    public int serialCount = 1;

    public float startTime = 0f;
    public float endTime = 30f;


    private BulletMove move;

    // Start is called before the first frame update
    void Start()
    {
        pos = transform.position;   
        move = bullet.GetComponent<BulletMove>();

        StartCoroutine(MakePatterns());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void PatternSingle()
    {
        Instantiate(bullet, pos, Quaternion.identity);
    }


    void  PatternCircle()
    {
       for (int i = 0; i < count; i++)
       {
            angle = 360f / count * i;
            GameObject b = Instantiate(bullet, pos, Quaternion.identity);
            b.GetComponent<BulletMove>().isHoming = homing;
            b.GetComponent<BulletMove>().angle = angle;
            b.GetComponent<BulletMove>().speed = speed;
        }
    }

    void PatternNway()
    {
        if (count > 1)
        {
            float spreadAngle = 60f; // î‚ÌL‚ª‚èŠp“xi‘S‘Ìj
            float startAngle = angle - spreadAngle / 2f;
            float step = spreadAngle / (count - 1);

            for (int i = 0; i < count; i++)
            {
                float shotAngle = startAngle + step * i;

                GameObject b = Instantiate(bullet, pos, Quaternion.identity);
                b.GetComponent<BulletMove>().angle = shotAngle;
                b.GetComponent<BulletMove>().speed = speed;
                b.GetComponent<BulletMove>().isHoming = homing;
            }
        }
    }

    void PatternRotation()
    {
        pos = transform.position;

        for (int i = 0; i < count; i++)
        {
            float shotAngle = baseAngle + (360f / count * i);

            GameObject b = Instantiate(bullet, pos, Quaternion.identity);
            b.GetComponent<BulletMove>().angle = shotAngle;
            b.GetComponent<BulletMove>().speed = speed;
            b.GetComponent<BulletMove>().isHoming = homing;
        }

        // Ÿ‰ñ”­Ë—p‚ÉŠp“x‚ğ‚¸‚ç‚·
        baseAngle += rotateStep;
        baseAngle %= 360f;
    }

    void PatternRandom()
    {
        pos = transform.position;

        for (int i = 0; i < count; i++)
        {
            float shotAngle = baseAngle + (360f / count * Random.Range(0, count));

            GameObject b = Instantiate(bullet, pos, Quaternion.identity);
            b.GetComponent<BulletMove>().angle = shotAngle;
            b.GetComponent<BulletMove>().speed = speed;
            b.GetComponent<BulletMove>().isHoming = homing;
        }

        // Ÿ‰ñ”­Ë—p‚ÉŠp“x‚ğ‚¸‚ç‚·
        baseAngle += Random.Range(-360f, 360f);
        baseAngle %= 360f;
    }

    void PatternGoInside()
    {
        for (int i = 0; i < count; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                GameObject b = Instantiate(bullet, pos, Quaternion.identity);
                b.GetComponent<BulletMove>().isHoming = homing;
                b.GetComponent<BulletMove>().angle = 360f / count * i;
                b.GetComponent<BulletMove>().speed = speed;
                b.GetComponent<BulletMove>().isCross = true;
                b.GetComponent<BulletMove>().crossAngle = angle + 180f;
            }
        }
    }

    void PatternCross()
    {
        for (int i = 0; i < count; i++)
        {
            float baseShotAngle = 360f / count * i;

            for (int j = 0; j < 2; j++)
            {
                GameObject b = Instantiate(bullet, pos, Quaternion.identity);
                var m = b.GetComponent<BulletMove>();

                m.isHoming = homing;
                m.angle = baseShotAngle;
                m.speed = speed;
                m.isCross = true;

                if (j == 0)
                    m.crossAngle = 30f;
                else
                    m.crossAngle = -30f;
            }
        }
    }



    IEnumerator MakePatterns()
    {
        while (timer >= startTime && timer <= endTime)
        {

            for (int i = 0; i < serialCount; i++)
            {
                switch (index)
                {
                    case 0:
                        PatternSingle();
                        break;
                    case 1:
                        PatternCircle();
                        break;
                    case 2:
                        PatternNway();
                        break;
                    case 3:
                        PatternRotation();
                        break;
                    case 4:
                        PatternRandom();
                        break;
                    case 5:
                        PatternGoInside();
                        break;
                    case 6:
                        PatternCross();
                        break;

                    default:
                        break;
                }

                yield return new WaitForSeconds(0.1f);
            }

            yield return new WaitForSeconds(intervalSec);

            timer += 1;
        }
    }
}
