using System;
using UnityEngine;

public abstract class CubeController : MonoBehaviour
{
    [SerializeField] ParticleSystem particleSystem;

    protected Rigidbody rb;

    protected virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    protected void Jump(float jumpForce)
    {
        if (IsGrounded())
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    protected bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, 1.1f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.CompareTag("Obstacle"))
        {
            Debug.Log("Obstacle");
            gameObject.SetActive(false);
            Instantiate(particleSystem, transform.position, Quaternion.identity);
            GameManager.Instance.GameOver();
        }
    }
}