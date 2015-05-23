using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour
{
    public GameObject[] SpawnObjects;
    public float timeMin = 0.7f;
    public float timeMax = 2f;

    GameObject SpawnObject;

    void Start()
    {
        SpawnObject = SpawnObjects[Random.Range(0, SpawnObjects.Length)];
        Spawn();
    }

    void Spawn() // RS: ugh!
    {
        if (GameStateManager.GameState == GameState.Playing)
        {
            Instantiate(SpawnObject, transform.position + Vector3.up * Random.Range(-0.5f, 1f), Quaternion.identity);
        }

        Invoke("Spawn", Random.Range(timeMin, timeMax));
    }
}
