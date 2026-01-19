using System.Collections;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float speed = 15.0f;
    public float limitY = 5.0f;
    public float limitX = 8.0f;
    public float angle = 90f;

    public bool isRound = false;
    public float roundAngle = 0f;

    public bool isHoming = false;
    public float homingTime = 1.0f;

    public bool isCross = false;

    public float crossAngle = 90f;

    private Rigidbody2D rb;
    private Vector3 dir;

    private GameObject player;

    private bool hasCrossed = false;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        rb = GetComponent<Rigidbody2D>();

        if (isHoming)
        {
            Vector3 targetDir = player.transform.position - this.gameObject.transform.position;
            targetDir.Normalize();
            rb.velocity = targetDir * speed;
        }
        else
        {
            dir.x = Mathf.Cos(angle * Mathf.Deg2Rad);
            dir.y = Mathf.Sin(angle * Mathf.Deg2Rad);
            rb.velocity = dir * speed;
        }

        if (isRound)
        {
            StartCoroutine(makeRotation());
        }

        roundAngle = 0f;

    }

    void Update()
    {
        if (isCross && !hasCrossed)
        {
            StartCoroutine(makeCross());
        }

        roundAngle = (roundAngle + 1) % 90;

        if (Mathf.Abs(transform.position.y) >= limitY || Mathf.Abs(transform.position.x) >= limitX)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator makeRotation()
    {
        float currentAngle = angle;

        while (true)
        {
            if (currentAngle - angle >= 90) { break; }
            
            // è≠ÇµÇ∏Ç¬êiçsï˚å¸ÇâÒÇ∑
            currentAngle += roundAngle * Time.deltaTime;

            Vector3 dir;
            dir.x = Mathf.Cos(currentAngle * Mathf.Deg2Rad);
            dir.y = Mathf.Sin(currentAngle * Mathf.Deg2Rad);
            dir.z = 0;
            dir.Normalize();

            rb.velocity = dir * speed;

            yield return null;
        }
    }


    IEnumerator makeCross()
    {
        yield return new WaitForSeconds(1);

        Vector3 newDir;
        newDir.x = Mathf.Cos((angle + crossAngle) * Mathf.Deg2Rad);
        newDir.y = Mathf.Sin((angle + crossAngle) * Mathf.Deg2Rad);
        newDir.z = 0;
        newDir.Normalize();

        rb.velocity = newDir * speed;

        hasCrossed = true;
    }
}