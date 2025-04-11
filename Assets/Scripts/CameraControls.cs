using DG.Tweening;
using UnityEngine;

public class CameraControls : MonoBehaviour
{
    [SerializeField] float duration = 0.5f;
    [SerializeField] float strength = 0.5f;
    [SerializeField] int vibrato = 10;
    [SerializeField] float randomness = 90f;

    public void Shake()
    {
        transform.DOShakePosition(duration, strength, vibrato, randomness);
    }
}
