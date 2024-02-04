using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnGift : MonoBehaviour
{
    [SerializeField] private List<GameObject> giftList;
    [SerializeField] private Transform giftSpawnPoint;
    [SerializeField] private ScoreController scoreController;

    private void Start()
    {
        SpawnRandomGift();
    }

    public void SpawnRandomGift()
    {
        var currentGift = Instantiate(giftList[Random.Range(0, giftList.Count)], giftSpawnPoint.position, 
            quaternion.identity);
        currentGift.transform.SetParent(giftSpawnPoint);
        var currentGiftCode = currentGift.GetComponent<GiftCode>();
        currentGiftCode.spawnGift = this;
        currentGiftCode.ScoreController = scoreController;

    }
    
}




