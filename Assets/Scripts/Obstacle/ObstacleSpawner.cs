using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    [SerializeField] Obstacle obstaclePrefab;
    [SerializeField] static float obstacleSpeed;

    [SerializeField] float startSpawnSpeed = 5f;
    [SerializeField] float minSpawnSpeed = 1.5f;
    [SerializeField] float rateOfDecSpawnSpeed = 0.01f;
    [SerializeField] float spawnSpeed = 3f;

    [SerializeField] float startSpeed = 5f;
    [SerializeField] float maxSpeed = 40f;
    [SerializeField] float speedIncreaseRate = 0.5f;

    [SerializeField] float spawnZ = 200f;
    [SerializeField] int queueLenght;
    [SerializeField] Queue<Obstacle> ObstaclePooling = new Queue<Obstacle>();

    public static float ObstacleSpeed
    {
        get => obstacleSpeed;
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
        if (obstacleSpeed < maxSpeed)
        {
            obstacleSpeed += speedIncreaseRate * Time.deltaTime;
        }

        if (spawnSpeed > minSpawnSpeed)
        {
            spawnSpeed -= spawnSpeed * rateOfDecSpawnSpeed * Time.deltaTime;
        }
    }

    IEnumerator SpawnRepeating()
    {
        while(true)
        {
            SpawnObstacle();
            yield return new WaitForSeconds(spawnSpeed);
        }
    }

    void SpawnObstacle()
    {
        float[] lanes = { -2.5f, 2.5f };
        float laneX = lanes[Random.Range(0, lanes.Length)];

        Vector3 spawnPos = new Vector3(laneX, -3.5f, spawnZ);

        if(ObstaclePooling.Count < queueLenght)
        {
            ObstaclePooling.Enqueue(Instantiate(obstaclePrefab, spawnPos, Quaternion.identity));
        }
        else
        {
            Obstacle obstacle = ObstaclePooling.Dequeue();
            obstacle.transform.position = spawnPos;
            obstacle.gameObject.SetActive(true);
            ObstaclePooling.Enqueue(obstacle);
        }
    }

    public void Restart()
    {
        gameObject.SetActive(true);
        spawnSpeed = startSpawnSpeed;
        obstacleSpeed = startSpeed;
        DeleteObstacles();
        StartCoroutine(SpawnRepeating());
    }

    void DeleteObstacles()
    {
        foreach(Obstacle item in ObstaclePooling)
        {
            Destroy(item.gameObject);
        }

        ObstaclePooling.Clear();
    }
}
