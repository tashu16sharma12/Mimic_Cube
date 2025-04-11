using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerCube : CubeController
{
    [SerializeField] float jumpForce = 5f;

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Jump(jumpForce);
            Observer.JumpSync.Invoke(jumpForce);
        }
    }
}

