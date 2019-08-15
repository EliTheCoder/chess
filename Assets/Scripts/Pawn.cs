using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pawn : Piece
{
    public override List<Cell> GetMoves()
    {
        List<Cell> possibleMoves = new List<Cell>();
        int directionMultiplier = (team == Team.White) ? 1 : 0;

        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(0, 1 * directionMultiplier, 0, 0)));
        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(0, 0, 0, 0)));

        return possibleMoves;
    }
}
