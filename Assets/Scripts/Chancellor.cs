using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chancellor : Piece
{
    public override List<Cell> GetMoves()
    {
        List<Cell> possibleMoves = new List<Cell>();

        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(1, 2, 0, 0), 1));
        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(1, 0, 2, 0), 1));
        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(1, 0, 0, 2), 1));
        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(0, 1, 2, 0), 1));
        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(0, 1, 0, 2), 1));
        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(0, 0, 1, 2), 1));

        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(-1, 2, 0, 0), 1));
        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(-1, 0, 2, 0), 1));
        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(-1, 0, 0, 2), 1));
        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(0, -1, 2, 0), 1));
        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(0, -1, 0, 2), 1));
        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(0, 0, -1, 2), 1));

        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(1, -2, 0, 0), 1));
        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(1, 0, -2, 0), 1));
        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(1, 0, 0, -2), 1));
        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(0, 1, -2, 0), 1));
        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(0, 1, 0, -2), 1));
        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(0, 0, 1, -2), 1));

        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(-1, -2, 0, 0), 1));
        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(-1, 0, -2, 0), 1));
        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(-1, 0, 0, -2), 1));
        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(0, -1, -2, 0), 1));
        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(0, -1, 0, 2), 1));
        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(0, 0, -1, -2), 1));



        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(2, 1, 0, 0), 1));
        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(2, 0, 1, 0), 1));
        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(2, 0, 0, 1), 1));
        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(0, 2, 1, 0), 1));
        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(0, 2, 0, 1), 1));
        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(0, 0, 2, 1), 1));

        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(-2, 1, 0, 0), 1));
        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(-2, 0, 1, 0), 1));
        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(-2, 0, 0, 1), 1));
        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(0, -2, 1, 0), 1));
        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(0, -2, 0, 1), 1));
        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(0, 0, -2, 1), 1));

        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(2, -1, 0, 0), 1));
        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(2, 0, -1, 0), 1));
        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(2, 0, 0, -1), 1));
        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(0, 2, -1, 0), 1));
        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(0, 2, 0, -1), 1));
        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(0, 0, 2, -1), 1));

        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(-2, -1, 0, 0), 1));
        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(-2, 0, -1, 0), 1));
        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(-2, 0, 0, -1), 1));
        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(0, -2, -1, 0), 1));
        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(0, -2, 0, 1), 1));
        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(0, 0, -2, -1), 1));




        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(1, 0, 0, 0)));
        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(0, 1, 0, 0)));
        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(0, 0, 1, 0)));
        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(0, 0, 0, 1)));
        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(-1, 0, 0, 0)));
        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(0, -1, 0, 0)));
        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(0, 0, -1, 0)));
        possibleMoves.AddRange(Grandmaster.instance.ChessRaycast(this, new Vector4(0, 0, 0, -1)));

        return possibleMoves;
    }
}
