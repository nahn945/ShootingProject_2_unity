using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBombControl : MonoBehaviour
{
    private GameSceneUIController controller;
    public float expandSpeed = 1f;
    public float circleLimit = 8f;

    public bool isActive = false;
    private bool hasCalled = false;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("UIMangaer").GetComponent<GameSceneUIController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (controller.isPaused) return;

        if (isActive && !hasCalled)
        {
            StartCoroutine(ExpandArea());
            hasCalled = true;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            isActive = true;
        }
    }

    IEnumerator ExpandArea()
    {
        while (true)
        {
            if (this.transform.localScale.x <= circleLimit)
            {
                this.transform.localScale += Vector3.one * expandSpeed;
            }
            else
            {
                hasCalled = false;
                break;
            }

            yield return new WaitForEndOfFrame();
        }
    }
}
