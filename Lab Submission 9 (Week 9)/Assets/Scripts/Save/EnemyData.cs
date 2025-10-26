using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemyData
{
    public float[] position;

    public EnemyData(RandomTarget randomTarget)
    {
        position = new float[3];
        position[0] = randomTarget.prefabs[0].transform.position.x;
        position[1] = randomTarget.prefabs[0].transform.position.y;
        position[2] = randomTarget.prefabs[0].transform.position.z;
    }
}
