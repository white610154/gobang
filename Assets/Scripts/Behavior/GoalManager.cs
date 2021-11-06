using UnityEngine;

public class GoalManager : MonoBehaviour
{
    public GameObject[,] cells = new GameObject[19, 19];
    public bool goaled = false;

    CellStatus status;

    public void CheckGoal(Vector2Int position)
    {
        status = StatusOfCell(position);

        if (
            CheckHorizontal(position) ||
            CheckVertical(position) ||
            CheckLeftCross(position) ||
            CheckRightCross(position)
        )
        {
            goaled = true;

            EndGame endGame = GameObject.FindObjectOfType<EndGame>();
            endGame.ShowWinnerWindow(status);
        }
    }

    CellStatus StatusOfCell(Vector2Int position)
    {
        GameObject cell = cells[position.x, position.y];
        PlaceChess placeChess = (PlaceChess)cell.GetComponent<PlaceChess>();
        return placeChess.status;
    }

    bool CheckHorizontal(Vector2Int p)
    {
        int count = 1;

        int i = 1;
        while (p.x - i >= 0)
        {
            if (StatusOfCell(new Vector2Int(p.x - i, p.y)) != status) break;

            count++;
            i++;
        }

        int j = 1;
        while (p.x + j < 19)
        {
            if (StatusOfCell(new Vector2Int(p.x + j, p.y)) != status) break;

            count++;
            j++;
        }

        if (count >= 5) return true;
        return false;
    }

    bool CheckVertical(Vector2Int p)
    {
        int count = 1;

        int i = 1;
        while (p.y - i >= 0)
        {
            if (StatusOfCell(new Vector2Int(p.x, p.y - i)) != status) break;

            count++;
            i++;
        }

        int j = 1;
        while (p.y + j < 19)
        {
            if (StatusOfCell(new Vector2Int(p.x, p.y + j)) != status) break;

            count++;
            j++;
        }

        if (count >= 5) return true;
        return false;
    }

    bool CheckLeftCross(Vector2Int p)
    {
        int count = 1;

        int i = 1;
        while (p.x - i >= 0 && p.y + i < 19)
        {
            if (StatusOfCell(new Vector2Int(p.x - i, p.y + i)) != status) break;

            count++;
            i++;
        }

        int j = 1;
        while (p.x + j < 19 && p.y - j >= 0)
        {
            if (StatusOfCell(new Vector2Int(p.x + j, p.y - j)) != status) break;

            count++;
            j++;
        }

        if (count >= 5) return true;
        return false;
    }

    bool CheckRightCross(Vector2Int p)
    {
        int count = 1;

        int i = 1;
        while (p.x - i >= 0 && p.y - i >= 0)
        {
            if (StatusOfCell(new Vector2Int(p.x - i, p.y - i)) != status) break;

            count++;
            i++;
        }

        int j = 1;
        while (p.x + j < 19 && p.y + j < 19)
        {
            if (StatusOfCell(new Vector2Int(p.x + j, p.y + j)) != status) break;

            count++;
            j++;
        }

        if (count >= 5) return true;
        return false;
    }
}
