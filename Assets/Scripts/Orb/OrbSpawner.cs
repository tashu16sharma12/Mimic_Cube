using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbSpawner : MonoBehaviour
{
    [SerializeField] Orb orbPrefab;
    [SerializeField] static float orbSpeed;

    [SerializeField] float startSpawnSpeed = 5f;
    [SerializeField] float minSpawnSpeed = 1.5f;
    [SerializeField] float rateOfDecSpawnSpeed = 0.01f;
    [SerializeField] float spawnSpeed = 3f;

    [SerializeField] float startSpeed = 5f;
    [SerializeField] float maxSpeed = 40f;
    [SerializeField] float speedIncreaseRate = 0.5f;

    [SerializeField] float spawnZ = 200f;
    [SerializeField] int queueLenght;
    [SerializeField] Queue<Orb> OrbPooling = new Queue<Orb>();

    public static float OrbSpeed
    {
        get => orbSpeed;
    }

    public void StartGame()
    {
        Restart();
    }
    public void GameStop()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (orbSpeed < maxSpeed)
        {
            orbSpeed += speedIncreaseRate * Time.deltaTime;
        }

        if (spawnSpeed > minSpawnSpeed)
        {
            spawnSpeed -= spawnSpeed * rateOfDecSpawnSpeed * Time.deltaTime;
        }
    }

    IEnumerator SpawnRepeating()
    {
        float[] lanes = { -2.5f, 2.5f };
        float side = lanes[Random.Range(0, 2)];
        int orbPairs = Random.Range(3, 5);

        Debug.Log("Start Spawning Orbs: " + side);

        for (int i = 0; i < orbPairs; i++)
        {
            SpawnOrb(side);
            yield return new WaitForSeconds(spawnSpeed);
        }

        StartCoroutine(SpawnRepeating());
    }

    void SpawnOrb(float side)
    {
        Vector3 spawnPos = new Vector3(side, -3.5f, spawnZ);

        if (OrbPooling.Count < queueLenght)
        {
            OrbPooling.Enqueue(Instantiate(orbPrefab, spawnPos, Quaternion.identity));
        }
        else
        {
            Orb orb = OrbPooling.Dequeue();
            orb.transform.position = spawnPos;
            orb.gameObject.SetActive(true);
            OrbPooling.Enqueue(orb);
        }
    }

    public void Restart()
    {
        gameObject.SetActive(true);
        spawnSpeed = startSpawnSpeed;
        orbSpeed = startSpeed;
        DeleteOrbs();
        StartCoroutine(SpawnRepeating());
    }

    void DeleteOrbs()
    {
        foreach (Orb item in OrbPooling)
        {
            Destroy(item.gameObject);
        }

        OrbPooling.Clear();
    }
}
