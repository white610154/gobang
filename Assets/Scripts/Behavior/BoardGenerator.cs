using UnityEngine;

public class BoardGenerator : MonoBehaviour
{
    public float cellLength;
    public GameObject cellPrefab;

    float zero;

    void Start()
    {
        zero = -9f * cellLength;

        GoalManager goalManager = (GoalManager)FindObjectOfType<GoalManager>();

        for (int i = 0; i < 19; i++)
        {
            for (int j = 0; j < 19; j++)
            {
                goalManager.cells[i, j] = CreateCell(i, j);
            }
        }

        Destroy(this);
    }

    GameObject CreateCell(int i, int j)
    {
        Vector3 position = new Vector3(zero + i * cellLength, zero + j * cellLength, 0f);
        GameObject cell = (GameObject)Instantiate(cellPrefab, position, Quaternion.identity);

        cell.name = string.Format("cell-{0:00}-{1:00}", i, j);

        PlaceChess placeChessComponent = (PlaceChess)cell.GetComponent<PlaceChess>();
        placeChessComponent.position = new Vector2Int(i, j);

        return cell;
    }
}
