using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public GameObject[] PlatformPrefabs;
    public int minPlatforms;
    public int maxPlatforms;
    public float distanceBetweenPlatforms;
    public Transform PlatformFinish;


    private void Awake()
    {
        int platformsCount = Random.Range(minPlatforms, maxPlatforms + 1);

        for (int i = 0; i < platformsCount; i++)
        {
            int prefabIndex = Random.Range(0, PlatformPrefabs.Length);
            GameObject platform = Instantiate(PlatformPrefabs[prefabIndex], transform);
            platform.transform.localPosition = CalculatePlatformPosition(i);
            platform.transform.localRotation = Quaternion.Euler(0, Random.Range(0, 360f), 0);
        }

        PlatformFinish.localPosition = CalculatePlatformPosition(platformsCount);
    }

    private Vector3 CalculatePlatformPosition(int platformIndex)
    {
        return new Vector3(0, -distanceBetweenPlatforms * platformIndex, 0);
    }
}
