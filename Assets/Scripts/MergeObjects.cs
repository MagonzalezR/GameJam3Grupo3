using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MergeComponent : MonoBehaviour
{
    public GameObject[] BuildingPrefabs; 

    public void CombineShips(int currentLevel, Vector3 position)
    {
        if (currentLevel < BuildingPrefabs.Length - 1) 
        {
            Destroy(BuildingPrefabs[currentLevel]);

            Instantiate(BuildingPrefabs[currentLevel + 1], position, Quaternion.identity);
        }
        else
        {
            Debug.Log("Nivel máximo alcanzado, no se puede combinar más.");
        }
    }
}
