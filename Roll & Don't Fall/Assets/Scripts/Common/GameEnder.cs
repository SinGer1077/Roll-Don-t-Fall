using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnder : MonoBehaviour
{
    [SerializeField]
    private GameObject _endGameCanvas;

    public void EndGame()
    {
        _endGameCanvas.SetActive(true);
    }
}
