using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    public Button rotateButton;
    public Vector3 targetRotation;
    public float rotationSpeed = 1f; // Velocidad de rotación

    private Quaternion targetQuaternion;
    private bool isRotating = false;

    void Start()
    {
        rotateButton.onClick.AddListener(StartRotation);
        targetQuaternion = Quaternion.Euler(targetRotation);
    }

    void Update()
    {
        if (isRotating)
        {
            // Lerp para una rotación suave hacia la rotación objetivo
            transform.rotation = Quaternion.Lerp(transform.rotation, targetQuaternion, rotationSpeed * Time.deltaTime);

            // Verifica si la cámara ha llegado a la rotación deseada
            if (Quaternion.Angle(transform.rotation, targetQuaternion) < 0.1f)
            {
                transform.rotation = targetQuaternion; // Asegura la rotación exacta
                isRotating = false; // Detiene la rotación
            }
        }
    }

    void StartRotation()
    {
        targetQuaternion = Quaternion.Euler(targetRotation); // Configura la rotación objetivo
        isRotating = true; // Activa la rotación
    }
}
