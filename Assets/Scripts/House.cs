using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    private int value;
    private Dictionary<int, GameObject> housePrefabs;  // Diccionario para almacenar los prefabs por valor

    // Lista de prefabs asignados desde el Inspector
    public GameObject prefab2;
    public GameObject prefab4;
    public GameObject prefab8;
    public GameObject prefab16;
    public GameObject prefab32;
    public GameObject prefab64;
    public GameObject prefab128;
    public GameObject prefab256;
    public GameObject prefab512;
    public GameObject prefab1024;
    public GameObject prefab2048;

    private void Awake()
    {
        // Inicializar el diccionario y asociar valores con prefabs
        housePrefabs = new Dictionary<int, GameObject>
        {
            { 2, prefab2 },
            { 4, prefab4 },
            { 8, prefab8 },
            { 16, prefab16 },
            { 32, prefab32 },
            { 64, prefab64 },
            { 128, prefab128 },
            { 256, prefab256 },
            { 512, prefab512 },
            { 1024, prefab1024 },
            { 2048, prefab2048 }
        };
    }

    // Establecer el valor de la casa
    public void SetValue(int newValue)
    {
        value = newValue;

        // Aquí puedes agregar lógica para actualizar visualmente si lo deseas
    }

    // Obtener el valor de la casa
    public int GetValue()
    {
        return value;
    }
}
