using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private HouseTile[,] grid; // Matriz para organizar la cuadrícula de casas

    // Función que mueve y fusiona las casas
    public void Move(Vector2Int direction)
    {
        // Aquí va la lógica para mover las casas en la dirección deseada.
        // Una vez movidas, verifica si pueden fusionarse.

        for (int x = 0; x < grid.GetLength(0); x++)
        {
            for (int y = 0; y < grid.GetLength(1); y++)
            {
                HouseTile currentTile = grid[x, y];
                if (currentTile != null)
                {
                    Vector2Int targetPos = new Vector2Int(x, y) + direction;
                    if (IsInsideGrid(targetPos) && grid[targetPos.x, targetPos.y] != null)
                    {
                        HouseTile targetTile = grid[targetPos.x, targetPos.y];
                        TryMergeTiles(currentTile, targetTile); // Llama a TryMergeTiles si pueden fusionarse
                    }
                }
            }
        }
    }

    // Función para intentar fusionar dos casas
    private void TryMergeTiles(HouseTile tileA, HouseTile tileB)
    {
        if (tileA.Level == tileB.Level) // Fusiona solo si están en el mismo nivel
        {
            tileA.LevelUp(); // Sube el nivel de tileA
            Destroy(tileB.gameObject); // Destruye tileB después de la fusión
        }
    }

    // Verifica si la posición está dentro de los límites de la cuadrícula
    private bool IsInsideGrid(Vector2Int position)
    {
        return position.x >= 0 && position.x < grid.GetLength(0) && position.y >= 0 && position.y < grid.GetLength(1);
    }
}
