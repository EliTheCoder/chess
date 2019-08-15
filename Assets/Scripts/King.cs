using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class King : Piece
{
    bool isValidMove(Cell cell)
    {
        float distX = Mathf.Abs(matrixPosition.x - cell.matrixPosition.x);
        float distY = Mathf.Abs(matrixPosition.y - cell.matrixPosition.y);
        float distZ = Mathf.Abs(matrixPosition.z - cell.matrixPosition.z);
        float distW = Mathf.Abs(matrixPosition.w - cell.matrixPosition.w);

        if (distX <= 1 && distY <= 1 && distZ <= 1 && distW <= 1 && (distX + distY + distZ + distW <= 2))
        {
            return true;
        }
        return false;
    }
    public override List<Cell> GetMoves()
    {
        List<Cell> possibleMoves = new List<Cell>();

        foreach (Cell cell in Grandmaster.instance.boardCells)
        {
            if (isValidMove(cell) && cell.matrixPosition != matrixPosition)
            {
                Piece pieceAtCell = Grandmaster.instance.GetPiece(cell.matrixPosition);
                if (pieceAtCell == null || pieceAtCell.GetTeam() != team)
                {
                    possibleMoves.Add(cell);
                }
            }
        }

        return possibleMoves;
    }
}
