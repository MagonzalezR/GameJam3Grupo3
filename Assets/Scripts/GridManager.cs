using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    private HouseTile[,] grid; // Matriz para organizar la cuadr�cula de casas

    // Funci�n que mueve y fusiona las casas
    public void Move(Vector2Int direction)
    {
        // Aqu� va la l�gica para mover las casas en la direcci�n deseada.
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

    // Funci�n para intentar fusionar dos casas
    private void TryMergeTiles(HouseTile tileA, HouseTile tileB)
    {
        if (tileA.Level == tileB.Level) // Fusiona solo si est�n en el mismo nivel
        {
            tileA.LevelUp(); // Sube el nivel de tileA
            Destroy(tileB.gameObject); // Destruye tileB despu�s de la fusi�n
        }
    }

    // Verifica si la posici�n est� dentro de los l�mites de la cuadr�cula
    private bool IsInsideGrid(Vector2Int position)
    {
        return position.x >= 0 && position.x < grid.GetLength(0) && position.y >= 0 && position.y < grid.GetLength(1);
    }
}
