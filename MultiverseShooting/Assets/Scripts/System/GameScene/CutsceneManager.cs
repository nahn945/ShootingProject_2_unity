using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneManager : MonoBehaviour
{
    public GameObject cutscene;

    // Start is called before the first frame update
    void Start()
    {
        cutscene.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        // ‰¼
        if (Input.GetKeyDown(KeyCode.C))
        {
            ActivateCutscene();
        }
    }

    public void ActivateCutscene()
    {
        cutscene.SetActive(true);
    }
}
