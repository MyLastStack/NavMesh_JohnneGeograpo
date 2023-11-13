using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraScript : MonoBehaviour
{
    [SerializeField] InputAction camAction, toggleAction;
    public Vector2 camRotation;
    float rotateSpd;

    float xRot;
    float yRot;

    [SerializeField] Transform orientation, camLeverage;

    void Start()
    {
        Cursor.lockState = CursorLockMode.None;

        rotateSpd = 150.0f;
    }

    void Update()
    {
        if (toggleAction.inProgress)
        {
            Cursor.lockState = CursorLockMode.Locked;
            camRotation = camAction.ReadValue<Vector2>();

            float mouseX = camRotation.x * Time.deltaTime * rotateSpd;
            float mouseY = camRotation.y * Time.deltaTime * rotateSpd * 0.5f;
            
            xRot += mouseX;
            yRot -= mouseY;
            xRot = Mathf.Clamp(xRot, -30f, 90f);

            camLeverage.rotation = Quaternion.Euler(xRot, yRot, 0);
            orientation.rotation = Quaternion.Euler(0, yRot, 0);
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void OnEnable()
    {
        camAction.Enable();
        toggleAction.Enable();
    }
    private void OnDisable()
    {
        camAction.Disable();
        toggleAction.Disable();
    }
}
