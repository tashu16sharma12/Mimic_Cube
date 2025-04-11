using System.Collections;
using UnityEngine;

public class DestroyDelay : MonoBehaviour
{
    [SerializeField] float delay;

    private void Start()
    {
        StartCoroutine(DelayAndDestroy());
    }

    IEnumerator DelayAndDestroy()
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
