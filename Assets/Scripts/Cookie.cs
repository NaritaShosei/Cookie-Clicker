using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Cookie : ButtonBase
{
    DataManager _dataManager;
    Sequence _sequence;

    private void Start()
    {
        OnClick.AddListener(AddPoint);
        _dataManager = ServiceLocator.Get<DataManager>();
    }

    private void AddPoint()
    {
        _dataManager.CookieData.AddCookie(1);

        Debug.Log(_dataManager.CookieData.CookieCount);
        Click();
    }

    private void Click()
    {
        _sequence?.Kill();

        _sequence = DOTween.Sequence();
        _sequence.Append(transform.DOScale(Vector3.one * 0.8f, 0.15f)).Append(transform.DOScale(Vector3.one * 1.2f, 0.3f)).Append(transform.DOScale(Vector3.one, 0.3f));
    }

}
