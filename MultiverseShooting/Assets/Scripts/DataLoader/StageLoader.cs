using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class StageLoader : MonoBehaviour
{
    public GameObject spawner;
    EnemySpawner enemySpawner;

    StageData loadedData;
    int stageIndex = 0;

    string jsonName;
    bool isLoading = false;

    List<string> nameList = new List<string>() {
        "stage1",
        ""
    };

    private void Awake()
    {

        loadedData = null;
        isLoading = true;
        Debug.Log("Load Start");
        StartCoroutine(ProcessLoad());
        LoadData(nameList[stageIndex]);

        enemySpawner = spawner.GetComponent<EnemySpawner>();
        enemySpawner.Init(loadedData);

        isLoading = false;
        Debug.Log("Load End");
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void LoadData(string fileName)
    {
        jsonName = Resources.Load<TextAsset>(fileName).ToString();
        loadedData = JsonUtility.FromJson<StageData>(jsonName);
    }

    IEnumerator ProcessLoad()
    {
        while (isLoading)
        {
            Debug.Log("Loading");
            yield return null;
        }

        yield return null;
    }

    public StageData GetData()
    {
        return loadedData;
    }
}
