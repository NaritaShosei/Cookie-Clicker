using UnityEngine;

public class FactoryView : ButtonBase
{
    [SerializeField] private int _rate;
    [SerializeField] private string _factoryName = "";
    private FactoryData _data;

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
            _data = _data != null ? _data : new FactoryData { Name = _factoryName };
            ServiceLocator.Get<DataManager>().AddFactory(_data);
        }
        _data.AddClicker();
    }

    public void ResetFactory()
    {
        _data = null;
        Debug.LogWarning("施設のデータをリセットしました");
    }
}
