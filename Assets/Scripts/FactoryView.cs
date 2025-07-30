using DG.Tweening;
using UnityEngine;

public class FactoryView : ButtonBase
{
    [SerializeField] private int _rate;
    [SerializeField] private string _factoryName = "";
    [SerializeField] private int _cost;
    [SerializeField] private int _cookiePerSecond;
    private FactoryData _data;
    private Sequence _sequence;
    private void Start()
    {
        OnClick.AddListener(AddFactory);
        _data = ServiceLocator.Get<DataManager>().GetFactory(_factoryName);
    }

    public void AddFactory()
    {
        if (_factoryName == "") { Debug.LogWarning("名前を変更してください。空文字のままです。"); }
        if (_data == null)
        {
            _data = ServiceLocator.Get<DataManager>().GetFactory(_factoryName);
            _data = _data != null ?
                _data :
                new FactoryData
                {
                    Name = _factoryName,
                    BaseCost = _cost,
                    CookiePerSecond = _cookiePerSecond
                };

            ServiceLocator.Get<DataManager>().AddFactory(_data);
        }
        _data.AddClicker();
        Click();
    }

    private void Click()
    {
        _sequence?.Kill();

        _sequence = DOTween.Sequence();
        _sequence.Append(transform.DOScale(Vector3.one * 0.8f, 0.15f)).Append(transform.DOScale(Vector3.one * 1.2f, 0.3f)).Append(transform.DOScale(Vector3.one, 0.3f));
    }

    public void ResetFactory()
    {
        _data = null;
        Debug.LogWarning("施設のデータをリセットしました");
    }
}
