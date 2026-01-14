using System;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public bool debugSpawnManager = false;

    public GameObject player;

    public GameObject[] npcPrefabs;

    public float[] lanesXCoordPosArr = {-235f, -230f, -225f};
    public float startBoundZCoord = -770f;
    public float startLineZCoord = -750f;
    public float finishLineZCoord = 1100f;
    public float endBoundZCoord = 1230f;

    public float spawnDistanceMinimumFromPlayer = 20f;
    public float spawnDistanceMaximumFromPlayer = 100f;
    public int spawnTimeMinMs = 500;
    public int spawnTimeMaxMs = 2000;

    private bool spawnNpcGameObjectNextFrame = false;

    void Start()
    {
        InvokeRepeating(nameof(ValidateNextNpcGameObjectSpawn), 0.5f, 1f);
    }

    void Update()
    {
        if (spawnNpcGameObjectNextFrame)
        {
            SpawnRandomNpcGameObject();
        }
    }

    void SpawnRandomNpcGameObject()
    {
        try
        {
            int npcIndex = UnityEngine.Random.Range(0, npcPrefabs.Length);
            int laneIndex = UnityEngine.Random.Range(0, lanesXCoordPosArr.Length);

            float currentPlayerZCoord = player.transform.position.z;

            float minCurrentPlayerZCoordWithOffset = currentPlayerZCoord + spawnDistanceMinimumFromPlayer > finishLineZCoord ? currentPlayerZCoord : currentPlayerZCoord + spawnDistanceMinimumFromPlayer;
            float maxCurrentPlayerZCoordWithOffset = currentPlayerZCoord + spawnDistanceMaximumFromPlayer > finishLineZCoord ? currentPlayerZCoord : currentPlayerZCoord + spawnDistanceMinimumFromPlayer;

            float npcPositionX = lanesXCoordPosArr[laneIndex];
            float npcPositionY = 0;
            float npcPositionZ = UnityEngine.Random.Range(minCurrentPlayerZCoordWithOffset, finishLineZCoord);

            Vector3 npcSpawnPosition = new(npcPositionX, npcPositionY, npcPositionZ);

            GameObject npcPrefab = npcPrefabs[npcIndex];

            if (debugSpawnManager)
            {
                Debug.Log($"Spawning {npcPrefab.name} at {npcPositionX}, {npcPositionY}, {npcPositionZ}");
            }

            Instantiate(npcPrefab, npcSpawnPosition, npcPrefab.transform.rotation);
        }
        catch (Exception ex)
        {
            Debug.Log(ex);
        }
        finally
        {
            spawnNpcGameObjectNextFrame = false;
        }
    }

    void ValidateNextNpcGameObjectSpawn()
    {
        int msToWaitForSpawn = UnityEngine.Random.Range(spawnTimeMinMs, spawnTimeMaxMs);
        _ = TimeSpan.FromMilliseconds(msToWaitForSpawn);

        spawnNpcGameObjectNextFrame = true;
    }
}
