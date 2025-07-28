using UnityEngine;
using UnityEngine.EventSystems;

public class Cookie : ButtonBase
{
    DataManager _dataManager;

    private void Start()
    {
        OnClick.AddListener(AddPoint);
        OnRightClick.AddListener(ResetPoint);
        _dataManager = ServiceLocator.Get<DataManager>();
    }

    private void AddPoint()
    {
        _dataManager.CookieData.AddCookie(1);

        Debug.Log(_dataManager.CookieData.CookieCount);
    }

    private void ResetPoint()
    {
        _dataManager.DataReset();

        Debug.Log(_dataManager.CookieData.CookieCount);
    }
}
