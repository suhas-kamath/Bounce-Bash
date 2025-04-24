using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
    public GameObject[] obstaclePrefabs;
    public GameObject coinPrefab;
    public Transform player;
    public float spawnInterval = 2f;
    public float xRange = 2f;
    public float xOffset = 10f;

    private float lastSpawnX;
    List<GameObject> spawnedObjects = new ();
    void Start () {
        lastSpawnX = player.position.x;
        GameManager.Instance.GameOverAction -= DestroyAllGameObject;
        GameManager.Instance.GameOverAction += DestroyAllGameObject;
    }
    void DestroyAllGameObject () {
        for (int i = 0; i < spawnedObjects.Count; i++) {
            Destroy (spawnedObjects[i]);
        }
        lastSpawnX = player.position.x;
    }
    void Update () {
        if (UiManager.Instance != null && UiManager.Instance.StartSpawing) {
            float playerX = player.position.x;
            while (lastSpawnX < playerX + xOffset) {
                spawnedObjects.Add (SpawnItem (lastSpawnX + spawnInterval));
                lastSpawnX += spawnInterval;
            }
        }
    }

    GameObject SpawnItem (float yPos) {

        float x = Random.Range (-xRange, xRange);
        int roll = Random.Range (0, 100);
        GameObject obj;

        if (roll < 70) {
            obj = Instantiate (coinPrefab, new Vector2 (yPos, x), Quaternion.identity);
        } else {
            int index = Random.Range (0, obstaclePrefabs.Length);
            obj = Instantiate (obstaclePrefabs[index], new Vector2 (yPos, x), Quaternion.identity);
        }

        obj.transform.SetParent (transform);
        return obj;
    }

}