using UnityEngine;


public class TurnManager : MonoBehaviour
{
    public Turn turn;

    // Start is called before the first frame update
    void Start()
    {
        turn = Turn.black;
    }

    public void TurnBlack()
    {
        turn = Turn.black;
    }

    public void TurnWhite()
    {
        turn = Turn.white;
    }
}
