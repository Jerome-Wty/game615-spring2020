using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : MonoBehaviour
{
    public static Transform[,] chessboard = new Transform[8, 8];
    public GameObject originalSquare;
    public Transform chessboardParent;
    public Transform chessPieces;
    const int SQUARE_SIZE = 2;

    public static GameState _instance;

    List<Square> squareList = new List<Square>();

    private void Awake()
    {
        _instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                GameObject square = Instantiate(originalSquare, chessboardParent);
                square.GetComponent<Square>().i = i;
                square.GetComponent<Square>().j = j;
                square.transform.position = new Vector3(i * SQUARE_SIZE - SQUARE_SIZE * 3.5f, 1.8f, j * SQUARE_SIZE - SQUARE_SIZE * 3.5f);

                for (int k = 0; k < chessPieces.childCount; ++k)
                {
                    if (Vector3.Distance(chessPieces.GetChild(k).position, square.transform.position) < SQUARE_SIZE / 2)
                    {
                        square.GetComponent<Square>().piece = chessPieces.GetChild(k);
                    }
                }
                square.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.0f);


                chessboard[i, j] = square.transform;
            }
        }
    }

    public Square GetPieceRowCol(Transform piece)
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (chessboard[i, j].GetComponent<Square>().piece == piece)
                {
                    Debug.Log("find" + chessboard[i, j].GetComponent<Square>().piece.position);

                    return (chessboard[i, j].GetComponent<Square>());
                    // Debug.Log(chessboard[i, j].GetComponent<Square>().i +":"+ chessboard[i, j].GetComponent<Square>().j);
                }
            }
        }
        return null;
    }

    private bool IsWhite(Transform piece)
    {
        if (piece.name.Contains("White"))
        {
            return true;
        }
        return false;
    }

    public void CheckPosMov(Transform piece)
    {
        squareList.Clear();
        if (piece.name.Contains("Rook"))
        {
            RookPosMove(piece);
        }
        if (piece.name.Contains("Pawn"))
        {
            PawnPosMov(piece);
        }
        if (piece.name.Contains("Bishop"))
        {
            BishopPosMov(piece);
        }
        if (piece.name.Contains("Queen"))
        {
            QueenPosMov(piece);
        }
        if (piece.name.Contains("King"))
        {
            KingPosMov(piece);
        }
        if (piece.name.Contains("Horse"))
        {
            HorsePosMov(piece);
        }
        foreach (Square s in squareList)
        {
            s.GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.3f);
        }

    }

    public void RookPosMove(Transform piece)
    {

        Square s = GetPieceRowCol(piece);

        for (int k = 1; k < 8; k++)
        {

            if ((s.j + k) < 8)
            {
                Square cSquare = chessboard[s.i, s.j + k].GetComponent<Square>();
                if (cSquare.piece == null || (cSquare.piece && IsWhite(piece) != IsWhite(cSquare.piece)))
                {
                    squareList.Add(cSquare);
                    // chessboard[s.i, s.j + k].GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.3f);
                }
                if (cSquare.piece)
                {
                    break;
                }


            }


        }
        for (int k = 1; k < 8; k++)
        {

            if ((s.j - k) >= 0)
            {
                Square cSquare = chessboard[s.i, s.j - k].GetComponent<Square>();
                if (cSquare.piece == null || (cSquare.piece && IsWhite(piece) != IsWhite(cSquare.piece)))
                {
                    squareList.Add(cSquare);
                    //chessboard[s.i, s.j - k].GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.3f);
                }
                if (cSquare.piece)
                {
                    break;
                }
            }
        }
        for (int k = 1; k < 8; k++)
        {
            if ((s.i + k) < 8)
            {
                Square cSquare = chessboard[s.i + k, s.j].GetComponent<Square>();
                if (cSquare.piece == null || (cSquare.piece && IsWhite(piece) != IsWhite(cSquare.piece)))
                {
                    squareList.Add(cSquare);

                    //chessboard[s.i + k, s.j].GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.3f);
                }
                if (cSquare.piece)
                {
                    break;
                }
            }
        }
        for (int k = 1; k < 8; k++)
        {
            if ((s.i - k) >= 0)
            {
                Square cSquare = chessboard[s.i - k, s.j].GetComponent<Square>();
                if (cSquare.piece == null || (cSquare.piece && IsWhite(piece) != IsWhite(cSquare.piece)))
                {
                    squareList.Add(cSquare);
                    //chessboard[s.i - k, s.j].GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.3f);
                }
                if (cSquare.piece)
                {
                    break;
                }
            }
        }

    }



    public void PawnPosMov(Transform piece)
    {
        Square s = GetPieceRowCol(piece);
        int whiteOrBlack = 1;
        if (IsWhite(piece))
        {
            whiteOrBlack = 1;
        }
        else if (!IsWhite(piece))
        {
            whiteOrBlack = -1;
        }



        if (IsWhite(piece) && s.j == 1 || !IsWhite(piece) && s.j == 6)
        {
            for (int i = 1; i < 3; i++)
            {
                Square cSquare = chessboard[s.i, s.j + i * whiteOrBlack].GetComponent<Square>();
                if (cSquare.piece != null)
                {
                    break;
                    //chessboard[s.i - k, s.j].GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.3f);
                }
                squareList.Add(cSquare);
            }
        }
        else
        {

            Square cSquare = chessboard[s.i, s.j + 1 * whiteOrBlack].GetComponent<Square>();
            if (cSquare.piece == null)
            {
                squareList.Add(cSquare);
            }

        }
        Square RtSquare = chessboard[s.i + 1 * whiteOrBlack, s.j + 1 * whiteOrBlack].GetComponent<Square>();
        if (RtSquare.piece)
        {
            if (IsWhite(piece) != IsWhite(RtSquare.piece))
            {
                squareList.Add(RtSquare);
            }
        }
        Square LtSquare = chessboard[s.i - 1 * whiteOrBlack, s.j + 1 * whiteOrBlack].GetComponent<Square>();
        if (LtSquare.piece && IsWhite(piece) != IsWhite(LtSquare.piece))
        {
            squareList.Add(LtSquare);
        }
    }

    public void BishopPosMov(Transform piece)
    {
        Square s = GetPieceRowCol(piece);

        for (int k = 1; k < 8; k++)
        {
            if (s.i + k < 8 && s.j + k < 8)
            {
                Square cSquare = chessboard[s.i + k, s.j + k].GetComponent<Square>();

                if (cSquare.piece == null || (cSquare.piece && IsWhite(piece) != IsWhite(cSquare.piece)))
                {
                    squareList.Add(cSquare);

                    //chessboard[s.i + k, s.j].GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.3f);
                }
                if (cSquare.piece)
                {
                    break;
                }
            }
        }


        for (int k = 1; k < 8; k++)
        {
            if (s.i + k < 8 && s.j - k >= 0)
            {
                Square cSquare = chessboard[s.i + k, s.j - k].GetComponent<Square>();

                if (cSquare.piece == null || (cSquare.piece && IsWhite(piece) != IsWhite(cSquare.piece)))
                {
                    squareList.Add(cSquare);

                    //chessboard[s.i + k, s.j].GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.3f);
                }
                if (cSquare.piece)
                {
                    break;
                }
            }
        }

        for (int k = 1; k < 8; k++)
        {
            if (s.i - k >= 0 && s.j + k < 8)
            {
                Square cSquare = chessboard[s.i - k, s.j + k].GetComponent<Square>();

                if (cSquare.piece == null || (cSquare.piece && IsWhite(piece) != IsWhite(cSquare.piece)))
                {
                    squareList.Add(cSquare);

                    //chessboard[s.i + k, s.j].GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.3f);
                }
                if (cSquare.piece)
                {
                    break;
                }
            }
        }

        for (int k = 1; k < 8; k++)
        {
            if (s.i - k >= 0 && s.j - k >= 0)
            {
                Square cSquare = chessboard[s.i - k, s.j - k].GetComponent<Square>();

                if (cSquare.piece == null || (cSquare.piece && IsWhite(piece) != IsWhite(cSquare.piece)))
                {
                    squareList.Add(cSquare);

                    //chessboard[s.i + k, s.j].GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.3f);
                }
                if (cSquare.piece)
                {
                    break;
                }
            }
        }
    }

    public void QueenPosMov(Transform piece)
    {
        Square s = GetPieceRowCol(piece);

        for (int k = 1; k < 8; k++)
        {

            if ((s.j + k) < 8)
            {
                Square cSquare = chessboard[s.i, s.j + k].GetComponent<Square>();
                if (cSquare.piece == null || (cSquare.piece && IsWhite(piece) != IsWhite(cSquare.piece)))
                {
                    squareList.Add(cSquare);
                    // chessboard[s.i, s.j + k].GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.3f);
                }
                if (cSquare.piece)
                {
                    break;
                }


            }


        }
        for (int k = 1; k < 8; k++)
        {

            if ((s.j - k) >= 0)
            {
                Square cSquare = chessboard[s.i, s.j - k].GetComponent<Square>();
                if (cSquare.piece == null || (cSquare.piece && IsWhite(piece) != IsWhite(cSquare.piece)))
                {
                    squareList.Add(cSquare);
                    //chessboard[s.i, s.j - k].GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.3f);
                }
                if (cSquare.piece)
                {
                    break;
                }
            }
        }
        for (int k = 1; k < 8; k++)
        {
            if ((s.i + k) < 8)
            {
                Square cSquare = chessboard[s.i + k, s.j].GetComponent<Square>();
                if (cSquare.piece == null || (cSquare.piece && IsWhite(piece) != IsWhite(cSquare.piece)))
                {
                    squareList.Add(cSquare);

                    //chessboard[s.i + k, s.j].GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.3f);
                }
                if (cSquare.piece)
                {
                    break;
                }
            }
        }
        for (int k = 1; k < 8; k++)
        {
            if ((s.i - k) >= 0)
            {
                Square cSquare = chessboard[s.i - k, s.j].GetComponent<Square>();
                if (cSquare.piece == null || (cSquare.piece && IsWhite(piece) != IsWhite(cSquare.piece)))
                {
                    squareList.Add(cSquare);
                    //chessboard[s.i - k, s.j].GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.3f);
                }
                if (cSquare.piece)
                {
                    break;
                }
            }
        }

        for (int k = 1; k < 8; k++)
        {
            if (s.i + k < 8 && s.j + k < 8)
            {
                Square cSquare = chessboard[s.i + k, s.j + k].GetComponent<Square>();

                if (cSquare.piece == null || (cSquare.piece && IsWhite(piece) != IsWhite(cSquare.piece)))
                {
                    squareList.Add(cSquare);

                    //chessboard[s.i + k, s.j].GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.3f);
                }
                if (cSquare.piece)
                {
                    break;
                }
            }
        }


        for (int k = 1; k < 8; k++)
        {
            if (s.i + k < 8 && s.j - k >= 0)
            {
                Square cSquare = chessboard[s.i + k, s.j - k].GetComponent<Square>();

                if (cSquare.piece == null || (cSquare.piece && IsWhite(piece) != IsWhite(cSquare.piece)))
                {
                    squareList.Add(cSquare);

                    //chessboard[s.i + k, s.j].GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.3f);
                }
                if (cSquare.piece)
                {
                    break;
                }
            }
        }

        for (int k = 1; k < 8; k++)
        {
            if (s.i - k >= 0 && s.j + k < 8)
            {
                Square cSquare = chessboard[s.i - k, s.j + k].GetComponent<Square>();

                if (cSquare.piece == null || (cSquare.piece && IsWhite(piece) != IsWhite(cSquare.piece)))
                {
                    squareList.Add(cSquare);

                    //chessboard[s.i + k, s.j].GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.3f);
                }
                if (cSquare.piece)
                {
                    break;
                }
            }
        }

        for (int k = 1; k < 8; k++)
        {
            if (s.i - k >= 0 && s.j - k >= 0)
            {
                Square cSquare = chessboard[s.i - k, s.j - k].GetComponent<Square>();

                if (cSquare.piece == null || (cSquare.piece && IsWhite(piece) != IsWhite(cSquare.piece)))
                {
                    squareList.Add(cSquare);

                    //chessboard[s.i + k, s.j].GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.3f);
                }
                if (cSquare.piece)
                {
                    break;
                }
            }
        }
    }

    public void KingPosMov(Transform piece)
    {
        Square s = GetPieceRowCol(piece);

        if ((s.i + 1) < 8)
        {
            Square cSquare = chessboard[s.i + 1, s.j].GetComponent<Square>();
            if (cSquare.piece == null || (cSquare.piece && IsWhite(piece) != IsWhite(cSquare.piece)))
            {
                squareList.Add(cSquare);

                //chessboard[s.i + k, s.j].GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.3f);
            }

        }



        if ((s.i - 1) >= 0)
        {
            Square cSquare = chessboard[s.i - 1, s.j].GetComponent<Square>();
            if (cSquare.piece == null || (cSquare.piece && IsWhite(piece) != IsWhite(cSquare.piece)))
            {
                squareList.Add(cSquare);

                //chessboard[s.i + k, s.j].GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.3f);
            }

        }



        if ((s.j + 1) < 8)
        {
            Square cSquare = chessboard[s.i, s.j + 1].GetComponent<Square>();
            if (cSquare.piece == null || (cSquare.piece && IsWhite(piece) != IsWhite(cSquare.piece)))
            {
                squareList.Add(cSquare);

                //chessboard[s.i + k, s.j].GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.3f);
            }

        }

        if ((s.j - 1) >= 0)
        {
            Square cSquare = chessboard[s.i, s.j - 1].GetComponent<Square>();
            if (cSquare.piece == null || (cSquare.piece && IsWhite(piece) != IsWhite(cSquare.piece)))
            {
                squareList.Add(cSquare);

                //chessboard[s.i + k, s.j].GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.3f);
            }


        }


        if (s.i + 1 < 8 && s.j + 1 < 8)
        {
            Square cSquare = chessboard[s.i + 1, s.j + 1].GetComponent<Square>();

            if (cSquare.piece == null || (cSquare.piece && IsWhite(piece) != IsWhite(cSquare.piece)))
            {
                squareList.Add(cSquare);

                //chessboard[s.i + k, s.j].GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.3f);
            }

        }

        if (s.i - 1 >= 0 && s.j - 1 >= 0)
        {
            Square cSquare = chessboard[s.i - 1, s.j - 1].GetComponent<Square>();

            if (cSquare.piece == null || (cSquare.piece && IsWhite(piece) != IsWhite(cSquare.piece)))
            {
                squareList.Add(cSquare);

                //chessboard[s.i + k, s.j].GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.3f);
            }

        }


        if (s.i + 1 < 8 && s.j - 1 >= 0)
        {
            Square cSquare = chessboard[s.i + 1, s.j - 1].GetComponent<Square>();

            if (cSquare.piece == null || (cSquare.piece && IsWhite(piece) != IsWhite(cSquare.piece)))
            {
                squareList.Add(cSquare);

                //chessboard[s.i + k, s.j].GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.3f);
            }


        }


        if (s.i - 1 >= 0 && s.j + 1 < 8)
        {
            Square cSquare = chessboard[s.i - 1, s.j + 1].GetComponent<Square>();

            if (cSquare.piece == null || (cSquare.piece && IsWhite(piece) != IsWhite(cSquare.piece)))
            {
                squareList.Add(cSquare);

                //chessboard[s.i + k, s.j].GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.3f);
            }
        }


    }

    public void HorsePosMov(Transform piece)
    {
        Square s = GetPieceRowCol(piece);

        if (s.i - 2 >= 0 && s.j + 1 < 8)
        {
            Square cSquare = chessboard[s.i - 2, s.j + 1].GetComponent<Square>();
            if (cSquare.piece == null || (cSquare.piece && IsWhite(piece) != IsWhite(cSquare.piece)))
            {
                squareList.Add(cSquare);

                //chessboard[s.i + k, s.j].GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.3f);
            }

        }

        if (s.i - 1 >= 0 && s.j + 2 < 8)
        {
            Square cSquare = chessboard[s.i - 1, s.j + 2].GetComponent<Square>();
            if (cSquare.piece == null || (cSquare.piece && IsWhite(piece) != IsWhite(cSquare.piece)))
            {
                squareList.Add(cSquare);

                //chessboard[s.i + k, s.j].GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.3f);
            }

        }

        if (s.i + 1 < 8 && s.j + 2 < 8)
        {
            Square cSquare = chessboard[s.i + 1, s.j + 2].GetComponent<Square>();
            if (cSquare.piece == null || (cSquare.piece && IsWhite(piece) != IsWhite(cSquare.piece)))
            {
                squareList.Add(cSquare);

                //chessboard[s.i + k, s.j].GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.3f);
            }

        }

        if (s.i + 2 < 8 && s.j + 1 < 8)
        {
            Square cSquare = chessboard[s.i + 2, s.j + 1].GetComponent<Square>();
            if (cSquare.piece == null || (cSquare.piece && IsWhite(piece) != IsWhite(cSquare.piece)))
            {
                squareList.Add(cSquare);

                //chessboard[s.i + k, s.j].GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.3f);
            }

        }

        if (s.i + 2 < 8 && s.j - 1 >= 0)
        {
            Square cSquare = chessboard[s.i + 2, s.j - 1].GetComponent<Square>();
            if (cSquare.piece == null || (cSquare.piece && IsWhite(piece) != IsWhite(cSquare.piece)))
            {
                squareList.Add(cSquare);

                //chessboard[s.i + k, s.j].GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.3f);
            }

        }

        if (s.i + 1 < 8 && s.j - 2 >= 0)
        {
            Square cSquare = chessboard[s.i + 1, s.j - 2].GetComponent<Square>();
            if (cSquare.piece == null || (cSquare.piece && IsWhite(piece) != IsWhite(cSquare.piece)))
            {
                squareList.Add(cSquare);

                //chessboard[s.i + k, s.j].GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.3f);
            }

        }

        if (s.i - 1 >= 0 && s.j - 2 >= 0)
        {
            Square cSquare = chessboard[s.i - 1, s.j - 2].GetComponent<Square>();
            if (cSquare.piece == null || (cSquare.piece && IsWhite(piece) != IsWhite(cSquare.piece)))
            {
                squareList.Add(cSquare);

                //chessboard[s.i + k, s.j].GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.3f);
            }

        }

        if (s.i - 2 >= 0 && s.j - 1 >= 0)
        {
            Square cSquare = chessboard[s.i - 2, s.j - 1].GetComponent<Square>();
            if (cSquare.piece == null || (cSquare.piece && IsWhite(piece) != IsWhite(cSquare.piece)))
            {
                squareList.Add(cSquare);

                //chessboard[s.i + k, s.j].GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0.3f);
            }

        }
    }

    public void UnhighlightSquare()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                chessboard[i, j].GetComponent<MeshRenderer>().material.color = new Color(1, 0, 0, 0);
            }
        }
    }

    public void UpdateChessborad(Square s, Transform piece)
    {
        if (piece)
        {
            Square OriSquare = GetPieceRowCol(piece);
            chessboard[OriSquare.i, OriSquare.j].GetComponent<Square>().piece = null;

            chessboard[s.i, s.j].GetComponent<Square>().piece = piece;

            Debug.Log(piece.name.Contains("Black"));
        }
    }
}
