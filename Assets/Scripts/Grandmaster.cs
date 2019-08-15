using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grandmaster : MonoBehaviour
{

    [SerializeField] Cell cellPrefab;


    [SerializeField] King kingPrefab;
    [SerializeField] Queen queenPrefab;
    [SerializeField] Archbishop archbishopPrefab;
    [SerializeField] Chancellor chancellorPrefab;
    [SerializeField] Bishop bishopPrefab;
    [SerializeField] Knight knightPrefab;
    [SerializeField] Rook rookPrefab;
    [SerializeField] Pawn pawnPrefab;

    [HideInInspector] public List<Cell> boardCells;
    [HideInInspector] public List<Piece> boardPieces;

    public Color selectColor;
    public Color boardColor1;
    public Color boardColor2;
    public Vector4 boardSize;
    public float zoom;
    public float boardSpacing;
    public Team activeTeam;

    public static Grandmaster instance;

    private Piece selectedPiece;

    public void Initialize()
    {
        boardCells.Clear();
        boardPieces.Clear();
        for (int x = 1; x <= boardSize.x; x++)
        {
            for (int y = 1; y <= boardSize.y; y++)
            {
                for (int z = 1; z <= boardSize.z; z++)
                {
                    for (int w = 1; w <= boardSize.w; w++)
                    {
                        Cell newCell = Instantiate(cellPrefab, transform);
                        newCell.Initialize(new Vector4(x, y, z, w));
                        boardCells.Add(newCell);
                    }
                }
            }
        }
        float cameraPosX = ( boardSize.x * boardSize.z + ((boardSize.z - 1) * 1f) ) / 2 + 0.5f;
        float cameraPosY = ( boardSize.y * boardSize.w + ((boardSize.w - 1) * 1f) ) / 2 + 0.5f;
        Camera.main.transform.position = new Vector3(cameraPosX, cameraPosY, -10);
        Camera.main.orthographicSize = ( (boardSize.x * boardSize.z) + ((boardSize.z - 1) * 1f) + (boardSize.y * boardSize.w) + ((boardSize.w - 1) * 1f) ) / zoom;
    }

    public void LoadMfen(string mfen)
    {
        string[] mfenArray = mfen.Split(' ');

        string[] sizes = mfenArray[0].Split('/');
        boardSize.x = float.Parse(sizes[0]);
        boardSize.y = float.Parse(sizes[1]);
        boardSize.z = float.Parse(sizes[2]);
        boardSize.w = float.Parse(sizes[3]);
        Initialize();

        string[] positionsW = mfenArray[1].Split('~');
        for (int w = 0; w < positionsW.Length; w++)
        {
            string[] positionsZ = positionsW[w].Split('-');
            for (int z = 0; z < positionsZ.Length; z++)
            {
                string[] positionsY = positionsZ[z].Split('/');
                for (int y = 0; y < positionsY.Length; y++)
                {
                    string[] positionsX = positionsY[y].Split('.');
                    int skipNo = 0;
                    for (int x = 0; x < positionsX.Length; x++)
                    {
                        if (int.TryParse(positionsX[x], out int skip))
                        {
                            skipNo += skip - 1;
                            continue;
                        }
                        Piece pieceType = LetterToPieceType(positionsX[x]);
                        if (pieceType == null)
                        {
                            throw new System.Exception("Error parsing MFEN string!");
                        }
                        Team team = (positionsX[x].ToUpper() == positionsX[x]) ? Team.White : Team.Black;
                        AddPiece(pieceType, team, new Vector4(x+1+skipNo, y+1, z+1, w+1));
                    }
                }
            }
        }

        activeTeam = (mfenArray[2] == "w") ? Team.White : Team.Black;

    }

    public Piece AddPiece(Piece piecePrefab, Team team, Vector4 matrixPos)
    {
        Piece newPiece = Instantiate(piecePrefab, transform);
        newPiece.SetTeam(team);
        newPiece.Initialize(matrixPos);
        boardPieces.Add(newPiece);
        return newPiece;
    }

    ChessObject GetClickedObject()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit)
            {
                return hit.transform.GetComponent<ChessObject>();
            }
        }
        return null;
    }

    public Piece GetPiece(Vector4 matrixPos)
    {
        foreach (Piece piece in boardPieces)
        {
            if (matrixPos == piece.matrixPosition)
            {
                return piece;
            }
        }
        return null;
    }

    public List<Cell> ChessRaycast(Piece piece, Vector4 direction)
    {
        return ChessRaycast(piece, direction, 999);
    }

    public List<Cell> ChessRaycast(Piece piece, Vector4 direction, int distance)
    {
        List<Cell> cells = new List<Cell>();
        int counter = 0;
        Vector4 matrixPos = piece.matrixPosition;
        while (counter < distance)
        {
            matrixPos += direction;
            counter++;
            Cell cell = GetCell(matrixPos);
            if (cell == null) break;
            Piece pieceAtCell = GetPiece(matrixPos);
            if (pieceAtCell != null)
            {
                if (pieceAtCell.GetTeam() == piece.GetTeam())
                {
                    break;
                }
                cells.Add(cell);
                break;
            }
            cells.Add(cell);
        }
        return cells;
    }

    public Cell GetCell(Vector4 matrixPos)
    {
        foreach (Cell cell in boardCells)
        {
            if (matrixPos == cell.matrixPosition)
            {
                return cell;
            }
        }
        return null;
    }

    public void MovePiece(Piece piece, Vector4 matrixPos)
    {
        Piece pieceAtCell = GetPiece(matrixPos);
        if (pieceAtCell != null && pieceAtCell.GetTeam() != activeTeam)
        {
            boardPieces.Remove(pieceAtCell);
            Destroy(pieceAtCell.gameObject);
        }
        piece.Initialize(matrixPos);
        Cell.DeselectAll();
        selectedPiece.Deselect();
        selectedPiece = null;

        activeTeam = (activeTeam == Team.White) ? Team.Black : Team.White;
    }

    public void RemovePiece(Piece piece)
    {
        boardPieces.Remove(piece);
        Destroy(piece.gameObject);
    }

    Piece LetterToPieceType(string letter)
    {
        letter = letter.ToUpper();
        switch (letter)
        {
            case "A":
                return archbishopPrefab;
            case "B":
                return bishopPrefab;
            case "C":
                return chancellorPrefab;
            case "K":
                return kingPrefab;
            case "N":
                return knightPrefab;
            case "P":
                return pawnPrefab;
            case "Q":
                return queenPrefab;
            case "R":
                return rookPrefab;
            default:
                return null;
        }
    }

    void CalculateSelection(Piece clickedPiece)
    {
        if (selectedPiece == null)
        {
            if (clickedPiece is Piece)
            {
                clickedPiece.Select();
                selectedPiece = clickedPiece as Piece;
                foreach (Cell cell in selectedPiece.GetMoves())
                {
                    cell.Select();
                }
            }
        }
        else if (selectedPiece != null)
        {
            if (clickedPiece is Piece)
            {
                Cell.DeselectAll();
                selectedPiece.Deselect();
                if (selectedPiece != clickedPiece)
                {
                    clickedPiece.Select();
                    selectedPiece = clickedPiece as Piece;
                    foreach (Cell cell in selectedPiece.GetMoves())
                    {
                        cell.Select();
                    }
                }
                else
                {
                    selectedPiece = null;
                }
            }
        }
    }

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        //LoadMfen("4/4/5/4 K/4/1.n.R.1/4-1.B.2~k b - - 0 1");

        // Standard Game
        LoadMfen("8/8/2/2 R.N.B.Q.K.B.N.R/P.P.P.P.P.P.P.P~8-8/8/8/8/8/8/p.p.p.p.p.p.p.p/r.n.b.q.k.b.n.r w");

       /* Initialize();
        AddPiece(kingPrefab, Team.White, new Vector4(1, 1, 1, 1));
        AddPiece(archbishopPrefab, Team.White, new Vector4(2, 1, 2, 1));
        AddPiece(chancellorPrefab, Team.Black, new Vector4(2, 3, 1, 1));
        activeTeam = Team.White;*/
    }

    void Update()
    {
        ChessObject clickedObject = GetClickedObject();
        if (clickedObject == null) return;
        if (clickedObject is Piece)
        {
            Piece clickedPiece = clickedObject as Piece;
            if (clickedPiece.GetTeam() == activeTeam)
            {
                CalculateSelection(clickedPiece);
            }
            else if (GetCell(clickedPiece.matrixPosition).isSelected())
            {
                MovePiece(selectedPiece, clickedPiece.matrixPosition);
            }
        }

        if (clickedObject is Cell && clickedObject.isSelected() && selectedPiece != null)
        {
            MovePiece(selectedPiece, clickedObject.matrixPosition);
        }
        
    }
}
