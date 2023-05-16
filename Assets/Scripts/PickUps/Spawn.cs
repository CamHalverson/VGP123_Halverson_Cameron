using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject[] pickups;
    public Transform[] spawnPoints;

    // Start is called before the first frame update
    void Start()
    {
        if (pickups == null)
            Debug.Log("Assign pickups to spawner");

        if (spawnPoints == null)
            Debug.Log("Assign spawn points to spawner");

        int pickupSize = pickups.Length;

        for (int i = 0; i < spawnPoints.Length; i++)
        {
            int randomPickup = Random.Range(0, pickupSize);

            Instantiate(pickups[randomPickup], spawnPoints[i].position, spawnPoints[i].rotation);
        }

    }
}
