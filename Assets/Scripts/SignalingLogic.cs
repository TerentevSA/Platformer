using UnityEngine;
using UnityEngine.Events;

public class SignalingLogic : MonoBehaviour
{
    [SerializeField] private UnityEvent _playerEnter;
    [SerializeField] private UnityEvent _playerExit;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
            _playerEnter.Invoke();
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
            _playerExit.Invoke();
    }
}