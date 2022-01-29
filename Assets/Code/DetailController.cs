using UnityEngine;

internal enum Detail
{
    Clean = 0,
    State1 = 1,
    State2 = 2,
    State3 = 3,
    Ready = 4
}


internal sealed class DetailController : MonoBehaviour
{
    #region Fields


    #endregion

    #region Properties

    public Detail State { get; internal set; }

    #endregion

    #region UnityMethods

    private void Awake()
    {
        State = 0;
    }

    #endregion
}
