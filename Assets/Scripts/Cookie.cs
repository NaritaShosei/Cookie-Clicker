using UnityEngine;
using UnityEngine.EventSystems;

public class Cookie : ButtonBase
{
    private void Start()
    {
        OnClick += AddPoint;
    }

    private void AddPoint()
    {

    }
}
