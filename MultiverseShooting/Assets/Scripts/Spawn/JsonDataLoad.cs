using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

[System.Serializable]
public class StageData
{
    public List<EnemyData> waves;
}

[System.Serializable]
public class EnemyData
{
    public SpawnPos spawnPos;

    public float spawnTime;
    public float pauseTime;
    public float retreatTime;

    public float moveSpeed;
    public float moveAngle;
    public int moveIndex;

    public float retreatSpeed;
    public float retreatAngle;
    public int retreatIndex;

    public float attackSpeed;
    public float attackAngle;
    public int attackIndex;
    public float attackInterval;
}

[System.Serializable]
public class SpawnPos
{
    public float x;
    public float y;
}

public class JsonDataLoad : MonoBehaviour
{

    string inputJson;
    StageData data = null;

    private void Awake()
    {
        Debug.Log("loading by JsonDataLoad.cs...");
        Time.timeScale = 0f;

        TextAsset jsonFile = Resources.Load<TextAsset>("stage1");

        if (jsonFile == null)
        {
            Debug.LogError("JSON‚ªŒ©‚Â‚©‚è‚Ü‚¹‚ñ");
            return;
        }

        data = JsonUtility.FromJson<StageData>(jsonFile.text);
        Debug.Log("load ended");
        Time.timeScale = 1.0f;
    }

    private void Start()
    {
        
        
    }

    public EnemyData GetEnemyData(int index)
    {
        if (data == null)
        {
            Debug.Log("dataNull");
            return null;
        }

        if (index > data.waves.Count - 1)
        {
            return null;
        }
        return data.waves[index];
    }
}
