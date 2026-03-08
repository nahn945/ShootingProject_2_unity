using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StageData
{
    public List<EnemyData> spawns;
}

[System.Serializable]
public class EnemyData
{
    public float spawnTime;
    public float retreatTime;
    public float x;
    public float y;
    public int moveIndex;
    public float moveSpeed;
    public float moveAngle;
    public float moveAngleSpeed;
    public float moveUniqueParam;
    public int retreatIndex;
    public float retreatSpeed;
    public float retreatAngle;
    public float retreatAngleSpeed;
    public float retreatUniqueParam;
}