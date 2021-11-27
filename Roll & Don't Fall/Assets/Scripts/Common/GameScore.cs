using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour
{
    [SerializeField]
    private Transform _character;

    [SerializeField]
    private Text _scoreText;

    private Vector3 _firstPosition;
    void Start()
    {
        _firstPosition = _character.position;
    }

    void Update()
    {
        _scoreText.text = "Distance: " + ((int)(_character.position.z - _firstPosition.z)).ToString();
    }
}
