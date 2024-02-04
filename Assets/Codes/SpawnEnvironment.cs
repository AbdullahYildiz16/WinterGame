using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;


public class SpawnEnvironment : MonoBehaviour
{
    [SerializeField] private float bgSpace = 19.2f;
    [SerializeField] private List<GameObject> levelList;
    public Vector3 currentBgPos;

    public void SpawnBg(Vector3 previousBgPos)
    {
        currentBgPos = previousBgPos + Vector3.right * bgSpace;
        Instantiate(levelList[Random.Range(0, levelList.Count)], currentBgPos, quaternion.identity);
    }
    
}
