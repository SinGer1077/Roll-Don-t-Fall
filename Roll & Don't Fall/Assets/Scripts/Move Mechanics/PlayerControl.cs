using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField]
    private PlayerInput _playerInput;

    private void Update()
    {
        if (_playerInput.actions["Move"].triggered)
        {
            Vector2 value = _playerInput.actions["Move"].ReadValue<Vector2>();
            Debug.Log(value);
        }
    }
}
