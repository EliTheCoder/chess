using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : ChessObject
{
    

    public override Color CalculateColor()
    {
        float sum = matrixPosition.x + matrixPosition.y + matrixPosition.z + matrixPosition.w;
        if (sum % 2 == 0)
        {
            return Grandmaster.instance.boardColor1;
        }
        else
        {
            return Grandmaster.instance.boardColor2;
        }
    }

    public static void DeselectAll()
    {
        foreach (Cell cell in Grandmaster.instance.boardCells)
        {
            cell.Deselect();
        }
    }


}
