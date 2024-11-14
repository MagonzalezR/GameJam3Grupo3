using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour
{
    private int value;
    public List<Transform> children;
    // Establecer el valor de la casa
    
    public void SetValue(int newValue)
    {
        value = newValue;
        switch (value)
        {
            case 2:
                children[0].gameObject.SetActive(true);
                for (int i = 1; i < children.Count; i++)
                {
                    children[i].gameObject.SetActive(false);
                }
                //Aqui se enciende 1 hijo prefab y se apaga el resto
                break;
            case 4:
                children[1].gameObject.SetActive(true);
                children[0].gameObject.SetActive(false);
                break;
            case 8: 
                children[2].gameObject.SetActive(true);
                children[1].gameObject.SetActive(false);
                break;
            case 16:
                children[3].gameObject.SetActive(true);
                children[2].gameObject.SetActive(false);
                break;
            case 32:
                children[4].gameObject.SetActive(true);
                children[3].gameObject.SetActive(false);
                break;
            case 64:
                children[5].gameObject.SetActive(true);
                children[4].gameObject.SetActive(false);
                break;
            case 128:
                children[6].gameObject.SetActive(true);
                children[5].gameObject.SetActive(false);
                break;
            case 256:;
                children[7].gameObject.SetActive(true);
                children[6].gameObject.SetActive(false);
                break;
            case 512:
                children[8].gameObject.SetActive(true);
                children[7].gameObject.SetActive(false);
                break;
            case 1024:
                children[9].gameObject.SetActive(true);
                children[8].gameObject.SetActive(false);
                break;
            case 2048:
                children[10].gameObject.SetActive(true);
                children[9].gameObject.SetActive(false);
                break;
        }
                //Aqui se enciende 2 hijo prefab y se apaga el resto
                // Espacio de actualizacion visual 
        }

        // Obtener el valor de la casa
        public int GetValue()
        {
            return value;
        }
    } 
