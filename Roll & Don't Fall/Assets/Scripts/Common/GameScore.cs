using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    [SerializeField]
    private Transform _character;

    [SerializeField]
    private Text _scoreText;

    private int _score = 0;

    public int Score => _score;

    private Vector3 _firstPosition;
    void Start()
    {
        _firstPosition = _character.position;
    }

    void Update()
    {
        _score = (int)(_character.position.z - _firstPosition.z);
        _scoreText.text = "Distance: " + _score.ToString();
    }
}
