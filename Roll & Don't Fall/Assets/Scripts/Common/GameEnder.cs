using UnityEngine;
using UnityEngine.UI;

public class GameEnder : MonoBehaviour
{
    [SerializeField]
    private GameObject _endGameCanvas;

    [SerializeField]
    private GameScore _score;

    [SerializeField]
    private Text _finalText;

    public void EndGame()
    {
        _endGameCanvas.SetActive(true);
        _finalText.text = "Result: "+ _score.Score.ToString();
    }
}
