using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [System.Serializable]
    public struct SpawnableObject
    {
        public GameObject spawnObject;
        [Range(0f, 1f)]
        public float spawnChance;
    }
    public SpawnableObject[] spawnObjects;

    public float MinSpawnRate = 1f, MaxSpawnRate = 2f;

    private void OnEnable()
    {
        InvokeRepeating(nameof(Spawn), 0f, Random.Range(MinSpawnRate, MaxSpawnRate));
    }
    void Spawn()
    {
        float spawnChance = Random.value;
        foreach (var spawnObject in spawnObjects)
        {
            if (spawnChance < spawnObject.spawnChance)
            {
                GameObject obstacle = Instantiate(spawnObject.spawnObject, transform, true);
                obstacle.transform.position += transform.position;
                break;
            }
            spawnChance -= spawnObject.spawnChance;
        }
    }
    private void OnDisable()
    {
        CancelInvoke(nameof(Spawn));
    }
}
