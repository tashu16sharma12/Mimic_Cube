using UnityEngine;

public class Obstacle : MonoBehaviour
{
    void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(Vector3.back * ObstacleSpawner.ObstacleSpeed * Time.deltaTime);

        if (transform.position.z < -5f)
        {
            gameObject.SetActive(false);
        }
    }
}
