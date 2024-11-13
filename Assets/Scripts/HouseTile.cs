using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseTile : MonoBehaviour
{
    public int Level { get; private set; } = 1; // Nivel inicial de la casa
    public GameObject[] levelPrefabs; // Array de prefabs para cada nivel

    // Método para subir el nivel cuando dos casas se fusionan
    public void LevelUp()
    {
        Level++; // Incrementa el nivel
        UpdateAppearance(); // Actualiza el aspecto de la casa para reflejar el cambio
    }

    // Método para actualizar la apariencia visual de la casa
    public void UpdateAppearance()
    {
        if (Level - 1 < levelPrefabs.Length) // Asegura que el nivel esté en el rango de prefabs
        {
            // Elimina el prefab actual
            foreach (Transform child in transform)
            {
                Destroy(child.gameObject);
            }
            // Instancia el nuevo prefab del nivel
            Instantiate(levelPrefabs[Level - 1], transform.position, Quaternion.identity, transform);
        }
        else
        {
            Debug.LogWarning("No hay un prefab para el nivel: " + Level);
        }
    }
}
