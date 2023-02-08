using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodSpawner : MonoBehaviour
{
    [Header("Food Spawning Attributes")]
    [SerializeField] private List<GameObject> food = new List<GameObject>();
    [SerializeField] private float timer;
    private float initialTime;
    [SerializeField] private Transform[] spawnPoints;

    private void Start()
    {
        initialTime = timer;
    }

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            //Vector3 randomSpawnPosition = new Vector3(Random.Range(.25f, -.25f), .02f, Random.Range(.25f, -.25f));
            //Instantiate(food[Random.Range(0, 5)], randomSpawnPosition, Quaternion.identity, this.transform);
            Transform sp = spawnPoints[Random.Range(0, 25)];
            Instantiate(food[Random.Range(0, 5)], sp.position, Quaternion.identity, this.transform);
            timer = initialTime;
        }
    }
}
