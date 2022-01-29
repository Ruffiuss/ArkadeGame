using UnityEngine;
using System.Collections.Generic;


internal sealed class RawSpawner : MonoBehaviour
{
    #region Fields

    public InteractableController[] RawInteractables;
    public GameObject[] RawMaterialObjects;

    private Dictionary<GameObject, bool> _isMaterialUsed;

    #endregion

    #region UnityMethods

    private void Awake()
    {
        _isMaterialUsed = new Dictionary<GameObject, bool>();

        for (int i = 0; i < RawMaterialObjects.Length; i++)
        {
            _isMaterialUsed.Add(RawMaterialObjects[i], false);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < RawInteractables.Length; i++)
            {
                if (!RawInteractables[i].IsHoldItem)
                {
                    RawInteractables[i].SpawnRawMaterial(GetFreeMaterial());
                    break;
                }    
            }
        }
    }

    #endregion

    #region Methods

    public GameObject GetFreeMaterial()
    {
        GameObject goBuffer = null;

        foreach (var material in _isMaterialUsed)
        {
            if (!material.Value)
            {
                goBuffer = material.Key;
            }
        }
        if (goBuffer != null)
        {
            _isMaterialUsed.Remove(goBuffer);
            return goBuffer;
        }
        else throw new System.Exception("No free materials");
    }

    #endregion
}
