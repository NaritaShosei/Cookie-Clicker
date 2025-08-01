using Cysharp.Threading.Tasks;
using DG.Tweening;
using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class FactoryView : ButtonBase
{
    [SerializeField] private int _rate;
    [SerializeField] private string _factoryName = "";
    [SerializeField] private int _cost = 50;
    [SerializeField] private int _cookiePerSecond = 1;
    private FactoryData _data;
    private Sequence _sequence;
    DataManager _dataManager;
    private CancellationTokenSource _cts;
    private void Start()
    {
        OnClick.AddListener(AddFactory);
        _data = ServiceLocator.Get<DataManager>().GetFactory(_factoryName);
        _cts = new CancellationTokenSource();
        _dataManager = ServiceLocator.Get<DataManager>();
        if (_data != null)
        {
            AutoClick(_cts.Token).Forget();
        }
    }

    private async UniTask AutoClick(CancellationToken token)
    {
        while (true)
        {
            await UniTask.Delay(1000, cancellationToken: token);
            _dataManager.CookieData.AddCookie(_data.CookiePerSecond * _data.AutoClickCount);
        }
    }

    public void AddFactory()
    {
        try
        {
            Debug.Log(_data.GetCurrentCost() + "今のコスト");
        }
        catch { }
        int cost = _data != null ? _data.GetCurrentCost() : _cost;
        if (_dataManager.CookieData.CookieCount < cost) { Debug.Log($"{cost}未満です"); return; }

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

            _cts = new CancellationTokenSource();

            AutoClick(_cts.Token).Forget();
        }
        _dataManager.CookieData.CookieCount -= cost;
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

        if (_cts == null) { return; }
        _cts.Cancel();
        _cts.Dispose();
        _cts = null;
    }
}
