using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndGame : MonoBehaviour
{
    public GameObject winnerWindow;
    public Text winText;

    public void ShowWinnerWindow(CellStatus status)
    {
        winText.text = string.Format("{0} Wins!", status);
        winnerWindow.SetActive(true);
    }

    public void LeaveScene()
    {
        SceneManager.LoadSceneAsync(0);
    }
}
