using UnityEngine;

public class PlaceChess : MonoBehaviour
{
    public SpriteRenderer colorRenderer;
    public Vector2Int position;
    public CellStatus status = CellStatus.Empty;

    TurnManager turnManager;
    GoalManager goalManager;

    void Start()
    {
        turnManager = (TurnManager)FindObjectOfType<TurnManager>();
        goalManager = (GoalManager)FindObjectOfType<GoalManager>();
    }

    public void PlaceBlack()
    {
        colorRenderer.color = Color.black;
        status = CellStatus.Black;
        goalManager.CheckGoal(position);

        turnManager.TurnWhite();
    }

    public void PlaceWhite()
    {
        colorRenderer.color = Color.white;
        status = CellStatus.White;
        goalManager.CheckGoal(position);

        turnManager.TurnBlack();
    }

    void OnMouseDown()
    {
        if (goalManager.goaled) return;

        if (status != CellStatus.Empty) return;

        switch (turnManager.turn)
        {
            case Turn.black:
                PlaceBlack();
                break;
            case Turn.white:
                PlaceWhite();
                break;
        }
    }
}
