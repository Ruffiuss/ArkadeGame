using UnityEngine;


internal enum Player
{
    Player1 = 0, Player2 = 1 
}

internal sealed class PlayerController : MonoBehaviour
{
    #region Fields

    private Rigidbody _rigidbody;

    [SerializeField] private Player _player;
    [SerializeField] private KeyCode Up;
    [SerializeField] private KeyCode Down;
    [SerializeField] private KeyCode Left;
    [SerializeField] private KeyCode Right;
    [SerializeField] private float _speed = 1.0f;

    #endregion

    #region UnityMethods

    private void Awake()
    {
        _rigidbody = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        
        if (Input.GetKey(Up))
            _rigidbody.velocity += new Vector3(0, 0, _speed * Time.deltaTime);
        if (Input.GetKey(Down))
            _rigidbody.velocity -= new Vector3(0, 0, _speed * Time.deltaTime);
        if (Input.GetKey(Left))
            _rigidbody.velocity -= new Vector3(_speed * Time.deltaTime, 0, 0);
        if (Input.GetKey(Right))
            _rigidbody.velocity += new Vector3(_speed * Time.deltaTime, 0, 0);
    }

    #endregion
}
