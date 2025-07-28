using System.Linq;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public CookieData CookieData { get; private set; }

    private void Awake()
    {
        CookieData = SaveLoadService.Load<CookieData>();
        ServiceLocator.Set(this);
    }

    public void DataReset()
    {
        CookieData = SaveLoadService.Reset<CookieData>();
    }

    public FactoryData GetFactory(string name)
    {
        return CookieData.FactoryDatas.Find(f => f.Name == name);
    }

    public void AddFactory(FactoryData data)
    {
        CookieData.FactoryDatas.Add(data);
    }

    private void OnDisable()
    {
        SaveLoadService.Save(CookieData);
    }
}
