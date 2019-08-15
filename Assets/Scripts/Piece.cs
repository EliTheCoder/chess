using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Team
{
    White,
    Black
}


public abstract class Piece : ChessObject
{
    protected Team team;

    public override Color CalculateColor()
    {
        if (team == Team.White)
        {
            return Color.white;
        }
        else
        {
            return Color.black;
        }
    }

    public void SetTeam(Team newTeam)
    {
        team = newTeam;

    }

    public Team GetTeam()
    {
        return team;
    }

    public abstract List<Cell> GetMoves();
}
