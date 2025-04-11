using UnityEngine;

public class Orb : MonoBehaviour
{
    [SerializeField] ParticleSystem orbBurst;
    Vector3 spawnPos = Vector3.zero;

    private void OnEnable()
    {
        spawnPos = Vector3.zero;
    }

    void Update()
    {
        if (transform.position.z < -5f)
        {
            gameObject.SetActive(false);
        }

        transform.Translate((Vector3.back + spawnPos) * OrbSpawner.OrbSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.transform.CompareTag("Obstacle"))
        {
            spawnPos = Vector3.up * -2.75f;
        }

        if(other.transform.CompareTag("Player"))
        {
            Observer.Score.Invoke(1);
            Instantiate(orbBurst, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }

        if (other.transform.CompareTag("Ghost"))
        {
            Observer.Score.Invoke(2);
            Instantiate(orbBurst, transform.position, Quaternion.identity);
            gameObject.SetActive(false);
        }
    }
}
