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
    [SerializeField] private KeyCode Interact;
    [SerializeField] private float _speed = 1.0f;
    [SerializeField] private Transform _itemHolder;

    private GameObject _holdedItem;

    private bool _isHoldItem;

    #endregion

    #region Properties

    public bool IsInteract { get; private set; }

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

        if (_isHoldItem)
            _holdedItem.transform.position = _itemHolder.position;
    }

    private void Update()
    {
        if (Input.GetKey(Interact))
        {
            IsInteract = true;
            Debug.Log("Interact");
        }
        else IsInteract = false;
    }

    #endregion

    #region Methods

    public void PickUpMaterial(GameObject go)
    {
        _holdedItem = go;
        _holdedItem.transform.position = _itemHolder.position;
        _isHoldItem = true;
    }

    #endregion
}
