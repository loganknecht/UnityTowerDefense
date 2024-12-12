using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float minimumSpawnTimer = 1f;
    public float maximumSpawnTimer = 3f;
    public GameObject gameObjectsToSpawn = null;
    public GameObject currentlySpawnedGameObject = null;
    public Transform startTransform = null;

    // Start is called before the first frame update
    void Start()
    {
        if (currentlySpawnedGameObject == null)
        {
            UnityEngine.Debug.Log($"X: {this.startTransform.position.x} Y: {this.startTransform.position.y} Z: {this.startTransform.position.z}");
            this.currentlySpawnedGameObject = Instantiate(this.gameObjectsToSpawn, this.startTransform.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


}
