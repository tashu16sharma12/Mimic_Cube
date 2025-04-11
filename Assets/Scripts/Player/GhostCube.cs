using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GhostCube : CubeController
{
    public float delayTime = 0.2f; // simulate network delay

    protected override void Start()
    {
        base.Start();
        Observer.JumpSync += OnJumpReceived;
    }

    private void OnDestroy()
    {
        Observer.JumpSync -= OnJumpReceived;
    }

    void OnJumpReceived(float jumpForce)
    {
        StartCoroutine(DelayedJump(jumpForce));
    }

    IEnumerator DelayedJump(float jumpForce)
    {
        yield return new WaitForSeconds(delayTime);
        Jump(jumpForce);
    }
}

