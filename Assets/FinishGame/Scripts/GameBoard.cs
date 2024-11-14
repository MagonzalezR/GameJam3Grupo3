using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GameBoard : MonoBehaviour
{
    public GameObject housePrefab;  // Prefab de la casa
    public GameObject canvasObj;  // Prefab de la casa
    public int boardSize = 4;       // Tama�o del tablero (ej. 4x4)
    public float cellSize = 2f;     // Espacio entre celdas

    private House[,] board;         // Array bidimensional para almacenar las casas

    public AudioClip clip;           //CLip de sonido cuando se mueven las fichas

    private void Start()
    {
        board = new House[boardSize, boardSize];  // Inicializar el tablero
        InitializeBoard();                        // Iniciar el tablero y generar casas
    }

    private void Update()
    {
        // Detectar entrada del usuario para mover las casas
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            MoveHouses(Vector2Int.up);
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            MoveHouses(Vector2Int.down);
        }
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            MoveHouses(Vector2Int.left);
        }
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            MoveHouses(Vector2Int.right);
        }
    }

    // Inicializar el tablero con casas iniciales
    private void InitializeBoard()
    {
        SpawnInitialHouses();
    }

    // Generar casas iniciales en posiciones aleatorias
    private void SpawnInitialHouses()
    {
        PlaceRandomHouse();
        PlaceRandomHouse();
    }

    // Colocar una casa en una posici�n aleatoria en el tablero
    private void PlaceRandomHouse()
    {
        List<Vector2Int> emptyPositions = GetEmptyPositions();
        if (emptyPositions.Count > 0)
        {
            Vector2Int position = emptyPositions[Random.Range(0, emptyPositions.Count)];
            InstantiateHouse(position.x, position.y, 2);  // Iniciar con valor 2
        }
    }

    // Obtener las posiciones vac�as en el tablero
    private List<Vector2Int> GetEmptyPositions()
    {
        List<Vector2Int> emptyPositions = new List<Vector2Int>();
        for (int x = 0; x < boardSize; x++)
        {
            for (int y = 0; y < boardSize; y++)
            {
                if (board[x, y] == null)
                {
                    emptyPositions.Add(new Vector2Int(x, y));
                }
            }
        }
        return emptyPositions;
    }

    // Instanciar una casa en una posici�n espec�fica y almacenar en el array board
    private void InstantiateHouse(int x, int y, int value)
    {
        Vector3 position = new Vector3(x * cellSize, 0, y * cellSize);
        GameObject houseObject = Instantiate(housePrefab, position, Quaternion.identity);

        // Configurar el valor de la casa
        House house = houseObject.GetComponent<House>();
        house.SetValue(value);

        // Almacenar la casa en el array del tablero
        board[x, y] = house;
    }

    // Obtener la casa en una posici�n espec�fica del tablero
    private House GetHouseAtPosition(int x, int y)
    {
        // Verificar que la posici�n est� dentro de los l�mites del tablero
        if (x >= 0 && x < boardSize && y >= 0 && y < boardSize)
        {
            return board[x, y];
        }
        return null;
    }

    // Mover todas las casas en una direcci�n espec�fica
    private void MoveHouses(Vector2Int direction)
    {
        bool moved = false;

        // Recorre el tablero y mueve cada casa
        for (int x = 0; x < boardSize; x++)
        {
            for (int y = 0; y < boardSize; y++)
            {
                House house = GetHouseAtPosition(x, y);
                if (house != null)
                {
                    if (MoveHouse(house, direction))
                    {
                        moved = true;
                    }
                }
            }
        }

        // Si se realiz� alg�n movimiento, colocar una nueva casa
        if (moved)
        {
            AudioManager.Instance.PlaySFX(clip);
            PlaceRandomHouse();
        } else {
            canvasObj.GetComponent<PauseMenu>().GameOverPanel();
        }
    }

    // Mover una casa en la direcci�n especificada
    private bool MoveHouse(House house, Vector2Int direction)
    {
        // Obtener la posici�n actual en el array `board`
        int currentX = Mathf.RoundToInt(house.transform.position.x / cellSize);
        int currentY = Mathf.RoundToInt(house.transform.position.z / cellSize);
        Vector2Int targetPos = new Vector2Int(currentX + direction.x, currentY + direction.y);

        // Verificar si la posici�n destino est� dentro del tablero
        if (targetPos.x >= 0 && targetPos.x < boardSize && targetPos.y >= 0 && targetPos.y < boardSize)
        {
            House targetHouse = GetHouseAtPosition(targetPos.x, targetPos.y);
            if (targetHouse == null)
            {
                // Si la posici�n destino est� vac�a, mover la casa
                board[currentX, currentY] = null;  // Vaciar la posici�n actual
                board[targetPos.x, targetPos.y] = house;   // Mover la casa a la nueva posici�n
                house.transform.position = new Vector3(targetPos.x * cellSize, 0, targetPos.y * cellSize);
                return true;  // Indica que se realiz� un movimiento
            }
            else if (targetHouse.GetValue() == house.GetValue())
            {
                // Si la posici�n destino tiene una casa del mismo valor, combinar casas
                targetHouse.SetValue(targetHouse.GetValue() * 2);  // Duplicar el valor de la casa destino
                Destroy(house.gameObject);                         // Destruir la casa actual
                board[currentX, currentY] = null;                  // Vaciar la posici�n original
                return true;  // Indica que se realiz� un movimiento
            }
        }

        return false;  // No se realiz� ning�n movimiento
    }
}
