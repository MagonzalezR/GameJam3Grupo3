using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public Button rotateButton; 
    public Vector3 targetRotation;
    public float rotationSpeed = 1f; 

    private Quaternion targetQuaternion;
    private bool isRotating = false;

    public void Start()
    {
        rotateButton.onClick.AddListener(StartRotation);
        targetQuaternion = Quaternion.Euler(targetRotation);
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (isRotating)
        {
            
            transform.rotation = Quaternion.Lerp(transform.rotation, targetQuaternion, rotationSpeed * Time.deltaTime);

            
            if (Quaternion.Angle(transform.rotation, targetQuaternion) < 0.1f)
            {
                transform.rotation = targetQuaternion; 
                isRotating = false; 
            }
        }
    }

    void StartRotation()
    {
        targetQuaternion = Quaternion.Euler(targetRotation); // Configura la rotación objetivo
        isRotating = true; // Activa la rotación
    }
}
