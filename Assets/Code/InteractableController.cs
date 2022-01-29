using UnityEngine;

internal enum Interactable
{
    RawMaterial = 0,
    Machine1 = 1,
    Machine2 = 2,
    Machine3 = 3,
    Store = 4
}

internal sealed class InteractableController : MonoBehaviour
{
    #region Fields


    [SerializeField] private Interactable _type;
    [SerializeField] private Transform _itemHolder;

    private CapsuleCollider _triggerZone;
    private GameObject _holdedItem;
    private PlayerController _whoInteract;

    private bool _isHoldItem;

    #endregion

    #region Properties

    public Transform ItemHolder { get => _itemHolder; }
    public bool IsHoldItem { get => _isHoldItem; }

    #endregion

    #region UnityMethods

    private void Awake()
    {
        _triggerZone = gameObject.GetComponent<CapsuleCollider>();
        Initilize(_type);
    }

    private void Update()
    {
        if (_isHoldItem)
        {
            if (_whoInteract != null && _whoInteract.IsInteract)
            {
                _whoInteract.PickUpMaterial(_holdedItem);
                _holdedItem = null;
                _isHoldItem = false;
            }
            else Debug.Log("Didn`t interact");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        _whoInteract = other.gameObject.GetComponent<PlayerController>();
    }

    private void OnTriggerExit(Collider other)
    {
        _whoInteract = null;
    }

    #endregion

    #region Methods

    private void Initilize(Interactable type)
    {
        switch (type)
        {
            case Interactable.RawMaterial:
                break;
            case Interactable.Machine1:
                break;
            case Interactable.Machine2:
                break;
            case Interactable.Machine3:
                break;
            case Interactable.Store:
                break;
            default:
                break;
        }
    }

    internal void SpawnRawMaterial(GameObject go)
    {
        _holdedItem = go;
        _holdedItem.transform.position = _itemHolder.position;
        _isHoldItem = true;
        _holdedItem.SetActive(true);
    }

    #endregion
}
